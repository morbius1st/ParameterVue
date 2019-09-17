using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using ParameterVue.FamilyManager;
using ParameterVue.FamilyManager.FamilyInfo;
using ParameterVue.FamilyManager.Support;
using ParameterVue.WpfSupport;
using ParameterVue.WpfSupport.CustomXAMLProperties;
using static ParameterVue.WpfSupport.MainWindowSupport;
using static ParameterVue.WpfSupport.ConfigurationSettings;


namespace ParameterVue
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public static string ColHeaderTbkStyleName { get; set; } = "ColHeaderTbk";
		public static string RowHeaderTbxStyleName { get; set; } = "RowHeaderTbx";
		public static string FieldTbxStyleName { get; set; } = "FieldTbx";

		private readonly int InitialPriorColumnWidth = 90;

		public static TextBlock tx;
		private int count = 0;

		

		public static ConfigurationSettings lbc { get;  set; } = new ConfigurationSettings();

		public FamilyMgr Fm { get; set; } = new FamilyMgr();

		public MainWindow()
		{
			InitializeComponent(); 

//			Fm.LoadFamilies();

			dataGrid2.ItemsSource = Fm.Fd;
			dataGrid3.ItemsSource = Fm.Fd;
			dataGrid4.ItemsSource = Fm.Cd.ColumnSpecs;

			tx = textBlock;
		}

		private int i = 100;

		public int testInt
		{
			get
			{
				Debug.WriteLine("get testInt|");
				
				return i;
			}
			set
			{ 
				i = value;
				OnPropertyChange();
			}
		}

		public bool EventWatcher
		{
			get
			{
				Debug.WriteLine("EventWatcher| get");
				return true;

			}
			set
			{
				Debug.WriteLine("EventWatcher| set| " + value);
			}
		}


		private void Button_Debug(object sender, RoutedEventArgs e)
		{

			testInt++;

			Debug.WriteLine("At button Debug");

			
		}


	#region DataGrid 2

		private void Button_Test21(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("At button Test 21");

			dataGrid2.Columns.Clear();

			LoadHeaderData();

			LoadDataToDg1s();

			Style s = (Style) FindResource("DataGridColumnHeaderStyle2");

			dataGrid2.DataContext = Dg1s;
			dataGrid2.AreRowDetailsFrozen = true;
			dataGrid2.HeadersVisibility = DataGridHeadersVisibility.All;
			dataGrid2.CanUserAddRows = false;
			dataGrid2.CanUserDeleteRows = true;


			Binding b = new Binding(col11);
			b.Mode = BindingMode.TwoWay;
			b.FallbackValue = false;

			DataGridCheckBoxColumn cbc = new DataGridCheckBoxColumn();
			cbc.IsThreeState = false;
			cbc.Header = Hi[0];
			cbc.Width = 30;
			cbc.Binding = b;
			dataGrid2.Columns.Add(cbc);

			b = new Binding(col12);
			b.Mode = BindingMode.TwoWay;
			b.FallbackValue = "none";

			DataGridTextColumn tbc = new DataGridTextColumn();
			tbc.Header = Hi[1];
			tbc.Width = 100;
			tbc.Binding = b;
			tbc.HeaderStyle = s;
			dataGrid2.Columns.Add(tbc);

			b = new Binding(col13);
			b.Mode = BindingMode.TwoWay;
			b.FallbackValue = "none";

			tbc = new DataGridTextColumn();
			tbc.Header = Hi[2];
			tbc.Width = 100;
			tbc.Binding = b;
			tbc.HeaderStyle = s;
			dataGrid2.Columns.Add(tbc);

			b = new Binding(col14);
			b.Mode = BindingMode.TwoWay;
			b.FallbackValue = "none";

			tbc = new DataGridTextColumn();
			tbc.Header = Hi[3];
			tbc.Width = 100;
			tbc.Binding = b;
			tbc.HeaderStyle = s;
			dataGrid2.Columns.Add(tbc);

			b = new Binding(col15);
			b.Mode = BindingMode.TwoWay;
			b.FallbackValue = "none";

			tbc = new DataGridTextColumn();
			tbc.Header = Hi[4];
			tbc.Width = 100;
			tbc.Binding = b;
			tbc.HeaderStyle = s;
			dataGrid2.Columns.Add(tbc);



			dataGrid2.ItemsSource = Dg1s;
		}

		private void Button_Test22(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("At button Test 22");

			dataGrid2.Columns.Clear();

			LoadHeaderData();

			LoadDataToDg1s();

			dataGrid2.DataContext = Dg1s;
			dataGrid2.AreRowDetailsFrozen = false;
			dataGrid2.HeadersVisibility = DataGridHeadersVisibility.All;
			dataGrid2.CanUserAddRows = false;
			dataGrid2.CanUserDeleteRows = true;

			ConfigureColumn(Hi[0], ConfigureBinding(col11, "false"));
			ConfigureColumn(Hi[1], ConfigureBinding(col12, "none"));
			ConfigureColumn(Hi[2], ConfigureBinding(col13, "none"));
			ConfigureColumn(Hi[3], ConfigureBinding(col14, "none"));
			ConfigureColumn(Hi[4], ConfigureBinding(col15, "none"));

			dataGrid2.ItemsSource = Dg1s;

		}

		private void Button_Test23(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("At button Test 23");

			dataGrid2.Columns.Clear();

			// load the parameter information into
			// Fm & Cd
			Binding b;

			ConfigureDataGrid(dataGrid2, Fm);

//			b = CreateBinding2("Selected", false, BindingMode.TwoWay);
//			AddColumn(this, dataGrid2, Fm.Cd.Selected, b);
//
//			b = CreateBinding2("FamilyName", "none", BindingMode.OneWay);
//			AddColumn(this, dataGrid2, Fm.Cd.FamilyName, b);

			

			int position = 0;
			string path;

			foreach (ColumnSpec cs in Fm.Cd.ColumnSpecs)
			{
				path = String.Format("ParameterValues[{0}].ParamValue",position);

				b = CreateBinding2(path, GetFallBack(cs), BindingMode.TwoWay);

				AddColumn(this, dataGrid2, cs, b);

				position++;
			}

		}

		private dynamic GetFallBack(ColumnSpec cs)
		{
			if (cs.ColumnType == ColumnType.CHECKBOX)
			{
				return false;
			}

			return "none";
		}

	#endregion

		public Binding ConfigureBinding(string bindTo, string fallBack)
		{
			Binding b = new Binding(bindTo);
			b.Mode = BindingMode.TwoWay;
			b.FallbackValue = fallBack;

			return b;
		}

		public void ConfigureColumn(HeaderInfo h, Binding b)
		{
			DataGridColumn col = null;
			Style s = null;

			switch (h.ColumnStyle)
			{
			case 0:
				{
					s = (Style) FindResource("DataGridColumnHeaderStyle2");

					col =  new DataGridCheckBoxColumn();
					((DataGridCheckBoxColumn) col).Binding = b;
					break;
				}
			case 1:
				{
					s = (Style) FindResource("DataGridColumnHeaderStyle2");

					col = new DataGridTextColumn();
					
					((DataGridTextColumn) col).Binding = b;
					break;
				}
			case 2:
				{
					s = (Style) FindResource("DataGridColumnHeaderStyle2");

					col = new DataGridComboBoxColumn();
					((DataGridComboBoxColumn) col).ItemsSource = h.options;
					((DataGridComboBoxColumn) col).SelectedItemBinding = b;
					break;
				}
			}

			col.Width = h.ColumnWidth;
			col.Header = h;
			col.HeaderStyle = s;

			if (h.Column == 3) { col.IsReadOnly = true; }

			dataGrid2.Columns.Add(col);

		}

		public ObservableCollection<Dg1> Dg1s = new ObservableCollection<Dg1>();

		private static readonly string col11 = "sel";
		private static readonly string col12 = "familyname_x";
		private static readonly string col13 = "parameter1_x";
		private static readonly string col14 = "parameter2_x";
		private static readonly string col15 = "parameter3_x";

		private void LoadDataToDg1s()
		{
			for (int i = 0; i < 4; i++)
			{
				Dg1 dg1 = new Dg1();

				dg1.sel = (i % 2) == 0;
				dg1.familyname_x = col12 + "_" + i;
				dg1.parameter1_x = col13 + "_" + i;
				dg1.parameter2_x = col14 + "_" + i;
				dg1.parameter3_x = col15 + "_" + i;

				Dg1s.Add(dg1);
			}
		}

		public ObservableCollection<HeaderInfo> Hi { get; set; } = new ObservableCollection<HeaderInfo>();
		private void LoadHeaderData()
		{
			HeaderInfo h;

			for (int i = 0; i <= 4; i++)
			{
				if ((i % 2) == 0)
				{
					h = new HeaderInfo("Hdr_A_" + i, Header2Font, 100);
				}
				else
				{
					h = new HeaderInfo("Hdr_B_" + i, Header3Font, 60);
				}

				h.ColumnStyle = 1;
				h.Column = i;

				Hi.Add(h);
			}

			Hi[0].ColumnStyle = 0;
			

			h = Hi[Hi.Count - 1];
			h.ColumnStyle = 2;

			h.options = new ObservableCollection<string>();

			h.options.Add(col15 + "_" + 0);
			h.options.Add(col15 + "_" + 1);
			h.options.Add(col15 + "_" + 2);
			h.options.Add(col15 + "_" + 3);
			h.options.Add(col15 + "_" + 4);
			h.options.Add(col15 + "_" + 5);

		}

	#region DataGrid 1

		private static readonly string col1 = "sel";
		private static readonly string col2 = "familyname";
		private static readonly string col3 = "parameter1";
		private static readonly string col4 = "parameter2";

		private void Button_Test11(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("At button Test 11");

			DataTable table1 = new DataTable("table1");

			DataColumn dc1;
			DataRow dr1;

			dc1 = new DataColumn(col1);
			dc1.Caption = col1;
			dc1.DataType = typeof(bool);
			dc1.ReadOnly = false;
			dc1.Unique = false;

			table1.Columns.Add(dc1);

			dc1 = new DataColumn(col2);
			dc1.Caption = col2;
			dc1.DataType = typeof(string);
			dc1.ReadOnly = false;
			dc1.Unique = false;

			table1.Columns.Add(dc1);

			dc1 = new DataColumn(col3);
			dc1.Caption = col3;
			dc1.DataType = typeof(string);
			dc1.ReadOnly = false;
			dc1.Unique = false;

			table1.Columns.Add(dc1);

			dc1 = new DataColumn(col4);
			dc1.Caption = col4;
			dc1.DataType = typeof(string);
			dc1.ReadOnly = false;
			dc1.Unique = false;

			table1.Columns.Add(dc1);

			DataColumn[] keyColumn = new DataColumn[1];
			keyColumn[0] = table1.Columns[col2];
			table1.PrimaryKey = keyColumn;

			for (int i = 0; i <= 3; i++)
			{
				dr1 = table1.NewRow();

				dr1[col1] = (i % 2) == 0;
				dr1[col2] = col2 + "_" + i;
				dr1[col3] = col3 + "_" + i;
				dr1[col4] = col4 + "_" + i;

				table1.Rows.Add(dr1);

			}

			dataGrid1.DataContext = table1;

		}

		public class Dg1
		{
			public bool sel { get; set; }
			public string familyname_x { get; set; }
			public string parameter1_x { get; set; }
			public string parameter2_x { get; set; }
			public string parameter3_x { get; set; }
		}


