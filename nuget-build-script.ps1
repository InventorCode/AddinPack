dotnet pack .\src\AddinPack\AddinPack.csproj
nuget push artifacts/Debug/InventorCode.AddinPack.0.1.0-alpha1.nupkg -Source https://api.nuget.org/v3/index.json