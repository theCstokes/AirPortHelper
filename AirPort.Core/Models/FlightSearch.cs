using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq.Expressions;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross;
using System.Collections;
using System.Reflection;
using Cirrious.CrossCore;

namespace AirPort.Core.Models
{
    public class FlightSearch : MvxNotifyPropertyChanged, INotifyDataErrorInfo
    {
        [Property("Carrier", typeof(string), "IsNullOrWhiteSpace", "At least one feild must be populated")]
        private string carrier;
        [Property("Carrier", typeof(string), "IsNullOrWhiteSpace", "At least one feild must be populated")]
        private string origin;
        [Property("Carrier", typeof(string), "IsNullOrWhiteSpace", "At least one feild must be populated")]
        private string dest;
        [Property("Carrier", typeof(string), "IsNullOrWhiteSpace", "Time cannot be empty")]
        private string time;
        public string Carrier
        {
            get
            {             
                return carrier;
            }
            set
            {
                carrier = value;
                RaisePropertyChanged(() => Carrier);
                RaisePropertyChanged(() => Search);
            }
        }

        public string Origin
        {
            get
            {
                return origin;
            }
            set
            {
                origin = value;
                RaisePropertyChanged(() => Origin);
                RaisePropertyChanged(() => Search);
            }
        }
  
        public string Dest
        {
            get
            {
                return dest;
            }
            set
            {
                dest = value;
                RaisePropertyChanged(() => Dest);
                RaisePropertyChanged(() => Search);
            }
        }

        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                RaisePropertyChanged(() => Time);
                RaisePropertyChanged(() => Search);
            }
        }

        public string Search
        {
            get
            {
                return string.Format("From: {0} To: {1} On: {2}", Origin, Dest, Carrier);
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors
        {
            get;
            private set;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            foreach(FieldInfo field in typeof(FlightSearch).GetFields())
            {
                foreach(Attribute attr in field.GetCustomAttributes(typeof(Property), false))
                {
                    Property p = (Property)attr;
                    if(propertyName == p.Name && p.Invoke((string) field.GetValue(this)))
                    {
                        HasErrors = true;
                        return p.Errors;
                    } else
                    {
                        HasErrors = false;
                    }
                }
            }
            return default(IEnumerable);
        }
    }
}
