Set-StrictMode -Version Latest

class Project
{
    [ValidateNotNullOrEmpty()][string]$ProjectPath
    [string]$AssemblyInfoPath
    [string]$CompanyName
    [string]$ProductName
    [bool]$IsPackable
    [string]$Id
    [string]$Title
    [string]$Authors
    [bool]$RequireLicenseAcceptance
    [string]$LicenseType
    [string]$ProjectUrl
    [string]$Description
    [string]$ReleaseNotes
    [string]$RepositoryUrl
    [string[]]$Tags
    [string]$ToolCommandName
    
    Project(
        [string]$ProjectPath,
        [string]$CompanyName,
        [PSObject]$Configuration
    )
    {
        $csprojDirectory = Split-Path (Resolve-Path -Path (Join-Path -Path (Resolve-Path -Path $pwd.Path) -ChildPath $ProjectPath)) -Parent
        if (!(Test-Path -Path $csprojDirectory -PathType Container))
        {
            throw "'$ProjectPath' is not a valid file path."
        }
        $this.ProjectPath = Join-Path -Path $csprojDirectory -ChildPath (Split-Path $ProjectPath -Leaf)

        $this.CompanyName = $CompanyName
        $this.ProductName = $Configuration.productName
        if ((Get-Member -InputObject $Configuration -Name "NuGet" -MemberType Properties) -and $Configuration.nuGet -ne $null)
        {
            $this.IsPackable = $true
            if(Get-Member -InputObject $Configuration.nuGet -Name "Id" -MemberType Properties)
            {
                $this.Id = $Configuration.nuGet.id
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "Title" -MemberType Properties)
            {
                $this.Title = $Configuration.nuGet.title
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "Authors" -MemberType Properties)
            {
                $this.Authors = $Configuration.nuGet.authors
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "RequireLicenseAcceptance" -MemberType Properties)
            {
                $this.RequireLicenseAcceptance = $Configuration.nuGet.requireLicenseAcceptance -eq $true
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "LicenseType" -MemberType Properties)
            {
                $this.LicenseType = $Configuration.nuGet.LicenseType
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "ProjectUrl" -MemberType Properties)
            {
                $this.ProjectUrl = $Configuration.nuGet.ProjectUrl
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "Description" -MemberType Properties)
            {
                $this.Description = $Configuration.nuGet.Description
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "ReleaseNotes" -MemberType Properties)
            {
                $this.ReleaseNotes = $Configuration.nuGet.ReleaseNotes
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "RepositoryUrl" -MemberType Properties)
            {
                $this.RepositoryUrl = $Configuration.nuGet.RepositoryUrl
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "Tags" -MemberType Properties)
            {
                $this.Tags = $Configuration.nuGet.Tags
            }
            if(Get-Member -InputObject $Configuration.nuGet -Name "ToolCommandName" -MemberType Properties)
            {
                $this.ToolCommandName = $Configuration.nuGet.ToolCommandName
            }
        }

        $this.AssemblyInfoPath = Join-Path -Path $csprojDirectory -ChildPath "Properties" -AdditionalChildPath "AssemblyInfo.cs"
    }

    [System.Collections.Generic.List[string]] GetProjectDependencies()
    {
        $dependencies = [System.Collections.Generic.List[string]]::new()
        $this._DiscoverProjectDependencies($this.ProjectPath, $dependencies)
        return $dependencies
    }

    [System.Collections.Generic.List[NuGetDependency]] GetNuGetDependencies()
    {
        $dependencies = [System.Collections.Generic.List[NuGetDependency]]::new()
        _Discover-NuGet-Dependencies($this.ProjectPath, $dependencies)
        return $dependencies
    }

    [void] hidden _DiscoverProjectDependencies([string] $csprojPath, [System.Collections.Generic.List[string]] $dependencies)
    {
        # for any referenced projects, recursively add dependencies to any project references it has
        foreach ($ConfigurationReference in (Select-Xml -Path $csprojPath -XPath "/Project/ItemGroup/ProjectReference" | Select-Object -ExpandProperty Node))
        {
            # path to the project reference
            $referencedCSProjectPath = $ConfigurationReference.GetAttribute("Include")

            $dependencies.Add($referencedCSProjectPath)

            # discover/push directory of current .csproj file
            $currentCSProjectDirectory = (Get-Item $csprojPath).Directory
            Push-Location -Path $currentCSProjectDirectory
            $referencedCSProjectPath = (Resolve-Path -Path $referencedCSProjectPath)
            $this._DiscoverProjectDependencies($referencedCSProjectPath, $dependencies)

            Pop-Location
        }
    }

