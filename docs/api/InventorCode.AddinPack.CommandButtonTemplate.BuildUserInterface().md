### [InventorCode\.AddinPack](InventorCode.AddinPack.md 'InventorCode\.AddinPack').[CommandButtonTemplate](InventorCode.AddinPack.CommandButtonTemplate.md 'InventorCode\.AddinPack\.CommandButtonTemplate')

## CommandButtonTemplate\.BuildUserInterface\(\) Method

The method to execute when Inventor builds the user interface\. Place code that creates ribbon buttons, etc here\.
This is typically done by calling the CommandButtonTemplate\.CreateRibbonButton\(\) method\. This must be overridden in the extending class\.

```csharp
public abstract void BuildUserInterface();
```

Implements [BuildUserInterface\(\)](InventorCode.AddinPack.IUiTemplate.BuildUserInterface().md 'InventorCode\.AddinPack\.IUiTemplate\.BuildUserInterface\(\)')