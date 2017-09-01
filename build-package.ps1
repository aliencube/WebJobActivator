# This script runs solution build.
Param(
	[string] [Parameter(Mandatory=$true)] $Version,
	[string] [Parameter(Mandatory=$false)] $Configuration = "Debug"
)

# Builds NuGet package

Write-Host "Building NuGet package..." -ForegroundColor Green

nuget pack .\src\WebJobActivator.Core\WebJobActivator.Core.nuspec -Version $Version -Build -Symbols -OutputDirectory ".\src\WebJobActivator.Core\bin\$Configuration" -Properties Configuration=$Configuration
nuget pack .\src\WebJobActivator.Autofac\WebJobActivator.Autofac.nuspec -Version $Version -Build -Symbols -OutputDirectory ".\src\WebJobActivator.Autofac\bin\$Configuration" -Properties Configuration=$Configuration

Write-Host "NuGet package built" -ForegroundColor Green
