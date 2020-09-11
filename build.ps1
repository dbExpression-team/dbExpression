using module .\build\HatTrick\Project\Project.psm1
using module .\build\HatTrick\AssemblyVersion\AssemblyVersion.psm1
using module .\build\HatTrick\NuGetPackage\NuGetPackage.psm1

Param
    (
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$Configuration = "Release",
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$BuildPropsFilePath = ".\build.props.json",
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BranchName,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CommitSHA,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BuildIdentifier,
        [switch]$SkipGenerationOfBuildFiles,
        [switch]$SkipGenerationOfAssembyInfoFiles,
        [switch]$SkipGenerationOfBuildPropFiles,
        [switch]$SkipGenerationOfBuildTargetFiles,
        [switch]$UseBranchNameAsVersionSuffixWhenNotSupplied
   )

Write-Host "VersionFilePath parameter: " $VersionFilePath

# read configuration from file
$config = Get-Content $BuildPropsFilePath | ConvertFrom-Json

[DateTime]$now = (Get-Date).ToUniversalTime()

if (!($SkipGenerationOfBuildFiles))
{
    foreach ($project in $config.Projects)
    {
        $suffix = $null
        if ((Get-Member -InputObject $project -Name "NuGet" -MemberType Properties) -and $project.nuGet -ne $null)
        {
            if(Get-Member -InputObject $project.nuGet -Name "Suffix" -MemberType Properties)
            {
                $suffix = $project.nuGet.suffix
            }
            elseif ($UseBranchNameAsVersionSuffixWhenNotSupplied -and $BranchName -ne "master")
            {
                $rgx = [System.Text.RegularExpressions.Regex]::new("[^a-zA-Z0-9 -]");
                $suffix = $rgx.Replace($BranchName, "-")
            }
        }

        $version = New-AssemblyVersion `
            -Major $project.major `
            -Minor $project.minor `
            -Patch ($project.nuGet -eq $null ? "" : $project.nuGet.patch) `
            -Suffix $suffix `
            -CurrentUtcDate $now
    
        $p = New-Project `
            -ProjectPath $project.csprojPath `
            -CompanyName $config.companyName `
            -Configuration $project
    
        if (!($SkipGenerationOfAssembyInfoFiles))
        {
            Write-Host "Creating AssemblyInfo.cs for" $p.ProjectPath
            New-AssemblyInfoFile -AssemblyVersion $version -BranchName $BranchName -CommitSHA $CommitSHA -BuildIdentifier $BuildIdentifier -CompanyName $config.companyName -Project $p
        }

        if (!($SkipGenerationOfBuildPropFiles))
        {
            Write-Host "Creating Directory.Build.props for" $p.ProjectPath
            New-BuildPropsFile -Project $p -CompanyName $config.companyName -AssemblyVersion $version
        }
     
        if (!($SkipGenerationOfBuildTargetFiles))
        {
            Write-Host "Creating Directory.Build.targets for" $p.ProjectPath
            New-BuildTargetsFile $p
        }
    }
}

Write-Host "Restoring packages for" $config.solutionPath
nuget restore $config.solutionPath -PackagesDirectory .\packages

Write-Host "Building solution" $config.solutionPath
dotnet build $config.solutionPath --configuration $Configuration

Write-Host "Creating NuGet packages for" $config.solutionPath
dotnet pack $config.solutionPath --output $config.nuGetPackageOutputPath --configuration $Configuration

Write-Host "Repairing packages for" $config.solutionPath
Remove-NuspecProjectReferenceNodes -Solution $config.solutionPath -Configuration $Configuration -Output $config.nuGetPackageOutputPath -SkipRemovalOfTemporaryFiles

Write-Host "Build complete for" $config.solutionPath