//		public ObservableCollection<Font> fts { get; set; } = new ObservableCollection<Font>();


		private void Button_Test12(object sender, RoutedEventArgs e)
		{
			FontStretch s = FontStretches.Normal;
			dataGrid1.DataContext = null;

//			fts.Add(new Font("Arial", 12.0, FontStyles.Normal, FontWeights.Black));
//			fts.Add(new Font("Cooper Black", 10.0, FontStyles.Italic, FontWeights.Normal));

			Debug.WriteLine("At button Test 12");

			HeaderInfo h;

//			for (int i = 0; i < 4; i++)
//			{
//				if ((i % 2) == 0)
//				{
//					h = new HeaderInfo("col_A_" + i, Header2Font, 100);
//				}
//				else
//				{
//					h = new HeaderInfo("col_B_" + i, Header3Font, 60);
//				}
//
//				Hi.Add(h);
//			}

			LoadHeaderData();

			LoadDataToDg1s();

			dataGrid1.ItemsSource = Dg1s;

//			int k = 0;
//
//			foreach (DataGridColumn col in dataGrid1.Columns)
//			{
//
//				if ((k % 2)==0)
//				{
//					col.Header = new HeaderInfo("col_A_" + k++, Header2Font, 70);
//				}
//				else
//				{
//					col.Header = new HeaderInfo("col_B_" + k++, Header3Font, 50);
//				}
//			}

		}

		private void Button_Test13(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("At button Test 13");
		}

	#endregion

	#region Listbox1

		private void Button_Test1(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("At button Test 1");

			VirtualizingStackPanel vp = GetVirtualizingStackPanel(listBox);

			removeOldHeaderElements();
			removeOldFieldElements();

			Fm.LoadFamilies();

			listBox.ItemsSource = Fm.Fd;
			listBox.UpdateLayout();

			AddColumns();

			listBox.UpdateLayout();

		}

		private void Button_Test2(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("At button Test 2");

			Fm.Fd[0].ParameterValues[0].ParamValue = "test " + count++;
		}

		private void btnDebug_Click(object sender, RoutedEventArgs e)
		{
			Fm.Fd[0].ParameterValues[0].Invalid = !Fm.Fd[0].ParameterValues[0].Invalid;


			Debug.WriteLine("At debug Click");
		}

		// based on previously loaded data, create all of
		// the columns for the grid
		private void AddColumns()
		{
			int col = 0;
			int priorColWidth = InitialPriorColumnWidth;
			// add the first two standard columns
			foreach (ColumnSpec cs in Fm.Cd.ColumnSpecs)
			{
				AddColumnAndData(cs, col++, priorColWidth);

//				priorColWidth = cs.ColumnWidth;
			}
		}

		private void removeOldHeaderElements()
		{
			Grid g = (Grid) FindNamedVisualChild<Grid>(listBox, "header");

			RemoveOldElements(g, 2);
		}

		private void removeOldFieldElements()
		{
			VirtualizingStackPanel vp = GetVirtualizingStackPanel(listBox);

			foreach (object vpChild in vp.Children)
			{
				if (!(vpChild is ListBoxItem)) continue;



				Grid g = FindNamedVisualChild<Grid>((ListBoxItem) vpChild,
					"data");

				RemoveOldElements(g, 2);

			}
		}

		private void RemoveOldElements(Grid g, int start)
		{
			if (g.Children.Count > start)
			{
				g.Children.RemoveRange(start, g.ColumnDefinitions.Count - start);
			}

			if (g.ColumnDefinitions.Count > start)
			{
				g.ColumnDefinitions.RemoveRange(start, g.ColumnDefinitions.Count - start);
			}
		}

		public void AddColumnAndData(ColumnSpec cs, int col, int priorColWidth)
		{
			Grid hg = (Grid) FindNamedVisualChild<Grid>(listBox, "header");

			AddHeader(this, hg, cs, priorColWidth);

			int row = 0;

			string basePath = string.Format("ParameterValues[{0:D}]", col);
			string tbxName = string.Format("ParameterValues{0:D}", col);


			VirtualizingStackPanel vp = GetVirtualizingStackPanel(listBox);

			foreach (object vpChild in vp.Children)
			{
				if (!(vpChild is ListBoxItem)) continue;

				Grid g = FindNamedVisualChild<Grid>((ListBoxItem) vpChild,
					"data");

				AddField(this, g, basePath, tbxName, priorColWidth);
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

	#endregion

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
			AddColumnAndData(Fm.Cd.ColumnSpecs[0], 0, 100);
			AddColumnAndData(Fm.Cd.ColumnSpecs[1], 1, 100);
			AddColumnAndData(Fm.Cd.ColumnSpecs[2], 2, 100);
//			AddColumnAndData(Fm.Cd.ColumnSpecs[3], 3, 100);

        }


		private void DataGrid4_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyName.IndexOf("font", StringComparison.OrdinalIgnoreCase) != -1)
			{
				e.Cancel = true;
			}
		}

		private void DataGrid3_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyName.IndexOf("value", StringComparison.OrdinalIgnoreCase) != -1)
			{
				e.Cancel = true;
			}
		}

	}

	public class HeaderInfo
	{
		public HeaderInfo(string title, Font font, int columnWidth)
		{
			this.title = title;
			this.font = font;
			this.ColumnWidth = columnWidth;
			IsChecked = false;
			ColumnStyle = 1;
		}

		public string title { get; set; }
		public int Column { get; set; }
		public bool IsChecked { get; set; }
		public Font font { get; set; }
		public int ColumnWidth { get; set; }

		// 0 = checkbox
		// 1 = text
		// 2 = dropdown
		public int ColumnStyle { get; set; }

		public ObservableCollection<string> options = null;
	}
}


