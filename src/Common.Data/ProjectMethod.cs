﻿using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Common.Data
{
    /// <summary>
    /// Local DTO for <see cref="MethodInfo"/>
    /// </summary>
    public class ProjectMethod
    {
        /// <summary>
        /// Actual Method-Information
        /// </summary>
        public MethodInfo Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Actual Method-Information</param>
        public ProjectMethod(MethodInfo value)
        {
            Value = value;
        }

        public override string ToString()
        {
            var visibility = string.Empty;
            var body = string.Empty;

            if (Value.IsPublic)
                visibility = "+";
            else if (Value.IsPrivate)
                visibility = "-";
            else if (Value.IsFamily)
                visibility = "#";

            for (int i = 0; i < Value.GetParameters().Length; i++)
            {
                body += $"{Value.GetParameters()[i].ParameterType} {Value.GetParameters()[i].Name} ";
                if (i != Value.GetParameters().Length - 1)
                {
                    body += ", ";
                }
            }

            return $"{ visibility } { Value.Name }({body}) : {Value.ReturnType}";
        }
    }
}
