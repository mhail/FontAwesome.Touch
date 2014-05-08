using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;
using System.Linq;

namespace FontAwesome.Touch
{
	public static class IconsExtensions
	{
		private static readonly Type _iconType = typeof(Icon);
		public static string AsString(this Icon icon)
		{
			return new string ((char)icon, 1);
		}

		public static string[] Categories(this Icon icon) 
		{
			return _iconType.GetField (Enum.GetName (_iconType, icon))
					.GetCustomAttributes (typeof(CategoryAttribute), false).OfType<CategoryAttribute> ()
					.Select (a => a.Name).ToArray ();
		}

		public static UIFont FontOfSize<T>(float size) where T : struct
		{
			var fontName = typeof(T)
				.GetCustomAttributes (typeof(FontAttribute), false)
				.OfType<FontAttribute> ()
				.FirstOrDefault ();

			if (null == fontName) {
				throw new InvalidOperationException ("FontAttribute not found");
			}

			var font = UIFont.FromName (fontName.Name, size);

			return font;
		}

		public static UIImage ToUIImage(this Icon icon, float size = 20.0f, UIColor color = null)
		{
			color = color ?? UIColor.DarkTextColor;
			var fontAwesome = FontOfSize<Icon>(size);
			NSString str = new NSString( icon.AsString());
			var imgSize = str.StringSize (fontAwesome);
			UIImage image = null;

			try{
				UIGraphics.BeginImageContextWithOptions (imgSize, false, 0.0f);
				color.SetFill();
				str.DrawString (PointF.Empty, fontAwesome);
				image = UIGraphics.GetImageFromCurrentImageContext ();
			} finally{
				UIGraphics.EndImageContext ();
			}
			return image;
		}
	}
}

