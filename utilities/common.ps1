#
# Utility functions shared between scripts in this directory
#

function exec($command) {

    $output = Invoke-Expression $command | Out-String
    if ($LASTEXITCODE -ne 0) {
        throw "Command '$command' completed with exit code $LASTEXITCODE"
    }

    return $output.Trim()
}

function log($message) {
    Write-Host -ForegroundColor Green -Object $message
}

function Get-RepositoryRoot {
    $root = (exec "git rev-parse --show-toplevel" | Resolve-Path).Path
    return $root
}