Param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BranchName,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CommitSHA,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BuildIdentifier
    )

Write-Host "The branch name provided as input was: " $BranchName
Write-Host "The SHA provided as input was: " $CommitSHA

$currentUtcDate = (Get-Date).ToUniversalTime()

# read configuration from file
$config = Get-Content version.json | ConvertFrom-Json
# generate build (max value of [Int16] 32768), use visual studio style of number of days since Jan. 1, 2000
$build = [int](New-TimeSpan -Start (Get-Date -Date "2000-01-01 00:00:00Z") -End ($currentUtcDate)).TotalDays
# generate revision by using the number of seconds into the current day (must divide by 2 as the max value for revision is 65534)
$revision = [int]((New-TimeSpan -Start (New-Object "System.DateTime" -ArgumentList $currentUtcDate.Year, $currentUtcDate.Month, $currentUtcDate.Day) -End $currentUtcDate).TotalSeconds / 2)

Write-Host ("build: {0}; revision: {1}" -f $build, $revision)

foreach ($fileVersion in $config.projects) 
{
    New-Item -Value "using System.Reflection;" -Path $fileVersion.assemblyInfoPath -ItemType "file" -Force
    Add-Content -Value ("[assembly: AssemblyVersion(""{0}.{1}.{2}.{3}"")]" -f $fileVersion.Major, $fileVersion.Minor, $build, $revision) -Path $fileVersion.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyFileVersion(""{0}.{1}.{2}.{3}"")]" -f $fileVersion.Major, $fileVersion.Minor, $build, $revision) -Path $fileVersion.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyInformationalVersion(""{0}.{1}.{2}.{3}"")]" -f $fileVersion.Major, $fileVersion.Minor, $build, $revision) -Path $fileVersion.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyConfiguration(""Branch:{0}; SHA:{1}, BuildIdentifier:{2}, Date:{3}"")]" -f $BranchName, $CommitSHA, $BuildIdentifier, ($currentUtcDate.ToString("s"))) -Path $fileVersion.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyProduct(""{0}"")]" -f $fileVersion.ProductName) -Path $fileVersion.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyCompany(""{0}"")]" -f $fileVersion.CompanyName) -Path $fileVersion.assemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyCopyright(""Copyright {0} HatTrick Labs, LLC"")]" -f $currentUtcDate.year) -Path $fileVersion.assemblyInfoPath
}