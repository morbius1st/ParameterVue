#region + Using Directives

using System.ComponentModel;
using System.Windows.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using Brush = System.Windows.Media.Brush;
using FontFamily = System.Windows.Media.FontFamily;
using FontStyle = System.Windows.FontStyle;

#endregion


// projname: ParameterVue.WpfSupport
// itemname: ListBoxConfiguration
// username: jeffs
// created:  8/24/2019 12:57:41 PM


namespace ParameterVue.WpfSupport
{
	// information about the design / settings
	// for a listbox
	public class ConfigurationSettings : INotifyPropertyChanged
	{
		public static readonly Font DefaultFont = new Font("Arial");

		public static Font HeaderFont { get; set; } = new Font("Arial");
		public static Font SymbolFont { get; set; } = new Font("ArialUni");
		public static Font RowHeaderFont { get; set; } = new Font("Arial");
		public static Font FieldFont { get; set; } = new Font("Arial");

		public static Font Header2Font { get; set; } = new Font("Bauhaus 93", 16.0);
		public static Font Header3Font { get; set; } = new Font("Cooper Black", 20.0, new SolidColorBrush(Colors.Blue));


		static ConfigurationSettings()
		{
			HeaderFont.Foreground = new SolidColorBrush(Colors.BlueViolet);
			SymbolFont.Foreground = new SolidColorBrush(Colors.Red);
			RowHeaderFont.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
			FieldFont.Foreground = new SolidColorBrush(Colors.MediumBlue);
		}

		public static Font GetDefaultHeaderFont() { return HeaderFont; }
		public static Font GetDefaultFieldFont() { return FieldFont; }

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}
	}

	public class Font : INotifyPropertyChanged
	{
		private const double DEFAULT_FONT_SIZE = 11.0f;

		private FontFamily fontFamily;		
		private double fontSize;		
		private FontStyle fontStyle;
		private FontWeight fontWeight;
		private FontStretch fontStretch;
		private Brush foreground;

		public Font() { }

		public Font(string fontFamily, double fontSize,
			Brush foreground) : this(fontFamily, fontSize, FontStyles.Normal,
			FontWeights.Normal, FontStretches.Normal, foreground) { }

		public Font(string fontFamily = null, double fontSize = DEFAULT_FONT_SIZE,
			FontStyle fontStyle = default(FontStyle),
			FontWeight fontWeight = default(FontWeight),
			FontStretch fontStretch = default(FontStretch),
			Brush foreground = null )
		{
			FontFamily = new FontFamily(fontFamily ?? "Arial");
			FontSize = fontSize;
			FontStyle = fontStyle; //?? default(FontStyle);
			FontWeight = fontWeight; //?? default(FontWeight);
			FontStretch = fontStretch; //?? default(FontStretch);
			Foreground = foreground ?? new SolidColorBrush(Colors.Black);
		}

		public FontFamily FontFamily
		{
			get => fontFamily;
			set
			{
				fontFamily = value;
				OnPropertyChange();
			}
		}

		public double FontSize
		{
			get => fontSize;
			set
			{
				fontSize = value;
				OnPropertyChange();
			}
		}

		public FontStyle FontStyle
		{
			get => fontStyle;
			set
			{
				fontStyle = value;
				OnPropertyChange();
			}
		}

		public FontWeight FontWeight
		{
			get => fontWeight;
			set
			{
				fontWeight = value;
				OnPropertyChange();
			}
		}

		public FontStretch FontStretch
		{
			get => fontStretch;
			set
			{
				fontStretch = value;
				OnPropertyChange();
			}
		}

		public Brush Foreground
		{
			get => foreground;
			set
			{
				foreground = value; 
				OnPropertyChange();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this,   new PropertyChangedEventArgs(memberName));
		}
	}


}