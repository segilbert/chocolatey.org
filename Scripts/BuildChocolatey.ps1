param($connectionString = "")

$scriptPath = Split-Path $MyInvocation.MyCommand.Path

$nugetProjFile = "$($scriptPath)\ChocolateyGallery.msbuild"
write-host "Running $nugetProjFile with $connectionString" 
Write-host "================================================"
Write-host "Build"
Write-host "================================================"
& "$(get-content env:windir)\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" "$nugetProjFile" /t:Build 
Write-host "================================================"
Write-host "CleanBuildOutput"
Write-host "================================================"
& "$(get-content env:windir)\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" "$nugetProjFile" /t:CleanBuildOutput 

# Write-host "================================================"
# Write-host "Copying chocolatey items over the nuget defaults"
# Write-host "================================================"
# $chocWeb = "$($scriptPath)\..\Website"
# $buildDest = "$($scriptPath)\..\..\bin\_PublishedWebsites"
# Write-host "Copying the contents of `'$chocWeb`' to `'$buildDest`'"
# Copy-Item $chocWeb $buildDest -recurse -force