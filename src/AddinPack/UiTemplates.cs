using System;
using System.Collections.Generic;

namespace InventorCode.AddinPack
{
    public class UiTemplates
    {
        public List<IUiTemplate> Items { get; set; } = new List<IUiTemplate>() { };

        public UiTemplates()
        {
        }

        public void Activate()
        {
            foreach (var button in Items)
            {
                button.Activate();
            }
        }

        public void Add(CommandButtonTemplate button) => Items.Add(button);

        public void BuildUserInterface()
        {
            foreach (var button in Items)
            {
                button.BuildUserInterface();
            }
        }

        public void Deactivate()
        {
            foreach (var button in Items)
            {
                button.Deactivate();
            }
        }
    }
}
