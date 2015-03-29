﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gesetzesentwicklung.Shared
{
    // Quelle: https://digitaltapestry.wordpress.com/2009/03/20/reflecting-on-code/
    public static class ReflectOn<T>
    {
        public static MemberInfo GetMember(Expression<Action<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(Reflect.GetMember(() => expression).Name);
            }

            return Reflect.GetMemberInfo(expression as LambdaExpression);
        }

        public static MemberInfo GetMember<TResult>(Expression<Func<T, TResult>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(Reflect.GetMember(() => expression).Name);
            }

            return Reflect.GetMemberInfo(expression as LambdaExpression);
        }

        public static MethodInfo GetMethod(Expression<Action<T>> expression)
        {
            MethodInfo method = GetMember(expression) as MethodInfo;
            if (method == null)
            {
                throw new ArgumentException(
                    "Not a method call expression",
                    Reflect.GetMember(() => expression).Name);
            }

            return method;
        }

        public static PropertyInfo GetProperty<TResult>(Expression<Func<T, TResult>> expression)
        {
            PropertyInfo property = GetMember(expression) as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException(
                    "Not a property expression", Reflect.GetMember(() => expression).Name);
            }

            return property;
        }

        public static FieldInfo GetField<TResult>(Expression<Func<T, TResult>> expression)
        {
            FieldInfo field = GetMember(expression) as FieldInfo;
            if (field == null)
            {
                throw new ArgumentException(
                    "Not a field expression", Reflect.GetMember(() => expression).Name);
            }

            return field;
        }
    }
}