using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ParameterVue.FamilyManager.Support
{

	[ValueConversion(typeof(string), typeof(string))]
	public class  YesNoToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.ToString().ToLower().Equals("yes")) return true;

			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool)
			{
				if ((bool) value == true)
				{
					return "Yes";
				}
			}

			return "No";
		}
	}

}
