
$root = Join-Path $PSScriptRoot ".."
$root = (Resolve-Path $root).Path

Push-Location $root

try {
    Write-Host "Restoring tools"
    Invoke-Expression "dotnet tool restore"

    Write-Host "Running dotnet format"
    Invoke-Expression "dotnet format --folder ./src"
}
finally {
    Pop-Location
}
