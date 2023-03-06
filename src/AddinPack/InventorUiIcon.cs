using stdole;
using System;
using System.Linq;

namespace InventorCode.AddinPack
{
    /// <summary>
    /// InventorUiIcon provides a wrapper for Inventor icons that allows the dev to
    /// wrap various image variations (size, light/dark theme) in a single object.
    /// This takes in various image formats.
    /// </summary>
    public class InventorUiIcon
    {
        private InventorTheme theme;
        private stdole.IPictureDisp small;
        private stdole.IPictureDisp large;
        private stdole.IPictureDisp smallDark;
        private stdole.IPictureDisp largeDark;

        /// <summary>
        /// Creates a new InventorUiIcon object with user-provided images. Supports bitmaps and icons.
        /// </summary>
        /// <param name="theme">An InventorTheme object to use for the icon's handling of light/dark icon switching.</param>
        /// <param name="small">The small icon image.</param>
        /// <param name="large">The large icon image.</param>
        /// <param name="smallDark">The small icon image for dark themes.</param>
        /// <param name="largeDark">The large icon image for dark themes.</param>
        public InventorUiIcon(InventorTheme theme, object small, object large, object smallDark, object largeDark)
        {
            this.theme = theme;

            this.small = ConvertImageFormat(small);
            this.large = ConvertImageFormat(large);
            this.smallDark = ConvertImageFormat(smallDark);
            this.largeDark = ConvertImageFormat(largeDark);

            RefreshIcons();
        }

        /// <summary>
        /// Returns the large image to match the current theme.
        /// </summary>
        /// <returns>Returns an IPictureDisp</returns>
        public stdole.IPictureDisp Large { get; set; }
        
        /// <summary>
        /// Returns the small image to match the current theme.
        /// </summary>
        /// <returns>Returns an IPictureDisp</returns>
        public stdole.IPictureDisp Small { get; set; }

        /// <summary>
        /// Refreshes the icon images to match the current theme.
        /// </summary>
        public void RefreshIcons()
        {
            if (theme.IsDarkTheme)
            {
                Small = smallDark;
                Large = largeDark;
            }
            else
            {
                Small = small;
                Large = large;
            }
        }

        IPictureDisp ConvertImageFormat(object image)
        {
            switch (image)
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
    }
}
