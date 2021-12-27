#
# This scripts runs "dotnet format" over the entire code base and fixes formatting errors.
# The script schould be run before every commit.
# The CI pipeline in Azure DevOps verifies the formatting and the build will fail if any formatting errors are found
#

# Imports
. (Join-Path $PSScriptRoot "common.ps1")

# Main script
Push-Location (Get-RepositoryRoot)
try {
    log "Running dotnet format"
    exec "dotnet format src\MarkdownGenerator.sln"
}
finally {
    Pop-Location
}
