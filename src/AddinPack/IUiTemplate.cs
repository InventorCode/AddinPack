using System;

namespace InventorCode.AddinPack
{
    public interface IUiTemplate
    {
        void Activate();
        void BuildUserInterface();
        void Deactivate();
        void Execute();
    }
}
