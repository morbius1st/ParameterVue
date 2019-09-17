using System.Collections.ObjectModel;
using Autodesk.Revit.DB;
using ParameterVue.FamilyManager.FamilyInfo;

namespace ParameterVue.FamilyManager.Support
{
	class FamilyMgrSupport
	{
		public static void LoadDesignData(ObservableCollection<FamilyData> Fd, ColumnData Cd)
		{
			ObservableCollection<ParameterValue> p;

			Parameter pa;

			FamilyData fd;

			fd = new FamilyData("Family 1");
			fd.Selected = false;
			Fd.Add(fd);
			
			p = Fd[Fd.Count - 1].ParameterValues;

			Cd.ColumnSpecs = new ObservableCollection<ColumnSpec>();

			pa = TestData.DefineParameter(new [] {"3/32\"" , "Text Size" , "Double "  , "105"    , "UT_SheetLength" , "DUT_FRACTIONAL_INCHES"});
			Cd.ColumnSpecs.Add(new ColumnSpec(0, pa));
			p.Add(new ParameterValue(pa));
			
			pa = TestData.DefineParameter(new [] {"Arial1" , "Text Font" , "string "  , "Text "  , "UT_Number"      , "(no unit type)"});
			Cd.ColumnSpecs.Add(new ColumnSpec(1, pa));
			p.Add(new ParameterValue(pa));

			
			pa = TestData.DefineParameter(new [] {"1/2\" " , "Tab Size"  , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES"});
			Cd.ColumnSpecs.Add(new ColumnSpec(2, pa));
			p.Add(new ParameterValue(pa));


			fd = new FamilyData("Family 2");
			fd.Selected = true;
			Fd.Add(fd);

			p = Fd[Fd.Count - 1].ParameterValues;
			p.Add(new ParameterValue(
				TestData.DefineParameter(new [] {"4/32\"" , "Text Size" , "Double "  , "105"    , "UT_SheetLength" , "DUT_FRACTIONAL_INCHES"})));
			p.Add(new ParameterValue(
				TestData.DefineParameter(new [] {"Arial2" , "Text Font" , "string "  , "Text "  , "UT_Number"      , "(no unit type)" })));
			p.Add(new ParameterValue(
				TestData.DefineParameter(new [] {"1/2\" " , "Tab Size"  , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES"})));

			fd = new FamilyData("Family 3");
			fd.Selected = false;
			Fd.Add(fd);

			p = Fd[Fd.Count - 1].ParameterValues;
			p.Add(new ParameterValue(
				TestData.DefineParameter(new [] {"5/32\"" , "Text Size" , "Double "  , "105"    , "UT_SheetLength" , "DUT_FRACTIONAL_INCHES"})));
			p.Add(new ParameterValue(
				TestData.DefineParameter(new [] {"Arial3" , "Text Font" , "string "  , "Text "  , "UT_Number"      , "(no unit type)" })));
			p.Add(new ParameterValue(
				TestData.DefineParameter(new [] {"1/2\" " , "Tab Size"  , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES"})));

		}
	}
}