### [InventorCode.AddinPack](InventorCode.AddinPack.md 'InventorCode.AddinPack')

## CommandButtonTemplate Class

Abstract class for creating CommandButtons.  Implement the abstract methods and properties  
in a new class to utilize.

```csharp
public abstract class CommandButtonTemplate :
InventorCode.AddinPack.IUiTemplate
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CommandButtonTemplate

Implements [IUiTemplate](InventorCode.AddinPack.IUiTemplate.md 'InventorCode.AddinPack.IUiTemplate')

| Constructors | |
| :--- | :--- |
| [CommandButtonTemplate(Application, string)](InventorCode.AddinPack.CommandButtonTemplate.CommandButtonTemplate(Application,string).md 'InventorCode.AddinPack.CommandButtonTemplate.CommandButtonTemplate(Application, string)') | Command button template constructor. |

| Properties | |
| :--- | :--- |
| [buttonDisplay](InventorCode.AddinPack.CommandButtonTemplate.buttonDisplay.md 'InventorCode.AddinPack.CommandButtonTemplate.buttonDisplay') | The button display style for the command. This must be overridden in the extending class. |
| [classification](InventorCode.AddinPack.CommandButtonTemplate.classification.md 'InventorCode.AddinPack.CommandButtonTemplate.classification') | The classification of the command button; define as a Inventor.CommandTypesEnum. This must be overridden in the extending class. |
| [descriptionText](InventorCode.AddinPack.CommandButtonTemplate.descriptionText.md 'InventorCode.AddinPack.CommandButtonTemplate.descriptionText') | The description of the command button. This must be overridden in the extending class. |
| [displayName](InventorCode.AddinPack.CommandButtonTemplate.displayName.md 'InventorCode.AddinPack.CommandButtonTemplate.displayName') | The name of the command button as it will appear in the UI. This must be overridden in the extending class. |
| [internalName](InventorCode.AddinPack.CommandButtonTemplate.internalName.md 'InventorCode.AddinPack.CommandButtonTemplate.internalName') | The internal name of the command button.  Must be unique across the Inventor Application. This must be overridden in the extending class. |
| [LargeIconImage](InventorCode.AddinPack.CommandButtonTemplate.LargeIconImage.md 'InventorCode.AddinPack.CommandButtonTemplate.LargeIconImage') | The large icon image for the command button. This must be overridden in the extending class. |
| [LargeIconImageDark](InventorCode.AddinPack.CommandButtonTemplate.LargeIconImageDark.md 'InventorCode.AddinPack.CommandButtonTemplate.LargeIconImageDark') | The large icon image for the command button when in dark mode. This must be overridden in the extending class. |
| [SmallIconImage](InventorCode.AddinPack.CommandButtonTemplate.SmallIconImage.md 'InventorCode.AddinPack.CommandButtonTemplate.SmallIconImage') | The small icon image for the command button. This must be overridden in the extending class. |
| [SmallIconImageDark](InventorCode.AddinPack.CommandButtonTemplate.SmallIconImageDark.md 'InventorCode.AddinPack.CommandButtonTemplate.SmallIconImageDark') | The small icon image for the command button when in dark mode. This must be overridden in the extending class. |
| [toolTipText](InventorCode.AddinPack.CommandButtonTemplate.toolTipText.md 'InventorCode.AddinPack.CommandButtonTemplate.toolTipText') | The tooltip text of the command button. This must be overridden in the extending class. |

| Methods | |
| :--- | :--- |
| [BuildUserInterface()](InventorCode.AddinPack.CommandButtonTemplate.BuildUserInterface().md 'InventorCode.AddinPack.CommandButtonTemplate.BuildUserInterface()') | The method to execute when Inventor builds the user interface. Place code that creates ribbon buttons, etc here.<br/>This is typically done by calling the CommandButtonTemplate.CreateRibbonButton() method. This must be overridden in the extending class. |
| [CreateRibbonButton(string, string, string, string, string)](InventorCode.AddinPack.CommandButtonTemplate.CreateRibbonButton(string,string,string,string,string).md 'InventorCode.AddinPack.CommandButtonTemplate.CreateRibbonButton(string, string, string, string, string)') | This method inserts the command button into the Inventor ribbon UI. This is typically called from the CommandBUttonTemplate.BuildUserInterface() method. |
| [Execute()](InventorCode.AddinPack.CommandButtonTemplate.Execute().md 'InventorCode.AddinPack.CommandButtonTemplate.Execute()') | The method to execute when the command button is clicked. This must be overridden in the extending class. |
