Param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BranchName,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CommitSHA,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BuildIdentifier,
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$VersionFilePath = "version.json"
    )

Write-Host "The branch name provided as input was: " $BranchName
Write-Host "The SHA provided as input was: " $CommitSHA

. .\GenerateVersion.ps1

# read configuration from file
$config = Get-Content $VersionFilePath | ConvertFrom-Json

foreach ($project in $config.projects) 
{
    $version = Generate-Version $BranchName $project.major $project.minor $project.nuGet.patch $project.nuGet.suffix

    Write-Host ("NuGet version: {0}" -f $version)

    New-Item -Value "using System.Reflection;" -Path $project.assemblyInfoPath -ItemType "file" -Force
    Add-Content -Value (([Environment]::NewLine)) -Path $project.assemblyInfoPath

    # msdocs (https://docs.microsoft.com/en-us/dotnet/standard/assembly/versioning): "The assembly's version number, which, together with the assembly name and culture 
    # information, is part of the assembly's identity. This number is used by the runtime to enforce version policy and plays a key part in the type resolution process at run time."
    # AssemblyVersion does not display in the Details tab of assembly properties, nor is it used by "nuget pack"
    Add-Content -Value ("[assembly: AssemblyVersion(""{0}"")]" -f $version.AssemblyVersion) -Path $project.assemblyInfoPath

    # AssemblyFileVersion displays as the "File version" in Details tab of assembly properties
    Add-Content -Value ("[assembly: AssemblyFileVersion(""{0}"")]" -f $version.AssemblyFileVersion) -Path $project.assemblyInfoPath

    # msdocs (https://docs.microsoft.com/en-us/dotnet/standard/assembly/versioning): "The informational version is a string that attaches additional version information to an 
    # assembly for informational purposes only; this information is not used at run time."
    # AssemblyInformationalVersion displays as the "Product version" in Details tab of assembly properties, it is also the version NuGet uses in "nuget pack"
    Add-Content -Value ("[assembly: AssemblyInformationalVersion(""{0}"")]" -f $version.AssemblyInformationalVersion) -Path $project.assemblyInfoPath

    Add-Content -Value ("[assembly: AssemblyConfiguration(""Branch:{0}; SHA:{1}, BuildIdentifier:{2}, Date:{3}"")]" -f $BranchName, $CommitSHA, $BuildIdentifier, ((Get-Date).ToString("g"))) -Path $project.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyProduct(""{0}"")]" -f $project.productName) -Path $project.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyCompany(""{0}"")]" -f $config.companyName) -Path $project.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyCopyright(""Copyright {0} {1}"")]" -f $(Get-Date).year, $config.companyName) -Path $project.assemblyInfoPath
}