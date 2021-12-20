namespace InventorCode.AddinPack
{
    public static class GlobalsBase
    {
        public static Inventor.Application InvApp { get; set; }
        public static string ClientID { get; set; }

        public static string ClientIDBracketed = "{" + ClientID + "}";
    }
}