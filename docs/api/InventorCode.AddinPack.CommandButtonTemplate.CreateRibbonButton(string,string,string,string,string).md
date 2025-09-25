### [InventorCode\.AddinPack](InventorCode.AddinPack.md 'InventorCode\.AddinPack').[CommandButtonTemplate](InventorCode.AddinPack.CommandButtonTemplate.md 'InventorCode\.AddinPack\.CommandButtonTemplate')

## CommandButtonTemplate\.CreateRibbonButton\(string, string, string, string, string\) Method

This method inserts the command button into the Inventor ribbon UI\. This is typically called from the CommandBUttonTemplate\.BuildUserInterface\(\) method\.

```csharp
public void CreateRibbonButton(string ribbon, string tabName, string tabId, string panelName, string panelId);
```
#### Parameters

<a name='InventorCode.AddinPack.CommandButtonTemplate.CreateRibbonButton(string,string,string,string,string).ribbon'></a>

`ribbon` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The Inventor ribbon name

<a name='InventorCode.AddinPack.CommandButtonTemplate.CreateRibbonButton(string,string,string,string,string).tabName'></a>

`tabName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the tab to add the button to

<a name='InventorCode.AddinPack.CommandButtonTemplate.CreateRibbonButton(string,string,string,string,string).tabId'></a>

`tabId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The internal name of the tab to add the button to

<a name='InventorCode.AddinPack.CommandButtonTemplate.CreateRibbonButton(string,string,string,string,string).panelName'></a>

`panelName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the panel to add the button to

<a name='InventorCode.AddinPack.CommandButtonTemplate.CreateRibbonButton(string,string,string,string,string).panelId'></a>

`panelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The internal name of the panel to add the button to