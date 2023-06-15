using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MvcMovie.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var displayAttribute = field?.GetCustomAttribute<DisplayAttribute>();
            return displayAttribute != null ? displayAttribute.Name : value.ToString();
        }
    }
}