    [void] hidden _DiscoverNuGetDependencies([string] $csprojPath, [System.Collections.Generic.List[NuGetDependency]] $dependencies)
    {
        # find all package references and add those to dependencies
        foreach ($packageReference in (Select-Xml -Path $csprojPath -XPath "/Project/ItemGroup/PackageReference" | Select-Object -ExpandProperty Node))
        {
            $include = $packageReference.GetAttribute("Include")
            $version = $packageReference.GetAttribute("Version")
            if (!($Dependencies.ContainsKey($include)))
            {
                Write-Host ("Adding dependency {0} (version {1})" -f $include, $version)
                $dependencies.Add([NuGetDependency]::new($include, $version))
            }
            elseif ($dependencies[$include] -ne $version)
            {
                throw ("Dependency has conflicting versions for {0}, depencies has {1}, trying to add {2}" -f $include, $dependencies[$include], $version)
            }
        }
    }
}

class NuGetDependency
{
    [ValidateNotNullOrEmpty()][string]$Id
    [ValidateNotNullOrEmpty()][string]$Version

    NuGetDependency(
        [string]$Id,
        [string]$Version
    )
    {
        $this.Id = $Id
        $this.Version = $Version
    }
}

function New-Project()
{
    param
    (
        [string]$ProjectPath,
        [string]$CompanyName,
        [PSObject]$Configuration
    )

    return [Project]::new($ProjectPath, $CompanyName, $Configuration)
}

function Get-ProjectDependencies()
{
    param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [Project]$Project
    )

    return $Project.GetProjectDependencies()
}

function Get-NuGetDependencies()
{
    param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [Project]$Configuration
    )

    return $Project.GetNuGetDependencies()
}

function New-AssemblyInfoFile()
{
    param
    (
        [Parameter(ValueFromPipelineByPropertyName)]
        [Project]$Project,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [AssemblyVersion]$AssemblyVersion,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BranchName,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CommitSHA,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BuildIdentifier,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CompanyName
    )

    New-Item -Value "using System.Reflection;" -Path $Project.AssemblyInfoPath -ItemType "file" -Force | Out-Null
    Add-Content -Value (([Environment]::NewLine)) -Path $Project.AssemblyInfoPath

    # msdocs (https://docs.microsoft.com/en-us/dotnet/standard/assembly/versioning): "The assembly's version number, which, together with the assembly name and culture 
    # information, is part of the assembly's identity. This number is used by the runtime to enforce version policy and plays a key part in the type resolution process at run time."
    # AssemblyVersion does not display in the Details tab of assembly properties, nor is it used by "nuget pack"
    Add-Content -Value $AssemblyVersion.ToAssemblyVersionAttribute() -Path $Project.AssemblyInfoPath

    # AssemblyFileVersion displays as the "File version" in Details tab of assembly properties
    Add-Content -Value $AssemblyVersion.ToAssemblyFileVersionAttribute() -Path $Project.AssemblyInfoPath

    # msdocs (https://docs.microsoft.com/en-us/dotnet/standard/assembly/versioning): "The informational version is a string that attaches additional version information to an 
    # assembly for informational purposes only; this information is not used at run time."
    # AssemblyInformationalVersion displays as the "Product version" in Details tab of assembly properties, it is also the version NuGet uses in "nuget pack"
    Add-Content -Value $AssemblyVersion.ToAssemblyInformationalVersionAttribute() -Path $Project.AssemblyInfoPath

    Add-Content -Value ("[assembly: AssemblyConfiguration(""Branch:{0}; SHA:{1}, BuildIdentifier:{2}, Date:{3}"")]" -f $BranchName, $CommitSHA, $BuildIdentifier, ($AssemblyVersion.CurrentUtcDate.ToString("g"))) -Path $Project.AssemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyProduct(""{0}"")]" -f $Project.ProductName) -Path $Project.AssemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyCompany(""{0}"")]" -f $Project.CompanyName) -Path $Project.AssemblyInfoPath
    Add-Content -Value ("[assembly: AssemblyCopyright(""Copyright {0} {1}"")]" -f $(Get-Date).year, $Project.CompanyName) -Path $Project.AssemblyInfoPath
    
    if ($Project.IsPackable)
    {
        if (!([string]::IsNullOrWhitespace($Project.Title)))
        {
            Add-Content -Value ("[assembly: AssemblyTitle(""{0}"")]" -f $Project.Title) -Path $Project.AssemblyInfoPath
        }
        if (!([string]::IsNullOrWhitespace($Project.Description)))
        {
            Add-Content -Value ("[assembly: AssemblyDescription(""{0}"")]" -f $Project.Description) -Path $Project.AssemblyInfoPath
        }
    }
}

