Set-StrictMode -Version Latest

class AssemblyVersion
{
    [ValidateNotNullOrEmpty()][string]$Major
    [ValidateNotNullOrEmpty()][string]$Minor
    [string]$Patch
    [string]$Suffix
    [string]$Build
    [string]$Revision
    [DateTime]$CurrentUtcDate

    [string]$AssemblyVersion
    [string]$AssemblyInformationalVersion

    AssemblyVersion(
        [string]$Major,
        [string]$Minor,
        [string]$Patch,
        [string]$Suffix,
        [DateTime]$CurrentUtcDate
    )
    {
        $this.Major = $Major
        $this.Minor = $Minor
        $this.Patch = $Patch
        $this.Suffix = $Suffix
        $this.CurrentUtcDate = $CurrentUtcDate

        # generate build (max value of [Int16] 32768), use visual studio style of number of days since Jan. 1, 2000
        $this.Build = [int](New-TimeSpan -Start (Get-Date -Date "2000-01-01 00:00:00Z") -End ($this.CurrentUtcDate)).TotalDays 
        
        # generate revision by using the number of seconds into the current day (must divide by 2 as the max value for revision is 65534)
        $this.Revision = [int]((New-TimeSpan -Start (New-Object "System.DateTime" -ArgumentList $this.CurrentUtcDate.Year, $this.CurrentUtcDate.Month, $this.CurrentUtcDate.Day) -End $this.CurrentUtcDate).TotalSeconds / 2)

        $this.AssemblyVersion = "{0}.{1}.{2}.{3}" -f $this.Major, $this.Minor, $this.Build, $this.Revision
        
        if ([string]::IsNullOrEmpty($this.Patch))
        {
            $this.AssemblyInformationalVersion = $this.AssemblyVersion
        }
        else
        {
            $version = "{0}.{1}.{2}" -f $this.Major, $this.Minor, $this.Patch
            if (![string]::IsNullOrEmpty($this.Suffix))
            {
                $version = "{0}-{1}" -f $version, $this.Suffix
            }      
            $this.AssemblyInformationalVersion = $version
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
        if ([string]::IsNullOrEmpty($this.Patch))
        {
            return "[assembly: AssemblyInformationalVersion(""{0}"")]" -f $this.AssemblyVersion
        }

        $nugetVersion = "{0}.{1}.{2}" -f $this.Major, $this.Minor, $this.Patch
        if (![string]::IsNullOrEmpty($this.Suffix))
        {
            $nugetVersion = "{0}-{1}" -f $nugetVersion, $this.Suffix
        }        
        return "[assembly: AssemblyInformationalVersion(""{0}"")]" -f $nugetVersion
    }
}

function New-AssemblyVersion()
{
    param
    (
        [string]$Major,
        [string]$Minor,
        [string]$Patch,
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

Export-ModuleMember -Function New-AssemblyVersion, Get-AssemblyVersionAttribute, Get-AssemblyFileVersionAttribute, Get-AssemblyInformationalVersionAttribute