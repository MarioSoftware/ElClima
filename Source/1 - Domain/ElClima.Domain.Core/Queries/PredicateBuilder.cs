﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;

namespace ElClima.Domain.Core.Queries
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = CreateParameterFrom(expr1, expr2);
            return Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(
                    Rewrite(expr1.Body, parameter),
                    Rewrite(expr2.Body, parameter)),
                parameter);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = CreateParameterFrom(expr1, expr2);
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    Rewrite(expr1.Body, parameter),
                    Rewrite(expr2.Body, parameter)),
                parameter);
        }

        private static ParameterExpression CreateParameterFrom(LambdaExpression left, LambdaExpression right)
        {
            var leftParameters = left.Parameters;
            var rightParameters = right.Parameters;

            if (leftParameters.Count != right.Parameters.Count)
                throw new ArgumentException();

            if (leftParameters.Count != 1)
                throw new ArgumentException();

            if (leftParameters[0].Type != rightParameters[0].Type)
                throw new ArgumentException();

            return Expression.Parameter(leftParameters[0].Type, leftParameters[0].Name);
        }

        private static Expression Rewrite(Expression expression, ParameterExpression parameter)
        {
            return new ParameterRewriter(parameter).Transform(expression);
        }

        private class ParameterRewriter : ExpressionTransformer
        {
            private readonly ParameterExpression _parameter;

            public ParameterRewriter(ParameterExpression parameter)
            {
                _parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression expression)
            {
                return _parameter;
            }
        }
    }

    internal abstract class ExpressionTransformer
    {
        public Expression Transform(Expression expression)
        {
            return Visit(expression);
        }

        protected virtual Expression Visit(Expression exp)
        {
            if (exp == null)
                return null;

            switch (exp.NodeType)
            {
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                case ExpressionType.UnaryPlus:
                    return VisitUnary((UnaryExpression)exp);
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Power:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                    return VisitBinary((BinaryExpression)exp);
                case ExpressionType.TypeIs:
                    return VisitTypeIs((TypeBinaryExpression)exp);
                case ExpressionType.Conditional:
                    return VisitConditional((ConditionalExpression)exp);
                case ExpressionType.Constant:
                    return VisitConstant((ConstantExpression)exp);
                case ExpressionType.Parameter:
                    return VisitParameter((ParameterExpression)exp);
                case ExpressionType.MemberAccess:
                    return VisitMemberAccess((MemberExpression)exp);
                case ExpressionType.Call:
                    return VisitMethodCall((MethodCallExpression)exp);
                case ExpressionType.Lambda:
                    return VisitLambda((LambdaExpression)exp);
                case ExpressionType.New:
                    return VisitNew((NewExpression)exp);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return VisitNewArray((NewArrayExpression)exp);
                case ExpressionType.Invoke:
                    return VisitInvocation((InvocationExpression)exp);
                case ExpressionType.MemberInit:
                    return VisitMemberInit((MemberInitExpression)exp);
                case ExpressionType.ListInit:
                    return VisitListInit((ListInitExpression)exp);
                default:
                    throw new Exception(string.Format("Unhandled expression type: '{0}'", exp.NodeType));
            }
        }

        protected virtual MemberBinding VisitBinding(MemberBinding binding)
        {
            switch (binding.BindingType)
            {
                case MemberBindingType.Assignment:
                    return VisitMemberAssignment((MemberAssignment)binding);
                case MemberBindingType.MemberBinding:
                    return VisitMemberMemberBinding((MemberMemberBinding)binding);
                case MemberBindingType.ListBinding:
                    return VisitMemberListBinding((MemberListBinding)binding);
                default:
                    throw new Exception(string.Format("Unhandled binding type '{0}'", binding.BindingType));
            }
        }

        protected virtual ElementInit VisitElementInitializer(ElementInit initializer)
        {
            var arguments = VisitExpressionList(initializer.Arguments);
            return arguments != initializer.Arguments
                ? Expression.ElementInit(initializer.AddMethod, arguments)
                : initializer;
        }

        protected virtual Expression VisitUnary(UnaryExpression u)
        {
            var operand = Visit(u.Operand);
            return operand != u.Operand
                ? Expression.MakeUnary(u.NodeType, operand, u.Type, u.Method)
                : u;
        }

        protected virtual Expression VisitBinary(BinaryExpression b)
        {
            var left = Visit(b.Left);
            var right = Visit(b.Right);
            var conversion = Visit(b.Conversion);
            if (left == b.Left && right == b.Right && conversion == b.Conversion)
            {
                return b;
            }

            if (b.NodeType == ExpressionType.Coalesce && b.Conversion != null)
            {
                return Expression.Coalesce(left, right, conversion as LambdaExpression);
            }

            return Expression.MakeBinary(b.NodeType, left, right, b.IsLiftedToNull, b.Method);
        }

        protected virtual Expression VisitTypeIs(TypeBinaryExpression b)
        {
            var expr = Visit(b.Expression);
            return expr != b.Expression
                ? Expression.TypeIs(expr, b.TypeOperand)
                : b;
        }

        protected virtual Expression VisitConstant(ConstantExpression c)
        {
            return c;
        }

        protected virtual Expression VisitConditional(ConditionalExpression c)
        {
            var test = Visit(c.Test);
            var ifTrue = Visit(c.IfTrue);
            var ifFalse = Visit(c.IfFalse);
            if (test != c.Test || ifTrue != c.IfTrue || ifFalse != c.IfFalse)
            {
                return Expression.Condition(test, ifTrue, ifFalse);
            }
            return c;
        }

        protected virtual Expression VisitParameter(ParameterExpression p)
        {
            return p;
        }

        protected virtual Expression VisitMemberAccess(MemberExpression m)
        {
            var exp = Visit(m.Expression);
            return exp != m.Expression
                ? Expression.MakeMemberAccess(exp, m.Member)
                : m;
        }

        protected virtual Expression VisitMethodCall(MethodCallExpression m)
        {
            var obj = Visit(m.Object);
            IEnumerable<Expression> args = VisitExpressionList(m.Arguments);
            if (obj != m.Object || !Equals(args, m.Arguments))
            {
                return Expression.Call(obj, m.Method, args);
            }
            return m;
        }

        protected virtual ReadOnlyCollection<Expression> VisitExpressionList(ReadOnlyCollection<Expression> original)
        {
            var list = VisitList(original, Visit);
            return list == null
                ? original
                : new ReadOnlyCollection<Expression>(list);
        }

        protected virtual MemberAssignment VisitMemberAssignment(MemberAssignment assignment)
        {
            var e = Visit(assignment.Expression);
            return e != assignment.Expression
                ? Expression.Bind(assignment.Member, e)
                : assignment;
        }

        protected virtual MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding binding)
        {
            var bindings = VisitBindingList(binding.Bindings);
            return !Equals(bindings, binding.Bindings)
                ? Expression.MemberBind(binding.Member, bindings)
                : binding;
        }

        protected virtual MemberListBinding VisitMemberListBinding(MemberListBinding binding)
        {
            var initializers = VisitElementInitializerList(binding.Initializers);
            return !Equals(initializers, binding.Initializers)
                ? Expression.ListBind(binding.Member, initializers)
                : binding;
        }

        protected virtual IEnumerable<MemberBinding> VisitBindingList(ReadOnlyCollection<MemberBinding> original)
        {
            return VisitList(original, VisitBinding);
        }

        protected virtual IEnumerable<ElementInit> VisitElementInitializerList(ReadOnlyCollection<ElementInit> original)
        {
            return VisitList(original, VisitElementInitializer);
        }

        private static IList<TElement> VisitList<TElement>(ReadOnlyCollection<TElement> original, Func<TElement, TElement> visit)
        {
            List<TElement> list = null;
            for (int i = 0, n = original.Count; i < n; i++)
            {
                var element = visit(original[i]);
                if (list != null)
                {
                    list.Add(element);
                }
                else if (!EqualityComparer<TElement>.Default.Equals(element, original[i]))
                {
                    list = new List<TElement>(n);
                    for (var j = 0; j < i; j++)
                    {
                        list.Add(original[j]);
                    }
                    list.Add(element);
                }
            }

            if (list != null)
            {
                return list;
            }

            return original;
        }

        protected virtual Expression VisitLambda(LambdaExpression lambda)
        {
            var body = Visit(lambda.Body);
            return body != lambda.Body
                ? Expression.Lambda(lambda.Type, body, lambda.Parameters)
                : lambda;
        }

        protected virtual NewExpression VisitNew(NewExpression nex)
        {
            IEnumerable<Expression> args = VisitExpressionList(nex.Arguments);
            if (Equals(args, nex.Arguments))
            {
                return nex;
            }

            return nex.Members != null
                ? Expression.New(nex.Constructor, args, nex.Members)
                : Expression.New(nex.Constructor, args);
        }

        protected virtual Expression VisitMemberInit(MemberInitExpression init)
        {
            var n = VisitNew(init.NewExpression);
            var bindings = VisitBindingList(init.Bindings);
            if (n != init.NewExpression || !Equals(bindings, init.Bindings))
            {
                return Expression.MemberInit(n, bindings);
            }

            return init;
        }

        protected virtual Expression VisitListInit(ListInitExpression init)
        {
            var n = VisitNew(init.NewExpression);
            var initializers = VisitElementInitializerList(init.Initializers);
            if (n != init.NewExpression || !Equals(initializers, init.Initializers))
            {
                return Expression.ListInit(n, initializers);
            }

            return init;
        }

        protected virtual Expression VisitNewArray(NewArrayExpression na)
        {
            IEnumerable<Expression> exprs = VisitExpressionList(na.Expressions);
            if (Equals(exprs, na.Expressions))
            {
                return na;
            }

            return na.NodeType == ExpressionType.NewArrayInit
                ? Expression.NewArrayInit(na.Type.GetElementType(), exprs)
                : Expression.NewArrayBounds(na.Type.GetElementType(), exprs);
        }

        protected virtual Expression VisitInvocation(InvocationExpression iv)
        {
            var args = VisitExpressionList(iv.Arguments);
            var expr = Visit(iv.Expression);
            if (args != iv.Arguments || expr != iv.Expression)
            {
                return Expression.Invoke(expr, args);
            }

            return iv;
        }
    }
}
