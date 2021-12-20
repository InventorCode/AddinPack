namespace InventorCode.AddinPack
{
    /// <summary>
    /// Icon provides a wrapper for Inventor icons that allows the dev to update icon
    /// images based on the user's theme.  Most useful when handling ribbon resets
    /// after the user has changed their theme from light/dark, or vice versa.
    /// </summary>
    public class Icon
    {
        private Inventor.Application _invApp;
        private stdole.IPictureDisp smallIcon;
        private stdole.IPictureDisp largeIcon;
        private stdole.IPictureDisp smallIconDark;
        private stdole.IPictureDisp largeIconDark;

        public System.Drawing.Bitmap SmallIconImage
        {
            set => smallIcon = PictureConverter.ImageToPictureDisp(value);
        }

        public System.Drawing.Bitmap SmallIconDarkImage
        {
            set => smallIconDark = PictureConverter.ImageToPictureDisp(value);
        }

        public System.Drawing.Bitmap LargeIconImage
        {
            set => largeIcon = PictureConverter.ImageToPictureDisp(value);
        }

        public System.Drawing.Bitmap LargeIconDarkImage
        {
            set => largeIconDark = PictureConverter.ImageToPictureDisp(value);
        }

        public stdole.IPictureDisp SmallIcon
        {
            get
            {
                if (IsDarkThemeActive(_invApp))
                { return smallIconDark; }
                else
                { return smallIcon; }
            }
        }

        public stdole.IPictureDisp LargeIcon
        {
            get
            {
                if (IsDarkThemeActive(_invApp))
                { return largeIconDark; }
                else
                { return largeIcon; }
            }
        }

        public Icon(Inventor.Application invApp)
        {
            _invApp = invApp;
        }

        public static bool IsDarkThemeActive(Inventor.Application invApp)
        {
            //version earlier than 2021 do not include dark mode, so return false
            if (invApp.SoftwareVersion.Major <= 23)
                return false;

            return invApp.ThemeManager.ActiveTheme.Name.ToUpper().Contains("DARK");
        }
    }
}