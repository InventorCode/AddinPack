# AddinPack

A simple collection of classes to simplify creating Autodesk Inventor addins.

The thought for this is that you can structure your addin such that each command is defined separately, and AddinPack will handle the management of them. For example, the following would be a typical addin structure:

- MyAddin Project
    - StandardAddInServer.cs
    - namespace Tool1
        - CommandButton.cs
        - Form.cs
        - Form.Designer.cs
    - namespace Tool2
        - CommandButton.cs
        - Tool2Helpers.cs


## UiTemplates

This is a simple collection class to manage loading multiple user interface components into your add-in (e.g. ribbon command-buttons, combo-boxes, etc). It supports the following:

- `List<IUiTemplate> Items` - collection of IUiTemplate objects to be managed from your StandardAddInServer class.
- `Add()` - adds an IUiTemplate object to the Items collection.
- `Activate()` - calls the Activate method on each IUiTemplate object in the Items collection.
- `Deactivate()` - calls the Deactivate method on each IUiTemplate object in the Items collection.
- `BuildUserInterface()` - calls the BuildUserInterface method on each IUiTemplate object in the Items collection.

Let's look at a simple (truncated) StandardAddInServer example that uses the UiTemplates class to manage loading your command buttons and other ui elements:

``` c#
    public class StandardAddinServer : Inventor.ApplicationAddInServer
    {
        //initialize the UiTemplates collection - this will hold all the UiComponents we're going to have managed...
        UiTemplates elements = new UiTemplates();

        public void Activate(Inventor.Application InventorApplication, string clientId, bool firstTime = true)
        {
            _inventorApplication = InventorApplication;

            //We'll add some command buttons to the UiTemplates collection here... you can dynamically load and unload these as needed...
            elements.Add(new Tool1.CommandButton(_inventorApplication, clientId));
            elements.Add(new Tool2.CommandButton(_inventorApplication, clientId));

            elements.Activate();
            if (firstTime)
                elements.BuildUserInterface();
        }

        public void Deactivate()
        {
            elements.Deactivate();
            _inventorApplication = null;
        }

        public void Execute()
        {
        }

    //continue the rest of the StandardAddInServer class here, not shown for brevity
    }
```
## IUiTemplate

An IUiTemplate is a simple interface for all UiTemplate objects. For the most part you won't need to worry about this, other than knowing that
- the IUiTemplate interface is used for all AddkinPack UI template elements (you can see it in the StandardAddInServer example above), and
- if you want to know how this all works under the hood.

It exposes the following members:

``` c#
    public interface IUiTemplate
    {
        void Activate();
        void BuildUserInterface();
        void Deactivate();
        void Execute();
    }
```

## CommandButtonTemplate

Now we'll look at how to define a CommandButton. We'll derive a class based on the CommandButtonTemplate class. The CommandButtonTemplate base class is part of AddinPack and does the hard work related to creating and managing an Inventor CommandButton. The `InventorCode.AddinPack.CommandButtonTemplate` does the following:
- Defines the Inventor CommandButton object
- Handles the activation/deactivation of the Inventor CommandButton object
- Manages the icon images for the button, including dark mode support and switching between dark and light mode
- Handles creation or access of the various ribbon elements. The user simply uses the CreateRibbonButton() method to trigger the creation of the ribbon interface for their command.
- Wires up the events to detect when the button is clicked by the user, or when the ribbon is reset.

Lets say we want to create a new command, ToolOne.  This Inventor command is created by deriving a `CommandButton` class from `CommandButtonTemplate` as shown:

``` c#
using Inventor;
using InventorCode.AddinPack;
using System;

namespace MyAddin.Tool1
{
    public class CommandButton : CommandButtonTemplate
    {
        public CommandButton(Inventor.Application _inventorApplication, string _clientId) : base(
            _inventorApplication,
            _clientId)
        { }

        protected override string displayName { get; set; } = "Tool One";
        //A unique command name used by inventor to identify the command
        protected override string internalName { get; set; } = "MyAddin_ToolOne";
        protected override string descriptionText { get; set; } = "This is a description of the Tool One.";
        protected override string toolTipText { get; set; } = "This is a tool tip text for the Tool One.";

        protected override CommandTypesEnum classification { get; set; } = CommandTypesEnum.kQueryOnlyCmdType;
        protected override ButtonDisplayEnum buttonDisplay { get; set; } = ButtonDisplayEnum.kAlwaysDisplayText;

        //Add the button images, those shown are embedded resources of the project... supported file formats currently include ico and bitmap images. Transparency is supported in ico files. The ico files do not currently support multi-size images, so you'll need to create a separate ico file for each size.
        protected override object SmallIconImage { get; set; } = Properties.Resources.toolOne16;
        protected override object SmallIconImageDark { get; set; } = Properties.Resources.toolOne16Dark;
        protected override object LargeIconImage { get; set; } = Properties.Resources.toolOne32;
        protected override object LargeIconImageDark { get; set; } = Properties.Resources.toolOne32Dark;

        //Here we'll add the ribbon button to the ribbon, wherever we want it...
        public override void BuildUserInterface()
        {
            //Create the ribbon button for the drawing environment
            CreateRibbonButton(
                ribbon: "Drawing",
                tabName: "MyAddin",
                tabId: "id_Tab_MyAddinDrawing",
                panelName: "MyAddin Panel",
                panelId: "id_Panel_MyAddin");

            //Create the ribbon button for the part environment
            CreateRibbonButton(
                ribbon: "Part",
                tabName: "MyAddin",
                tabId: "id_Tab_MyAddinPart",
                panelName: "MyAddin Panel",
                panelId: "id_Panel_MyAddin");

            //
            CreateRibbonButton(
                ribbon: "Assembly",
                tabName: "MyAddin",
                tabId: "id_Tab_MyAddinAssembly",
                panelName: "MyAddin Panel",
                panelId: "id_Panel_MyAddin");
        }

        public override void Execute()
        {
            //Add your code here to handle when the user presses the button...              
        }
    }
}
```

