function Generate-Version()
{
    Param
        (
            [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
            [string]$BranchName,
            [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
            [short]$MajorVersion,
            [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
            [short]$MinorVersion,
            [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
            [string]$NuGetPatch,
            [Parameter(ValueFromPipelineByPropertyName)]
            [string]$NuGetSuffix
        )

    $currentUtcDate = (Get-Date).ToUniversalTime()

    # generate build (max value of [Int16] 32768), use visual studio style of number of days since Jan. 1, 2000
    $build = [int](New-TimeSpan -Start (Get-Date -Date "2000-01-01 00:00:00Z") -End ($currentUtcDate)).TotalDays
    # generate revision by using the number of seconds into the current day (must divide by 2 as the max value for revision is 65534)
    $revision = [int]((New-TimeSpan -Start (New-Object "System.DateTime" -ArgumentList $currentUtcDate.Year, $currentUtcDate.Month, $currentUtcDate.Day) -End $currentUtcDate).TotalSeconds / 2)

    $nugetVersion = "{0}.{1}.{2}" -f $MajorVersion, $MinorVersion, $NuGetPatch

    if (![string]::IsNullOrEmpty($NuGetSuffix))
    {
        $nugetVersion = "{0}-{1}" -f $nugetVersion, $NuGetSuffix
    }
    elseif ($BranchName -like 'hotfix*')
    {
        $nugetVersion = "{0}-hotfix" -f $nugetVersion
    }

    $version = New-Object -TypeName Version
    $version | Add-Member -MemberType NoteProperty -Name AssemblyVersion -Value ("{0}.{1}.{2}.{3}" -f $MajorVersion, $MinorVersion, $build, $revision)
    $version | Add-Member -MemberType NoteProperty -Name AssemblyFileVersion -Value $version.AssemblyVersion
    $version | Add-Member -MemberType NoteProperty -Name AssemblyInformationalVersion -Value $nugetVersion

    return $version
}