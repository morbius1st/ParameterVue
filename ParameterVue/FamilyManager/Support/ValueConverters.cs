using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

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


	public class RowToIndexConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			DataGridRow row = value as DataGridRow;
			if (row != null)
				return row.GetIndex();
			else
				return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class CellColToIndexConverter : IMultiValueConverter
	{
		public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{ 
			if (!(value[1] is DataGridCell))
			{
				return "";
			}

			DataGridCell cell = (DataGridCell) value[1];

			return cell.Column.DisplayIndex.ToString();
		}

		public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}

	public class CellRowToIndexConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{

			DataGridRow r = DataGridRow.GetRowContainingElement(value as DataGridCell);

			if (r == null)
				return -1;

			return r.GetIndex();
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int v;

			if (int.TryParse((string) value, out v))
				return v;

			return -1;
		}

	}


	public class TestConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Debug.WriteLine("at test convert");

			Type t = value.GetType();
			
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}

}
