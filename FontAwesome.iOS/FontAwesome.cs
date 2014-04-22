using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace FontAwesome
{
	public static class WebFont
	{
		public static string FontName = "FontAwesome";

		public static UIFont FontOfSize(float size)
		{
			return UIFont.FromName (FontName, size);
		}

		public static UIImage ToUIImage(this Icon icon, float size = 20.0f, UIColor color = null)
		{
			color = color ?? UIColor.DarkTextColor;
			var fontAwesome = FontOfSize(size);
			NSString str = new NSString( icon.AsString());
			var imgSize = str.StringSize (fontAwesome);
			UIImage image = null;
			UIGraphics.BeginImageContextWithOptions (imgSize, false, 0.0f);
			try{
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

