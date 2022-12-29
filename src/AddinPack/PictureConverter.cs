namespace InventorCode.AddinPack
{
    [System.ComponentModel.DesignerCategory("")]
    public class PictureConverter : System.Windows.Forms.AxHost
    {
        public PictureConverter() : base("59EE46BA-677D-4d20-BF10-8D8067CB8B32")
        {
        }

        public static stdole.IPictureDisp ImageToPictureDisp(System.Drawing.Image image)
        {
            return (stdole.IPictureDisp)(GetIPictureDispFromPicture(image));
        }

        public static stdole.IPictureDisp ConvertIconToIPictureDisp( System.Drawing.Icon Icon)
            {
                try
                {
                    return (stdole.IPictureDisp)GetIPictureFromPicture(Icon.ToBitmap());
                }
                catch
                {
                    return null;
                }
            }

        public static stdole.IPictureDisp ConvertIconSizeToIPictureDisp(System.Drawing.Icon icon, int x, int y)
        {
            System.Drawing.Icon smallIco = new System.Drawing.Icon(icon, x, y);
            try
            {
                return (stdole.IPictureDisp)PictureConverter.GetIPictureFromPicture(smallIco.ToBitmap());
            }
            catch
            {
                return null;
            }
        }

        public static System.Drawing.Image PictureDispToImage(stdole.IPictureDisp image)
        {
            return GetPictureFromIPictureDisp(image);
        }
    }
}