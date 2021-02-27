Set-StrictMode -Version Latest

class AssemblyVersion
{
    [int]$Major
    [int]$Minor
    [int]$Patch
    [string]$Suffix
    [DateTime]$CurrentUtcDate

    [string]$AssemblyVersion
    [string]$AssemblyInformationalVersion
    [short]$Build
    [int]$Revision

    AssemblyVersion(
        [int]$Major,
        [int]$Minor,
        [int]$Patch,
        [string]$Suffix,
        [Nullable[DateTime]]$CurrentUtcDate
    )
    {
        $this.Major = $Major
        $this.Minor = $Minor
        $this.Patch = $Patch
        $this.Suffix = $Suffix

        if ($CurrentUtcDate -eq $null)
        {
            $this.CurrentUtcDate = (Get-Date).ToUniversalTime()
        }
        else
        {
            $this.CurrentUtcDate = $CurrentUtcDate
        }

        $this.Build = Get-BuildNumber($this.CurrentUtcDate)        
        $this.Revision = Get-RevisionNumber($this.CurrentUtcDate)

        $this.AssemblyVersion = "{0}.{1}.{2}.{3}" -f $this.Major, $this.Minor, $this.Build, $this.Revision
        
        $this.AssemblyInformationalVersion = $this.AssemblyVersion
        if (![string]::IsNullOrEmpty($this.Patch))
        {
            $this.AssemblyInformationalVersion = "{0}-{1}" -f $this.AssemblyVersion, $this.Suffix
       }
    }

    [string] ToAssemblyVersionAttribute()
    {
        return "[assembly: AssemblyVersion(""{0}"")]" -f $this.AssemblyVersion
    }

    [string] ToAssemblyFileVersionAttribute()
    {
        return "[assembly: AssemblyFileVersion(""{0}"")]" -f $this.AssemblyVersion
    }

    [string] ToAssemblyInformationalVersionAttribute()
    {
        return "[assembly: AssemblyInformationalVersion(""{0}"")]" -f $this.AssemblyInformationalVersion
    }
}

function New-AssemblyVersion()
{
    param
    (
        [int]$Major,
        [int]$Minor,
        [int]$Patch,
        [string]$Suffix,
        [DateTime]$CurrentUtcDate
    )

    return [AssemblyVersion]::new($Major, $Minor, $Patch, $Suffix, $CurrentUtcDate)
}

function Get-AssemblyVersionAttribute()
{
    param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [AssemblyVersion]$AssemblyVersion
    )

    return $AssemblyVersion.ToAssemblyVersionAttribute()
}

function Get-AssemblyFileVersionAttribute()
{
    param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [AssemblyVersion]$AssemblyVersion
    )

    return $AssemblyVersion.ToAssemblyFileVersionAttribute()
}

function Get-AssemblyInformationalVersionAttribute()
{
    param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [AssemblyVersion]$AssemblyVersion
    )

    return $AssemblyVersion.ToAssemblyInformationalVersionAttribute()
}

function Get-BuildNumber()
{
    param
    (
        [DateTime]$CurrentUtcDate
    )

    $this.CurrentUtcDate = $CurrentUtcDate
    
    if ($this.CurrentUtcDate -eq $null)
    {
        $this.CurrentUtcDate = (Get-Date).ToUniversalTime()
    }

    # generate build (max value of [Int16] 32768), use visual studio style of number of days since Jan. 1, 2000
    return [int](New-TimeSpan -Start (Get-Date -Date "2000-01-01 00:00:00Z") -End ($this.CurrentUtcDate)).TotalDays
}

function Get-RevisionNumber()
{
    param
    (
        [DateTime]$CurrentUtcDate
    )

    $this.CurrentUtcDate = $CurrentUtcDate
    
    if ($this.CurrentUtcDate -eq $null)
    {
        $this.CurrentUtcDate = (Get-Date).ToUniversalTime()
    }

    # generate revision by using the number of seconds into the current day (must divide by 2 as the max value for revision is 65534)
    return [int]((New-TimeSpan -Start (New-Object "System.DateTime" -ArgumentList $this.CurrentUtcDate.Year, $this.CurrentUtcDate.Month, $this.CurrentUtcDate.Day) -End $this.CurrentUtcDate).TotalSeconds / 2)
}

Export-ModuleMember -Function New-AssemblyVersion, Get-AssemblyVersionAttribute, Get-AssemblyFileVersionAttribute, Get-AssemblyInformationalVersionAttribute