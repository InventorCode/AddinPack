using Inventor;
using System;
using System.Windows.Forms;

namespace InventorCode.AddinPack
{
    /// <summary>
    /// Abstract class for creating CommandButtons.  Implement the abstract methods and properties
    /// in a new class to utilize.
    /// </summary>
    public abstract class CommandButtonTemplate : IUiTemplate
    {
        protected ButtonDefinition commandButtonDefinition;
        protected Icon icon;
        protected Inventor.Application inventorApplication;
        UserInterfaceEvents uiEvents;

        public CommandButtonTemplate(Inventor.Application _inventorApplication, string _clientId)
        {
            this.inventorApplication = _inventorApplication;
            UIManager = _inventorApplication.UserInterfaceManager;
            this.clientId = _clientId;

            CreateIcons();
            CreateButtonDefinition();
        }

        public delegate void OnExecute(NameValueMap Context);

        protected bool CommandButtonExists()
        {
            ButtonDefinition test = null;
            try
            {
                test = (ButtonDefinition)inventorApplication.CommandManager.ControlDefinitions[internalName];
            }
            catch
            {
                return false;
            }

            return (test != null);
        }

        private void CreateButtonDefinition()
        {
            if (CommandButtonExists())
            {
                MessageBox.Show($"InventorCode.AddinPack.CommandButtonTemplate error 00F: \n" +
                    $"the internal command name {internalName} is already loaded in Inventor. Report this issue to " +
                    $"the add-in maintainer.", "Error");
                return;
            }

            var controlDefs = inventorApplication.CommandManager.ControlDefinitions;

            commandButtonDefinition = controlDefs.AddButtonDefinition(
                    displayName,
                    internalName,
                    classification,
                    clientId,
                    descriptionText,
                    toolTipText,
                    icon.SmallIcon,
                    icon.LargeIcon,
                    buttonDisplay);
        }

        private void CreateIcons()
        {
            icon = new Icon(inventorApplication);
            icon.SmallIconImage = SmallIconImage;
            icon.SmallIconDarkImage = SmallIconImageDark;
            icon.LargeIconImage = LargeIconImage;
            icon.LargeIconDarkImage = LargeIconImageDark;
        }

        private void customButtonDefinition_OnExecute(NameValueMap Context) => Execute();

        private UserInterfaceManager UIManager { get; }

        protected string clientId { get; }

        public void Activate()
        {
            uiEvents = inventorApplication.UserInterfaceManager.UserInterfaceEvents;
            uiEvents.OnResetRibbonInterface += OnResetRibbonInterface_handler;
            commandButtonDefinition.OnExecute += customButtonDefinition_OnExecute;
        }

        public void CreateRibbonButton(
            string ribbon,
            string tabName,
            string tabId,
            string panelName,
            string panelId)
        {
            // Get the assembly doc ribbon.
            Ribbon assemblyRibbon = UIManager.Ribbons[ribbon];

            // Get the getting started tab.
            RibbonTab ribbonTab;
            try
            {
                ribbonTab = assemblyRibbon.RibbonTabs[tabId];
            }
            catch
            {
                ribbonTab = assemblyRibbon.RibbonTabs.Add(tabName, tabId, clientId);
            }

            Inventor.RibbonPanel ribbonPanel;
            // Get the new features panel.
            try
            {
                ribbonPanel = ribbonTab.RibbonPanels[panelId];
            }
            catch
            {
                ribbonPanel = ribbonTab.RibbonPanels.Add(panelName, panelId, clientId);
            }

            // Add a button to the panel, using the previously created button definition.
            ribbonPanel.CommandControls.AddButton(commandButtonDefinition, false);
        }

        public void Deactivate()
        {
            commandButtonDefinition.OnExecute -= customButtonDefinition_OnExecute;
            commandButtonDefinition = null;

            uiEvents.OnResetRibbonInterface -= OnResetRibbonInterface_handler;
            uiEvents = null;

            inventorApplication = null;
        }

        private void OnResetRibbonInterface_handler(NameValueMap Context) => BuildUserInterface();

        #region Override in extending class
        /// <summary>
        /// The name of the command button as it will appear in the UI.
        /// </summary>
        protected abstract string displayName { get; set; }
        /// <summary>
        /// The internal name of the command button.  Must be unique across the Inventor Application.
        /// </summary>
        protected abstract string internalName { get; set; }
        /// <summary>
        /// The classification of the command button; define as a Inventor.CommandTypesEnum
        /// </summary>
        protected abstract CommandTypesEnum classification { get; set; }
        /// <summary>
        /// The description of the command button.
        /// </summary>
        protected abstract string descriptionText { get; set; }
        /// <summary>
        /// The tooltip text of the command button.
        /// </summary>
        protected abstract string toolTipText { get; set; }
        /// <summary>
        /// The button display style for the command.
        /// </summary>
        protected abstract ButtonDisplayEnum buttonDisplay { get; set; }
        /// <summary>
        /// The small icon image for the command button.
        /// </summary>
        protected abstract System.Drawing.Bitmap SmallIconImage { get; set; }
        /// <summary>
        /// The small icon image for the command button when in dark mode.
        /// </summary>
        protected abstract System.Drawing.Bitmap SmallIconImageDark { get; set; }
        /// <summary>
        /// The large icon image for the command button.
        /// </summary>
        protected abstract System.Drawing.Bitmap LargeIconImage { get; set; }
        /// <summary>
        /// The large icon image for the command button when in dark mode.
        /// </summary>
        protected abstract System.Drawing.Bitmap LargeIconImageDark { get; set; }
        /// <summary>
        /// The method to execute when Inventor builds the user interface. Place code that creates ribbon buttons, etc here.
        /// Refer to CommandButtonTemplate.CreateRibbonButton().
        /// </summary>
        public abstract void BuildUserInterface();
        /// <summary>
        /// The method to execute when the command button is clicked.
        /// </summary>
        public abstract void Execute();

        #endregion
    }
}
