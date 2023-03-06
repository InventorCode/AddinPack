### [InventorCode.AddinPack](InventorCode.AddinPack.md 'InventorCode.AddinPack')

## InventorUiIcon Class

InventorUiIcon provides a wrapper for Inventor icons that allows the dev to  
wrap various image variations (size, light/dark theme) in a single object.  
This takes in various image formats.

```csharp
public class InventorUiIcon
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InventorUiIcon

| Constructors | |
| :--- | :--- |
| [InventorUiIcon(InventorTheme, object, object, object, object)](InventorCode.AddinPack.InventorUiIcon.InventorUiIcon(InventorCode.AddinPack.InventorTheme,object,object,object,object).md 'InventorCode.AddinPack.InventorUiIcon.InventorUiIcon(InventorCode.AddinPack.InventorTheme, object, object, object, object)') | Creates a new InventorUiIcon object with user-provided images. Supports bitmaps and icons. |

| Properties | |
| :--- | :--- |
| [Large](InventorCode.AddinPack.InventorUiIcon.Large.md 'InventorCode.AddinPack.InventorUiIcon.Large') | Returns the large image to match the current theme. |
| [Small](InventorCode.AddinPack.InventorUiIcon.Small.md 'InventorCode.AddinPack.InventorUiIcon.Small') | Returns the small image to match the current theme. |

| Methods | |
| :--- | :--- |
| [RefreshIcons()](InventorCode.AddinPack.InventorUiIcon.RefreshIcons().md 'InventorCode.AddinPack.InventorUiIcon.RefreshIcons()') | Refreshes the icon images to match the current theme. |
