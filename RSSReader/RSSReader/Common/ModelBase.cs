using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.Common
{
    public class ModelBase : NotifyPropertyChanged
    {
        public void SetProperty<IProperty>(ref IProperty orgin, IProperty newValue,
            [CallerMemberName]string propName = null)
        {
            if (object.Equals(orgin, newValue)) return;
            orgin = newValue;
            if (string.IsNullOrEmpty(propName)) return;
            base.OnPropertyChanged(propName);
        }
    }
}
