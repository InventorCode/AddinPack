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
        protected InventorUiIcon icon;
        protected Inventor.Application inventorApplication;
        ApplicationEvents applicationEvents;
        UserInterfaceEvents uiEvents;
        InventorTheme theme;

        /// <summary>
        /// Command button template constructor.
        /// </summary>
        /// <param name="_inventorApplication">The Inventor.Application object.</param>
        /// <param name="_clientId">The client id of the add-in.</param>
        public CommandButtonTemplate(Inventor.Application _inventorApplication, string _clientId)
        {
            this.inventorApplication = _inventorApplication;
            UIManager = _inventorApplication.UserInterfaceManager;
            applicationEvents = inventorApplication.ApplicationEvents;
            this.clientId = _clientId;

            theme = new InventorTheme(inventorApplication);

            CreateUiIcon();
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
                    icon.Small,
                    icon.Large,
                    buttonDisplay);
        }

        private void CreateUiIcon()
        {
            icon = new InventorUiIcon(theme,
                                   small: SmallIconImage,
                                   large: LargeIconImage,
                                   smallDark: SmallIconImageDark,
                                   largeDark: LargeIconImageDark);
        }

        private void customButtonDefinition_OnExecute(NameValueMap Context) => Execute();

        private UserInterfaceManager UIManager { get; }

        protected string clientId { get; }

        public void Activate()
        {
            uiEvents = inventorApplication.UserInterfaceManager.UserInterfaceEvents;
            uiEvents.OnResetRibbonInterface += OnResetRibbonInterface_handler;
            commandButtonDefinition.OnExecute += customButtonDefinition_OnExecute;
            applicationEvents.OnApplicationOptionChange += OnApplicationOptionChange_handler;
        }

        /// <summary>
        /// This method inserts the command button into the Inventor ribbon UI. This is typically called from the CommandBUttonTemplate.BuildUserInterface() method.
        /// </summary>
        /// <param name="ribbon">The Inventor ribbon name</param>
        /// <param name="tabName">The name of the tab to add the button to</param>
        /// <param name="tabId">The internal name of the tab to add the button to</param>
        /// <param name="panelName">The name of the panel to add the button to</param>
        /// <param name="panelId">The internal name of the panel to add the button to</param>
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

            applicationEvents.OnApplicationOptionChange -= OnApplicationOptionChange_handler;
            applicationEvents = null;

            uiEvents.OnResetRibbonInterface -= OnResetRibbonInterface_handler;
            uiEvents = null;

            inventorApplication = null;
        }

        private void OnApplicationOptionChange_handler(EventTimingEnum BeforeOrAfter, NameValueMap Context, out HandlingCodeEnum HandlingCode)
        {
            if (BeforeOrAfter == EventTimingEnum.kAfter)
            {
                icon.RefreshIcons();
                commandButtonDefinition.LargeIcon = icon.Large;
                commandButtonDefinition.StandardIcon = icon.Small;
            }
            HandlingCode = HandlingCodeEnum.kEventNotHandled;
        }

        private void OnResetRibbonInterface_handler(NameValueMap Context) => BuildUserInterface();

        #region Override in extending class
        /// <summary>
        /// The name of the command button as it will appear in the UI. This must be overridden in the extending class.
        /// </summary>
        protected abstract string displayName { get; set; }
        /// <summary>
        /// The internal name of the command button.  Must be unique across the Inventor Application. This must be overridden in the extending class.
        /// </summary>
        protected abstract string internalName { get; set; }
        /// <summary>
        /// The classification of the command button; define as a Inventor.CommandTypesEnum. This must be overridden in the extending class.
        /// </summary>
        protected abstract CommandTypesEnum classification { get; set; }
        /// <summary>
        /// The description of the command button. This must be overridden in the extending class.
        /// </summary>
        protected abstract string descriptionText { get; set; }
        /// <summary>
        /// The tooltip text of the command button. This must be overridden in the extending class.
        /// </summary>
        protected abstract string toolTipText { get; set; }
        /// <summary>
        /// The button display style for the command. This must be overridden in the extending class.
        /// </summary>
        protected abstract ButtonDisplayEnum buttonDisplay { get; set; }
        /// <summary>
        /// The small icon image for the command button. This must be overridden in the extending class.
        /// </summary>
        protected abstract object SmallIconImage { get; set; }

        /// <summary>
        /// The small icon image for the command button when in dark mode. This must be overridden in the extending class.
        /// </summary>
        protected abstract object SmallIconImageDark { get; set; }

        /// <summary>
        /// The large icon image for the command button. This must be overridden in the extending class.
        /// </summary>
        protected abstract object LargeIconImage { get; set; }

        /// <summary>
        /// The large icon image for the command button when in dark mode. This must be overridden in the extending class.
        /// </summary>
        protected abstract object LargeIconImageDark { get; set; }

        /// <summary>
        /// The method to execute when Inventor builds the user interface. Place code that creates ribbon buttons, etc here.
        /// This is typically done by calling the CommandButtonTemplate.CreateRibbonButton() method. This must be overridden in the extending class.
        /// </summary>
        public abstract void BuildUserInterface();

        /// <summary>
        /// The method to execute when the command button is clicked. This must be overridden in the extending class.
        /// </summary>
        public abstract void Execute();

        #endregion
    }
}
