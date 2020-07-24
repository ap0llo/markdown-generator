#
# This script creates a new release branch for the current version, increments
# the version on master and pushes both master and the new release branch.
#

# Imports
. (Join-Path $PSScriptRoot "common.ps1")

# Variables
$expectedCurrentBranch = "master"

# Functions
function checkoutAndPush($branchName) {

    log "Switching to branch $branchName"
    exec "git checkout `"$branchName`"" | Write-Host

    log "Pushing branch $branchName"
    exec "git push --set-upstream origin `"$branchName`"" | Write-Host
}

# Main script
Push-Location (Get-RepositoryRoot)
try {

    # Ensure we're on the master branch
    $currentBranch = exec "git rev-parse --abbrev-ref HEAD"
    if ($currentBranch -ne $expectedCurrentBranch) {
        throw "New releases must be created from master"
    }

    log "Restoring tools"
    exec "dotnet tool restore"

    log "Creating release branch"
    $nbgvOutput = exec "dotnet tool run nbgv -- prepare-release --format json" | ConvertFrom-Json
    $releaseBranchName = $nbgvOutput.NewBranch.Name

    if ($releaseBranchName) {
        log "Release branch name is '$releaseBranchName'"
    }
    else {
        throw "Failed to determine name of release branch"
    }

    checkoutAndPush $releaseBranchName
    checkoutAndPush $currentBranch
}
finally {
    Pop-Location
}
