Push-Location
dotnet build .\src\AddinPack\AddinPack.csproj -c Release
Get-ChildItem artifacts/*.nupkg -Recurse | foreach { Remove-Item -Path $_.FullName }
dotnet pack .\src\AddinPack\AddinPack.csproj -c Release