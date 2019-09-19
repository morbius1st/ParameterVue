// Solution:     WpfApp1-ListControlTest
// Project:       ParameterVue
// File:             CustomProperties.cs
// Created:      -- ()

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace ParameterVue.WpfSupport.CustomXAMLProperties 
{

	public class CustomProperties
	{
		public static readonly DependencyProperty GenericBoolOneProperty = DependencyProperty.RegisterAttached(
			"GenericBoolOne", typeof(bool), typeof(CustomProperties),
			new PropertyMetadata(false));
		
		public static readonly DependencyProperty GenericBoolTwoProperty = DependencyProperty.RegisterAttached(
			"GenericBoolTwo", typeof(bool), typeof(CustomProperties),
			new PropertyMetadata(false));
		
		public static readonly DependencyProperty GenericIntOneProperty = DependencyProperty.RegisterAttached(
			"GenericIntOne", typeof(int), typeof(CustomProperties),
			new PropertyMetadata(0));
		
		public static readonly DependencyProperty GenericObjectOneProperty = DependencyProperty.RegisterAttached(
			"GenericObjectOne", typeof(object), typeof(CustomProperties),
			new PropertyMetadata(0));

		public static readonly DependencyProperty GenericFontProperty = DependencyProperty.RegisterAttached(
			"GenericFont", typeof(Font), typeof(CustomProperties),
			new PropertyMetadata(new Font("Arial")));

		public static readonly DependencyProperty GenericFontFamilyProperty = DependencyProperty.RegisterAttached(
			"GenericFontFamily", typeof(FontFamily), typeof(CustomProperties),
			new PropertyMetadata(new FontFamily("Arial")));

		public static readonly DependencyProperty ErrorFlagProperty = DependencyProperty.RegisterAttached(
			"ErrorFlag", typeof(bool), typeof(CustomProperties),
			new PropertyMetadata(false));


	#region GenericBoolOne

		public static void SetGenericBoolOne(UIElement e, bool value)
		{
			e.SetValue(GenericBoolOneProperty, value);
		}

		public static bool GetGenericBoolOne(UIElement e)
		{
			return (bool) e.GetValue(GenericBoolOneProperty);
		}

	#endregion
		
	#region GenericBoolTwo

		public static void SetGenericBoolTwo(UIElement e, bool value)
		{
			Debug.WriteLine("SetGenericBoolTwo| " + value);
			e.SetValue(GenericBoolTwoProperty, value);
		}

		public static bool GetGenericBoolTwo(UIElement e)
		{
			Debug.WriteLine("GetGenericBoolTwo| ");
			return (bool) e.GetValue(GenericBoolTwoProperty);
		}

	#endregion
				
	#region GenericIntOne

		public static void SetGenericIntOne(UIElement e, int value)
		{
			Debug.WriteLine("SetGenericIntOne| " + value);
			e.SetValue(GenericIntOneProperty, value);
		}

		public static int GetGenericIntOne(UIElement e)
		{
			Debug.WriteLine("GetGenericIntOne| ");
			return (int) e.GetValue(GenericIntOneProperty);
		}

	#endregion
				
	#region GenericObjectOne

		public static void SetGenericObjectOne(UIElement e, object value)
		{
			Debug.WriteLine("SetGenericObjectOne| " + value);
			e.SetValue(GenericObjectOneProperty, value);
		}

		public static object GetGenericObjectOne(UIElement e)
		{
			Debug.WriteLine("GetGenericObjectOne| ");
			return (object) e.GetValue(GenericObjectOneProperty);
		}

	#endregion

	#region GenericFont

		public static void SetGenericFont(UIElement e, Font value)
		{
			e.SetValue(GenericFontProperty, value);
		}

		public static Font GetGenericFont(UIElement e)
		{
			return (Font) e.GetValue(GenericFontProperty);
		}

	#endregion

	#region GenericFont

		public static void SetGenericFontFamily(UIElement e, FontFamily value)
		{
			e.SetValue(GenericFontFamilyProperty, value);
		}

		public static FontFamily GetGenericFontFamily(UIElement e)
		{
			return (FontFamily) e.GetValue(GenericFontFamilyProperty);
		}

	#endregion

	#region ErrorFlag

		public static void SetErrorFlag(UIElement e, bool value)
		{
			e.SetValue(ErrorFlagProperty, value);
		}

		public static bool GetErrorFlag(UIElement e)
		{
			return (bool) e.GetValue(ErrorFlagProperty);
		}

	#endregion


	}
}