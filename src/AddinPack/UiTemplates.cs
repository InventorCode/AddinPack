using System;
using System.Collections.Generic;

namespace InventorCode.AddinPack
{
    /// <summary>
    /// A collection IUiTemplate objects to manage their lifecycles.
    /// </summary>
    public class UiTemplates
    {
        /// <summary>
        /// The list of IUiTemplate objects.
        /// </summary>
        public List<IUiTemplate> Items { get; set; } = new List<IUiTemplate>() { };

        /// <summary>
        /// Creates a new UiTemplates object.
        /// </summary>
        public UiTemplates()
        {
        }

        /// <summary>
        /// Activates all user interface elements in the IUiTemplate collection.
        /// </summary>
        public void Activate()
        {
            foreach (var button in Items)
            {
                button.Activate();
            }
        }

        /// <summary>
        /// Adds a new IUiTemplate object to the collection.
        /// </summary>
        /// <param name="button">The IUiTemplate object to add.</param>
        public void Add(CommandButtonTemplate button) => Items.Add(button);

        /// <summary>
        /// Builds all user interface elements in the IUiTemplate collection.
        /// </summary>
        public void BuildUserInterface()
        {
            foreach (var button in Items)
            {
                button.BuildUserInterface();
            }
        }

        /// <summary>
        /// Deactivates all user interface elements in the IUiTemplate collection.
        /// </summary>
        public void Deactivate()
        {
            foreach (var button in Items)
            {
                button.Deactivate();
            }
        }
    }
}
