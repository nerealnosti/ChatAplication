using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ChatAplicationFaseto.ValueConverters
{
    public abstract class BaseValueConverters<T> : MarkupExtension, IValueConverter
        where T: class,new()
    {
        public static T mConverter = null;

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter?? (mConverter = new T ());
        }

    }
}
