$ErrorActionPreference = "Stop"

# Install SDK and runtime as specified in global.json
./build/dotnet-install.ps1 -JsonFile "$PSScriptRoot/global.json"

dotnet run --project build/Build.csproj -- $args
exit $LASTEXITCODE