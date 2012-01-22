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

. "$($scriptPath)\..\nugetgallery\Scripts\Get-ConnectionString.ps1"

if ($connectionString.Trim() -eq "") 
{
  $connectionString = Get-ConnectionString -configPath (join-path $scriptPath '..\chocolatey\Website\web.config') -connectionStringName NuGetGallery
}


#Write-host "================================================"
#Write-host "UpdateDatabase - $connectionString"
#Write-host "================================================"
#& "$(get-content env:windir)\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" "$nugetProjFile" /p:DbConnection=$connectionString /t:UpdateDatabase 

# Write-host "================================================"
# Write-host "Copying chocolatey items over the nuget defaults"
# Write-host "================================================"
# $chocWeb = "$($scriptPath)\..\Website"
# $buildDest = "$($scriptPath)\..\..\bin\_PublishedWebsites"
# Write-host "Copying the contents of `'$chocWeb`' to `'$buildDest`'"
# Copy-Item $chocWeb $buildDest -recurse -force