using InventorCode.AddinPack;
using stdole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorCode.AddinPack
{
    /// <summary>
    /// InventorUiIcon provides a wrapper for Inventor icons that allows the dev to
    /// wrap various image variations (size, light/dark theme) in a single object.
    /// This takes in various image formats.
    /// </summary>
    public class InventorUiIcon
    {
        private Inventor.Application _invApp;
        private stdole.IPictureDisp small;
        private stdole.IPictureDisp large;
        private stdole.IPictureDisp smallDark;
        private stdole.IPictureDisp largeDark;

        public InventorUiIcon(Inventor.Application invApp, object small, object large, object smallDark, object largeDark)
        {
            _invApp = invApp;

            this.small = ConvertImageFormat(small);
            this.large = ConvertImageFormat(large);
            this.smallDark = ConvertImageFormat(smallDark);
            this.largeDark = ConvertImageFormat(largeDark);
        }

        IPictureDisp ConvertImageFormat(object image)
        {
            switch(image)
            {
                case System.Drawing.Icon icon:
                    return PictureDispConverter.ToIPictureDisp(icon);

                case System.Drawing.Bitmap bitmap:
                    return PictureDispConverter.ToIPictureDisp(bitmap);

                case stdole.IPictureDisp picture:
                    return picture;

                default:
                    throw new ArgumentException("A command button icon was in an invalid image format.");
            }
        }

        public stdole.IPictureDisp Small
        {
            get
            {
                if (IsDarkThemeActive(_invApp))
                { return smallDark; }
                else
                { return small; }
            }
        }

        public stdole.IPictureDisp Large
        {
            get
            {
                if (IsDarkThemeActive(_invApp))
                { return largeDark; }
                else
                { return large; }
            }
        }

        public static bool IsDarkThemeActive(Inventor.Application invApp)
        {
            //version earlier than 2021 do not include dark mode, so return false
            if (invApp.SoftwareVersion.Major <= 23)
                return false;
            return ThemeNameContainsDark(invApp);
        }

        private static bool ThemeNameContainsDark(Inventor.Application invApp)
        {
            return invApp.ThemeManager.ActiveTheme.Name.IndexOf("DARK", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
