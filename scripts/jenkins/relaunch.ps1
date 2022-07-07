Write-Host ' + Stop container'
. "${PSScriptRoot}\stop.ps1"

Write-Host ' + Rebuild image'
. "${PSScriptRoot}\build.ps1"

Write-Host ' + Launch container'
. "${PSScriptRoot}\launch.ps1"