// not this way

//		private static readonly string col31 = "selz";
//		private static readonly string col32 = "familyname_z";
//		private static readonly string col33 = "parameter1_z";
//
//		public class Dg2
//		{
//			public string parameter1_z { get; set; }
//
//		}
//
//		public class Dg3
//		{
//			public bool selz { get; set; }
//			public string familyname_z { get; set; }
//			public ObservableCollection<Dg2> Dg2s = new ObservableCollection<Dg2>();
//
//		}
//
//		public ObservableCollection<Dg3> dg3 = new ObservableCollection<Dg3>();
//
//
// not this way
//		private void Button_Test13(object sender, RoutedEventArgs e)
//		{
//			Debug.WriteLine("At button Test 13");
//
//			for (int j = 0; j <= 4; j++)
//			{
//				Dg3 d3 = new Dg3();
//
//				ObservableCollection<Dg2> dg2s = new ObservableCollection<Dg2>();
//
//				for (int i = 0; i <= 3; i++)
//				{
//					Dg2 d = new Dg2();
//
//					d.parameter1_z = col33 + "_" + j + "_" + i;
//
//					dg2s.Add(d);
//				}
//
//				d3.selz = (j % 2) == 0;
//				d3.familyname_z = col32 + "_" + j;
//
//				dg3.Add(d3);
//			}
//
//			dataGrid1.DataContext = dg3;
//		}

