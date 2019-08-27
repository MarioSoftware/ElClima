using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Core.Entities
{
    public abstract class BaseEntity
    {
        public int id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntity;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (ReferenceEquals(null, compareTo))
            {
                return false;
            }

            return id.Equals(compareTo.id);
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 33) + id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + id + "]";
        }
    }
}
