#region + Using Directives

using System.Collections.ObjectModel;
using System.Dynamic;
using Autodesk.Revit.DB;

#endregion


// projname: ParameterVue
// itemname: HeaderMgr
// username: jeffs
// created:  8/18/2019 9:08:10 PM


namespace ParameterVue.FamilyManager.FamilyInfo
{
	public class ColumnData
	{
		private static ColumnSpec familyName;
		private static ColumnSpec selected;

		private const string SELECTED_COL_TITLE = "☑";
		private const string FAMILYNAME_COL_TITLE = "Family Name";

		public ObservableCollection<ColumnSpec> ColumnSpecs { get; private set; }

		public  ColumnData()
		{
			Initalize();

//			SetSelected();
//			SetFamilyName();

//			Parameter p = new Parameter();
//			p.Definition = new InternalDefinition();
//			p.Definition.Name = "Column Title";
//
//			ColumnSpec cs = new ColumnSpec( p, 0);
//			ColumnSpecs.Add(cs);
		}

		public void Initalize()
		{
			ColumnSpec.Initalize();

			SetSelected();
			SetFamilyName();

			ColumnSpec.Initalize();

			ColumnSpecs  = new ObservableCollection<ColumnSpec>();
		}

		public static ColumnSpec SelectedColSpec()
		{
			return selected;
		}

		public ColumnSpec Selected
		{
			get => selected;
			private set => selected = value;
		}


		public static ColumnSpec FamilyNameColSpec()
		{
			return familyName;
		}

		public  ColumnSpec FamilyName
		{
			get => familyName;
			private set => familyName = value;
		}

		private void SetSelected()
		{
			Selected = new ColumnSpec( TestData.DefineParameter("Selected", "Selected", "string", "YesNo", "none", "none"), 0);
		}

		private void SetFamilyName()
		{
			FamilyName = new ColumnSpec( TestData.DefineParameter("Family Name", "Family Name", "string", "Text", "none", "none"), 1);
		}
	}
}