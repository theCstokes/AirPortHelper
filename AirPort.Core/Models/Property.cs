using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AirPort.Core.Models
{
    [AttributeUsage(AttributeTargets.Field)]
    class Property : Attribute
    {
        private string propertyName;
        private MethodInfo method;
        private string[] errors;
        public Property(string propertyName, Type type, string methodName, params string[] errors)
        {
            this.propertyName = propertyName;
            method = type.GetMethod(methodName);
            this.errors = errors;
        }

        public string Name
        {
            get
            {
                return Name;
            }
        }

        public string[] Errors
        {
            get
            {
                return errors;
            }
        }

        public bool Invoke(string item)
        {
            return (bool)method.Invoke(null, new object[] { item });
        }
    }
}
