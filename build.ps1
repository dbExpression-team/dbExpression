using module .\build\HatTrick\DirectoryBuildPropsFile\DirectoryBuildPropsFile.psm1
using module .\build\HatTrick\AssemblyVersion\AssemblyVersion.psm1

param
    (
        # The full path (including name) to the solution to build
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$SolutionPath = "DbEx.sln",

        # The full path (including name) to the Directory.build.props file used as a template to provide the base version (Major.Minor.Patch) version used to create assembly attributes and nuget packages.  If the fiile contains a VersionSuffix, it will be honored as provided.
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$PropertiesPath = "Directory.build.props",

        # The path to place constructed NuGet packages
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$NuGetOutputPath = "assets",

        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$Configuration = "Release",

        # The branch that sources public releases.  Any build processes from this branch will not use auto-generated build numbers and revisions in the package naming strategy, but will honor a VersionSuffix if supplied in the $PropertiesPath file.
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$PublicReleaseBranchName = "master",

        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BranchName,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CommitSHA,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BuildIdentifier,

        # A switch indicating whether the $BranchName should be used in generated a package name.  If VersionSuffix is supplied in the $PropertiesPath file, this switch has no effect.
        [switch]$UseBranchNameInPackageSuffixWhenNotSpecified
   )

Write-Host "BranchName parameter: " $BranchName
Write-Host "BuildIdentifier parameter: " $BuildIdentifier
Write-Host "CommitSHA parameter: " $CommitSHA
Write-Host "Configuration parameter: " $Configuration
Write-Host "NuGetOutputPath parameter: " $NuGetOutputPath
Write-Host "PropertiesPath parameter: " $PropertiesPath
Write-Host "PublicReleaseBranchName parameter: " $PublicReleaseBranchName
Write-Host "SolutionPath parameter: " $SolutionPath
Write-Host "UseBranchNameInPackageSuffixWhenNotSupplied switch: " $UseBranchNameInPackageSuffixWhenNotSpecified

$directoryBuildPropsTemplate = [xml](Get-Content $PropertiesPath);

# validate version prefix is in format Major.Minor.Patch
if ($directoryBuildPropsTemplate.SelectSingleNode("/Project/PropertyGroup/VersionPrefix") -eq $null)
{
    throw "Expected a node at /Project/PropertyGroup/VersionPrefix in `$PropertiesPath"
}
$versionPrefixParts = $directoryBuildPropsTemplate.SelectSingleNode("/Project/PropertyGroup/VersionPrefix").InnerText -Split "\."
if ($versionPrefixParts.Length -ne 3)
{
    throw "Expected the node value at /Project/PropertyGroup/VersionPrefix to be in the form Major.Minor.Patch"
}

# generate a build/package suffix by using the value specified in template file or by branch name
[string]$versionSuffix
$versionSuffixNode = $directoryBuildPropsTemplate.SelectSingleNode("/Project/PropertyGroup/VersionSuffix")
if ($versionSuffixNode -eq $null)
{
    if ($UseBranchNameInPackageSuffixWhenNotSpecified -and $BranchName -ne $PublicReleaseBranchName)
    {
        # a branch name of issue/#499 will become a version suffix of issue-499
        $versionSuffix = ([System.Text.RegularExpressions.Regex]::new("[^a-zA-Z0-9]")).Replace($BranchName, "-")
        $versionSuffix = ([System.Text.RegularExpressions.Regex]::new("--")).Replace($versionSuffix, "-")
    }
}
else
{
    $versionSuffix = $versionSuffixNode.InnerText
}

# create an assembly version, which provides build and revision numbers
try
{
    $version = New-AssemblyVersion `
       -Major $versionPrefixParts[0] `
       -Minor $versionPrefixParts[1] `
       -Patch $versionPrefixParts[2] `
       -Suffix $versionSuffix
}
catch
{
    Write-Host $_
    throw
}

# rewrite the props file with additional data based on assembly version and script parameters
try
{
    $props = New-DirectoryBuildPropsFile `
       -OutputPath $PropertiesPath `
       -AssemblyVersion $version `
       -IncludeBuildNumberPartsInPackageVersion ($BranchName -ne $PublicReleaseBranchName)

	$props.ReplaceVersionPrefixInDirectoryBuildPropsFile()
}
catch
{
    Write-Host $_
    throw
}

Write-Host "Restoring packages for" $SolutionPath
nuget restore $SolutionPath -PackagesDirectory .\packages

Write-Host "Building solution" $SolutionPath
dotnet build $SolutionPath --configuration $Configuration

Write-Host "Creating NuGet packages for " $SolutionPath
dotnet pack $SolutionPath --output $NuGetOutputPath --configuration $Configuration

Write-Host "Build complete for" $SolutionPath
