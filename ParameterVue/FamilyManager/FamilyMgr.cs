#region + Using Directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using Autodesk.Revit.DB;
using ParameterVue.FamilyManager.FamilyInfo;
using ParameterValue = ParameterVue.FamilyManager.FamilyInfo.ParameterValue;

using ParameterVue.FamilyManager.Support;

#endregion


// projname: ParameterVue.ListBoxManager
// itemname: ListBoxMgr
// username: jeffs
// created:  8/19/2019 9:55:52 PM


namespace ParameterVue.FamilyManager
{
	public class FamilyMgr
	{
		private readonly string N = System.Environment.NewLine;

		public ObservableCollection<FamilyData> Fd { get; set; } = new ObservableCollection<FamilyData>();
		public ColumnData Cd { get; set; } = new ColumnData();

		public FamilyMgr()
		{
		#if DEBUG
			FamilyMgrSupport.LoadDesignData(Fd, Cd);
		#endif
		}

		// overall datagrid properties
		public bool CanUserAddRows { get; set; } = true;
		public bool CanUserDeleteRows { get; set; } = true;
		public bool CanUserAddColumns { get; set; } = false;
		public bool CanUserDeleteColumns { get; set; } = false;



	#if DEBUG

		// load a family's data from the test data
		public void LoadFamilies()
		{
			Cd = new ColumnData();
			Fd = new ObservableCollection<FamilyData>();

			FamilyData fd;

			// get the first record
			KeyValuePair<string, List<Parameter>> k = TestData.TestFamilyData.First();

			int col = 0;

			// setup the column specifications
			foreach (Parameter p in k.Value)
			{
				ColumnSpec cs = CreateColumnSpec(p, col++);

				Cd.ColumnSpecs.Add(cs);
			}

			col = 0;

			// set up each row with the neme & set selected to false plus
			// the value for each parameter
			foreach (KeyValuePair<string, List<Parameter>> kvp in TestData.TestFamilyData)
			{
				AddRow(false, kvp.Key, kvp.Value);
			}

			UpdateTitles();
		}

		private void AddRow(bool selected, string familyName, List<Parameter> parameters)
		{
			int col = 0;
			FamilyData fd;

			fd = new FamilyData(familyName);
			fd.Selected = false;

			foreach (Parameter p in parameters)
			{
				ParameterValue pv = new ParameterValue(p);

				if (Cd.ColumnSpecs[col].ColumnType == ColumnType.CHECKBOX)
				{
					Cd.ColumnSpecs[col].WidestCell = 1;
				}
				else
				{
					Cd.ColumnSpecs[col].WidestCell = pv.ParamValue.Length;
				}

				fd.ParameterValues.Add(new ParameterValue(p));

				col++;
			}

			Fd.Add(fd);
		}


		private void UpdateTitles()
		{
			foreach (ColumnSpec cs in Cd.ColumnSpecs)
			{
				cs.DivideTitle();
			}
		}

		private string SplitTitle(string title, int actMaxWidth, out int LinesOfText)
		{
			int colWidth = actMaxWidth > ColumnSpec.MaxAllowedValueWidth ? 
				ColumnSpec.MaxAllowedValueWidth : 
				actMaxWidth < ColumnSpec.MinAllowedValueWidth ? 
					ColumnSpec.MinAllowedValueWidth : actMaxWidth;

			string pattern = @"(\b.{1," + $"{colWidth:D}" + @"})(?:\s+|$)";

			MatchCollection matches =
				Regex.Matches(title, pattern);

			LinesOfText = matches.Count;

			if (matches.Count == 1)
			{
				return matches[0].Value;
			}

			Match[] titles = new Match[LinesOfText];

			matches.CopyTo(titles, 0);

			return JoinMatchesWith(titles, N);


		}

		private string JoinMatchesWith(Match[] matches, string with)
		{
			if (matches.Length < 2) return matches[0].Value;

			StringBuilder sb = new StringBuilder();

			for (var i = 0; i < matches.Length; i++)
			{
				sb.Append(matches[i].Value);

				if (i < matches.Length - 1)
				{
					sb.Append(with);
				}
			}

			return sb.ToString();
		}

		private ColumnSpec CreateColumnSpec(Parameter p, int colIdx)
		{
			ColumnSpec cs = new ColumnSpec(colIdx, p);

			cs.Choices = null;

			return cs;
		}

	#endif

	}
}
