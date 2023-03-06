using System;

namespace InventorCode.AddinPack
{
    /// <summary>
    /// Provides a simple interface for user interface objects.
    /// </summary>
    public interface IUiTemplate
    {
        /// <summary>
        /// Activates the user interface.
        /// </summary>
        void Activate();

        /// <summary>
        /// Builds the user interface.
        /// </summary>
        void BuildUserInterface();

        /// <summary>
        /// Deactivates the user interface.
        /// </summary>
        void Deactivate();

        /// <summary>
        /// Executes when the UI element is activated by the user.
        /// </summary>
        void Execute();
    }
}