function New-BuildPropsFile()
{
    param
    (
        [Parameter(ValueFromPipelineByPropertyName)]
        [Project]$Project,
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$CompanyName
    )

    $dependencies = $Project.GetProjectDependencies()    

    # discover/push directory of current csproj path
    $csprojFilePath = (Resolve-Path -Path $Project.ProjectPath)
    $buildPropsFilePath = Split-Path $csprojFilePath -Parent
    $buildPropsFilePath = Join-Path -Path $buildPropsFilePath -ChildPath "Directory.Build.props"
    $file = New-Item -Path $buildPropsFilePath -ItemType "file" -Force
    
    $props = [System.Xml.XmlTextWriter]::new($file, $null)
    $props.Formatting = "Indented"
    $props.Indentation = 1
    $props.IndentChar = "`t"
    $props.WriteStartDocument()

    $props.WriteStartElement("Project")
    $props.WriteStartElement("PropertyGroup")
    $props.WriteElementString("GenerateAssemblyVersionAttribute", "false")
    $props.WriteElementString("IsPackable", ($Project.IsPackable ? "true" : "false"))

    if ($Project.IsPackable)
    {
        [System.Collections.Generic.List[string]]$dependencies = $Project.GetProjectDependencies()
        if ($dependencies.Count -gt 0)
        {
            $props.WriteElementString("TargetsForTfmSpecificBuildOutput", "`$(TargetsForTfmSpecificBuildOutput);PackProjectReferences")
        }

        $props.WriteElementString("Id", $Project.Id)
        $props.WriteElementString("Title", $Project.Title)
        $props.WriteElementString("Authors", $Project.Authors)
        $props.WriteElementString("RequireLicenseAcceptance", $Project.RequireLicenseAcceptance ? "true" : "false")    
        $props.WriteElementString("PackageLicenseExpression", $Project.LicenseType)
        $props.WriteElementString("ProjectUrl", $Project.ProjectUrl)
        $props.WriteElementString("Description", $Project.Description)
        $props.WriteElementString("ReleaseNotes", $Project.ReleaseNotes)
        $props.WriteElementString("Copyright",  ("Copyright {0} {1}" -f $(Get-Date).year, $CompanyName))
        if (($Project.Tags -ne $null) -and ($Project.Tags.Length -gt 0))
        {
            $props.WriteElementString("Tags", ([string]::Join(",", $Project.Tags)))
        }
        $props.WriteElementString("RepositoryUrl", $Project.RepositoryUrl)
        if (!([string]::IsNullOrWhitespace($Project.ToolCommandName)))
        {
            $props.WriteElementString("ToolCommandName", $Project.ToolCommandName)
            $props.WriteElementString("PackAsTool", "true")
        }
    }
    else
    {
        Write-Host ("Skipping creating NuGet specific elements/attributes in Directory.Build.props file for {0} as it is not packable." -f $Project.ProjectPath)
    }

    $props.WriteEndElement() # /PropertyGroup
    $props.WriteEndElement() # /Project
    $props.Flush()
    $props.Close()
}

function New-BuildTargetsFile()
{
    param
    (
        [Parameter(ValueFromPipelineByPropertyName)]
        [Project]$Project
    )

    $dependencies = $Project.GetProjectDependencies()
    if ($dependencies.Count -eq 0)
    {
        Write-Host "0 project dependencies discovered, not creating a Directory.Build.targets file for " $Project.ProjectPath
        return
    }
    else
    {
        Write-Host ("{0} project dependencies discovered, creating a Directory.Build.targets file for {1}" -f $dependencies.Count, $Project.ProjectPath)
    }

    # discover/push directory of current csproj path
    $csprojFilePath = (Resolve-Path -Path $Project.ProjectPath)
    $targetsFilePath = Split-Path $csprojFilePath -Parent
    $targetsFilePath = Join-Path -Path $targetsFilePath -ChildPath "Directory.Build.targets"
    $file = New-Item -Path $targetsFilePath -ItemType "file" -Force
    
    $targets = [System.Xml.XmlTextWriter]::new($file, $null)
    $targets.Formatting = "Indented"
    $targets.Indentation = 1
    $targets.IndentChar = "`t"

    $targets.WriteStartDocument()
    $targets.WriteStartElement("Project")
    $targets.WriteStartElement("Target")
    $targets.WriteAttributeString("Name", "PackProjectReferences")    
    $targets.WriteStartElement("ItemGroup")
    $targets.WriteStartElement("BuildOutputInPackage")
    $targets.WriteAttributeString("Include", "`$(OutputPath)\*.dll")
    $targets.WriteEndElement() # /BuildOutputInPackage
    $targets.WriteEndElement() # /ItemGroup
    $targets.WriteEndElement() # /Target
    $targets.WriteEndElement() # /Project
    $targets.Flush()
    $targets.Close()
}

Export-ModuleMember -Function New-Project, Get-ProjectDependencies, Get-NuGetDependencies, New-AssemblyInfoFile, New-BuildPropsFile, New-BuildTargetsFile