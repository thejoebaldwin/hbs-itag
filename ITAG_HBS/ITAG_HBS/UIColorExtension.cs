using System;
using UIKit;

namespace ITAG.HBS
{
    public class UIColorExtension
    {
		public static UIColor FromHex(int hexValue)
		{
			return UIColor.FromRGB(
				(((hexValue & 0xFF0000) >> 16) / 255.0f),
				(((hexValue & 0xFF00) >> 8) / 255.0f),
				((hexValue & 0xFF) / 255.0f)
			);
		}
    }
}
