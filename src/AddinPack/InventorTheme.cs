using Inventor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorCode.AddinPack
{
    public class InventorTheme
    {
        Inventor.Application application;
        string themeName{get => application.ThemeManager.ActiveTheme.Name;}
        bool unsupportedVersion;

        public InventorTheme(Inventor.Application app)
        {
            application = app;

            //version earlier than 2021 do not include dark mode, so return false
            unsupportedVersion = (application.SoftwareVersion.Major <= 23);
        }

        public bool IsDarkTheme
        {
              get
              {
                  if(unsupportedVersion)
                    return false;
                  return ThemeNameContainsDark();
              }
        }

        private bool ThemeNameContainsDark()
        {
            return themeName.IndexOf("DARK", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
