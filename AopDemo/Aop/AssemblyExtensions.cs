using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AopDemo.Aop
{
    /// <summary>
    ///   Helper class for retrieving attributes.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        ///   Gets the attribute.
        /// </summary>
        /// <param name = "member">The member.</param>
        /// <returns>The member attribute.</returns>
        public static T GetAttribute<T>(this ICustomAttributeProvider member) where T : class
        {
            return GetAttributes<T>(member).FirstOrDefault();
        }

        /// <summary>
        ///   Gets the attributes. Does not consider inherited attributes!
        /// </summary>
        /// <param name = "member">The member.</param>
        /// <returns>The member attributes.</returns>
        public static T[] GetAttributes<T>(this ICustomAttributeProvider member) where T : class
        {
            if (typeof(T) != typeof(object))
            {
                return (T[])member.GetCustomAttributes(typeof(T), false);
            }
            return (T[])member.GetCustomAttributes(false);
        }

        /// <summary>
        ///   Gets the type attribute.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <returns>The type attribute.</returns>
        public static T GetTypeAttribute<T>(this Type type) where T : class
        {
            var attribute = GetAttribute<T>(type);

            if (attribute == null)
            {
                foreach (var baseInterface in type.GetInterfaces())
                {
                    attribute = GetTypeAttribute<T>(baseInterface);
                    if (attribute != null)
                    {
                        break;
                    }
                }
            }

            return attribute;
        }

        /// <summary>
        ///   Gets the type attributes.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <returns>The type attributes.</returns>
        public static T[] GetTypeAttributes<T>(Type type) where T : class
        {
            var attributes = GetAttributes<T>(type);

            if (attributes.Length == 0)
            {
                foreach (var baseInterface in type.GetInterfaces())
                {
                    attributes = GetTypeAttributes<T>(baseInterface);
                    if (attributes.Length > 0)
                    {
                        break;
                    }
                }
            }

            return attributes;
        }

        /// <summary>
        ///   Gets the attribute.
        /// </summary>
        /// <param name = "member">The member.</param>
        /// <returns>The member attribute.</returns>
        public static bool HasAttribute<T>(this ICustomAttributeProvider member) where T : class
        {
            return GetAttributes<T>(member).FirstOrDefault() != null;
        }
    }
}

