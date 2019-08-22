using FastMember;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EFCore.BulkExtensions
{
    internal class ObjectReaderEx : ObjectReader // Overridden to fix ShadowProperties in FastMember library
    {
        private readonly List<IProperty> _shadowProperties;
        private readonly Dictionary<string, ValueConverter> _convertibleProperties;
        private readonly DbContext _context;
        private readonly string[] _members;
        private readonly FieldInfo _current;

        private ObjectReaderEx(Type type, IEnumerable source, List<IProperty> shadowProperties, Dictionary<string, ValueConverter> convertibleProperties, DbContext context, params string[] members) : base(type, source, members)
        {
            _shadowProperties = shadowProperties;
            _convertibleProperties = convertibleProperties;
            _context = context;
            _members = members;
            _current = typeof(ObjectReader).GetField("current", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static ObjectReader Create<T>(IEnumerable<T> source, List<IProperty> shadowProperties, Dictionary<string, ValueConverter> convertibleProperties, DbContext context, params string[] members)
        {
            var hasShadowProp = shadowProperties.Count > 0;
            var hasConvertibleProperties = convertibleProperties.Keys.Count > 0;
            return (hasShadowProp || hasConvertibleProperties)
                ? new ObjectReaderEx(typeof(T), source, shadowProperties, convertibleProperties, context, members)
                : Create(source, members);
        }

        public override object this[string name]
        {
            get
            {
                foreach (var shadowProperty in _shadowProperties)
                {
                    if (shadowProperty.Name != name)
                        continue;

                    var prop = shadowProperty.GetContainingForeignKeys().ToList();
                    var current = _current.GetValue(this);

                    var entityType = prop[0].PrincipalEntityType;
                    var key = prop[0].PrincipalKey;
                    var nameColumn = GetName(current, entityType);
                    var reference = _context.Entry(current).Reference(nameColumn).CurrentValue;
                    var value = GetValue<int>(reference, key);

                    return _context.Entry(current).Property(name).CurrentValue = value;
                    /*GetValue<int>(_context.Entry(current).Reference(GetName(current, prop[0].PrincipalEntityType)).CurrentValue, prop[0].PrincipalKey);*/
                }

                if (!_convertibleProperties.TryGetValue(name, out var converter)) return base[name];
                {
                    var current = _current.GetValue(this);
                    var currentValue = _context.Entry(current).Property(name).CurrentValue;
                    return converter.ConvertToProvider(currentValue);
                }
            }
        }

        public override object this[int i]
        {
            get
            {
                var name = _members[i];
                return this[name];
            }
        }

        private static string GetName(object obj, IEntityType name)
        {
            var text = string.Empty;
            foreach (var p in obj.GetType().GetProperties())
            {
                if (name.Name == p.PropertyType.FullName) text = p.Name;
            }
            return text;
        }

        private static T GetValue<T>(object obj, IKey key)
        {
            var p = obj.GetType().GetProperty(key.Properties[0].Name);
            return (T)p.GetValue(obj, null);
        }
    }
}
