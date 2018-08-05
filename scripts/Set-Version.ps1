param(
    [switch]$Major,
    [switch]$Minor
)
$versionJsonFilePath = Join-Path $PSScriptRoot "..\version.json"
$preReleaseTag = "-prerelease"

function Start-Git($command) {
    Invoke-Expression "git $command"
    if($LASTEXITCODE -ne 0) {
        throw "Command 'git $command' failed (exit code $LASTEXITCODE)"
    }
}

if(-not ($Major -or $Minor)) {
    throw "Use either the -Major or -Minor switch to increment the version"
}
if($Major -and $Minor) {
    throw "The switches -Major or -Minor cannot be used together"
}

if(-not (Test-Path $versionJsonFilePath)) {
    throw "version.json not found (expected at '$versionJsonFilePath')"
}

$currentBranchName = Start-Git "rev-parse --abbrev-ref HEAD"

if($currentBranchName -eq $null) {
    throw "Failed to dermine current branch"
}

# Read version.json to determine version to be release
try {
    $versionInfo = ConvertFrom-Json (Get-Content -Raw -Path $versionJsonFilePath)
    $currentVersion = $versionInfo.version
    $releaseVersion = [version]($versionInfo.version.Replace($preReleaseTag, ""))
} catch {
    throw
}

# Determine new version for current branch
if($Major) {
    $newVersion = "$($releaseVersion.Major + 1).0$preReleaseTag"
} elseif($Minor) {
    $newVersion = "$($releaseVersion.Major).$($releaseVersion.Minor + 1)$preReleaseTag"
}

Write-Host "Current version is '$currentVersion'"
Write-Host "Version to be released is '$releaseVersion'"
Write-Host "Version for current branch '$currentBranchName' will be set to '$newVersion'"

# Prompt for user confirmation
$choice = ""
while ($choice -notmatch "[y|n]"){
    $choice = Read-Host "Do you want to continue? (Y/N)"
}
if ($choice -eq "n"){
    exit 0
}
    

# Create release branch for current version
$releaseBranchName = "release/v$releaseVersion"

Write-Host "Creating release branch '$releaseBranchName'"
Start-Git "checkout -b $releaseBranchName"

Write-Host "Updating version.json on release branch"
$versionInfo.version = "$($releaseVersion.Major).$($releaseVersion.Minor)"
$versionInfo | ConvertTo-Json | Out-File $versionJsonFilePath -Encoding utf8

Start-Git "add `"$versionJsonFilePath`""
Start-Git "commit -m `"Create release branch v$releaseVersion`""

# Switch current branch to new version
Write-Host "Updating version.json on branch $currentBranchName"
Start-Git "checkout $currentBranchName"
$versionInfo.version = $newVersion
$versionInfo | ConvertTo-Json | Out-File $versionJsonFilePath -Encoding utf8
Start-Git "add `"$versionJsonFilePath`""
Start-Git "commit -m `"Set version to $newVersion`""

Write-Host "Version(s) updated successfully"