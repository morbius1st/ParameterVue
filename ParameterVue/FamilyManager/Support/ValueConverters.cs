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
//		static RowToIndexConverter converter;

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

		//		public override object ProvideValue(IServiceProvider serviceProvider)
		//		{
		//			if (converter == null) converter = new RowToIndexConverter();
		//			return converter;
		//		}

		//		public RowToIndexConverter() { }
	}

	public class CellColToIndexConverter : IValueConverter
	{
//		static CellColToIndexConverter converter;

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			DataGridCell cell = value as DataGridCell;

			if (cell == null)
				return -1;
//
////			DataGridCellInfo info = new DataGridCellInfo(cell);
//
//
//			DataGridCellsPanel p = (DataGridCellsPanel) VisualTreeHelper.GetParent(cell);
//
//			if (p == null)
//				return -1;
//
//			int i = p.Children.IndexOf(cell);

			Debug.WriteLine("converting| " + cell.Column.DisplayIndex);

			return cell.Column.DisplayIndex;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class CellRowToIndexConverter : IValueConverter
	{
//		static CellRowToIndexConverter converter;

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{

			DataGridRow r = DataGridRow.GetRowContainingElement(value as DataGridCell);

			if (r == null)
				return -1;

			return r.GetIndex();
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}

	public class TestConverter : IValueConverter
	{
//		static CellRowToIndexConverter converter;

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{

			Debug.WriteLine("converting| Test");

			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}

}
