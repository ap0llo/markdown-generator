$ErrorActionPreference = "Stop"

# Install .NET 5 runtime (requried for runnign some of the local tools during build)
./build/dotnet-install.ps1 -Channel 5.0 -Runtime dotnet

# Install SDK and runtime as specified in global.json
./build/dotnet-install.ps1 -JsonFile "$PSScriptRoot/global.json"

dotnet run --project build/Build.csproj -- $args
exit $LASTEXITCODE