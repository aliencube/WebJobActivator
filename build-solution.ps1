# This script runs solution build.
Param(
	[string] [Parameter(Mandatory=$false)] $Configuration = "Debug",
	[string] [Parameter(Mandatory=$false)] $Platform = "Any CPU"
)

# Restores NuGet packages
Write-Host "Restoring NuGet packages ..." -ForegroundColor Green

nuget restore .\WebJobActivator.sln

Write-Host "NuGet packages restored" -ForegroundColor Green

# Builds solution
Write-Host "Building WebJobActivator.sln ..." -ForegroundColor Green

# $msbuild = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\msbuild.exe"
$msbuild = "msbuild"
& $msbuild .\WebJobActivator.sln /t:Rebuild /p:Configuration=$Configuration /p:Platform=$Platform

Write-Host "WebJobActivator.sln built" -ForegroundColor Green
