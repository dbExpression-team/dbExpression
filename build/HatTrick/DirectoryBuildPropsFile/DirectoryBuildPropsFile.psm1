using module ..\AssemblyVersion\AssemblyVersion.psm1
Set-StrictMode -Version Latest

class DirectoryBuildPropsFile
{
    [ValidateNotNullOrEmpty()][string]$OutputPath
    [ValidateNotNullOrEmpty()][string]$Configuration
    [string]$BranchName
    [string]$CommitSHA
    [string]$BuildIdentifier
    [AssemblyVersion]$AssemblyVersion
    [boolean]$IncludeBuildNumberPartsInPackageVersion

    DirectoryBuildPropsFile(
        [string]$OutputPath,
        [string]$Configuration,
        [string]$BranchName,
        [string]$CommitSHA,
        [string]$BuildIdentifier,
        [AssemblyVersion]$AssemblyVersion,
        [boolean]$IncludeBuildNumberPartsInPackageVersion
    )
    {
        $this.OutputPath = $OutputPath
        $this.Configuration = $Configuration
        $this.BranchName = $BranchName
        $this.CommitSHA = $CommitSHA
        $this.BuildIdentifier = $BuildIdentifier
        $this.AssemblyVersion = $AssemblyVersion
        $this.IncludeBuildNumberPartsInPackageVersion = $IncludeBuildNumberPartsInPackageVersion
    }

    [void] RewriteDirectoryBuildPropsFile()
    {
        $props = [System.Xml.XmlTextWriter]::new((Resolve-Path -Path $this.OutputPath), $null)
        $props.Formatting = "Indented"
        $props.Indentation = 1
        $props.IndentChar = "`t"
        $props.WriteStartDocument()
        $props.WriteStartElement("Project")
        $props.WriteStartElement("PropertyGroup")
        $props.WriteElementString("Version", $this.AssemblyVersion.AssemblyVersion)
        $props.WriteElementString("GenerateAssemblyConfigurationAttribute", "false")
        if ($this.IncludeBuildNumberPartsInPackageVersion)
        {
            $props.WriteElementString("InformationalVersion", ("{0}.{1}.{2}-{3}{4}-{5}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Build, $this.AssemblyVersion.Revision, $this.AssemblyVersion.Suffix))
            $props.WriteElementString("PackageVersion", ("{0}.{1}.{2}-{3}{4}-{5}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Build, $this.AssemblyVersion.Revision, $this.AssemblyVersion.Suffix))
        }
        else
        {
            $props.WriteElementString("InformationalVersion", ("{0}.{1}.{2}-{3}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Suffix))
            $props.WriteElementString("PackageVersion", ("{0}.{1}.{2}-{3}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Suffix))
        }

        $props.WriteEndElement() # /PropertyGroup

        $props.WriteStartElement("ItemGroup")
        $props.WriteStartElement("AssemblyAttribute")
        $props.WriteAttributeString("Include", "System.Reflection.AssemblyConfigurationAttribute")
        $props.WriteElementString("_Parameter1", ("Branch:{0}; SHA:{1}, BuildIdentifier:{2}, Date:{3}, Configuration:{4}" -f $this.BranchName, $this.CommitSHA, $this.BuildIdentifier, ($this.AssemblyVersion.CurrentUtcDate.ToString("g")), $this.Configuration))
        $props.WriteEndElement() # /AssemblyAttribute
        $props.WriteEndElement() # /ItemGroup

        $props.WriteEndElement() # /Project
        $props.Flush()
        $props.Close()
    }
}

function New-DirectoryBuildPropsFile()
{
    param
    (
        [string]$OutputPath,
        [string]$Configuration,
        [string]$BranchName,
        [string]$CommitSHA,
        [string]$BuildIdentifier,
        [AssemblyVersion]$AssemblyVersion,
        [boolean]$IncludeBuildNumberPartsInPackageVersion
    )

    return [DirectoryBuildPropsFile]::new($OutputPath, $Configuration, $BranchName, $CommitSHA, $BuildIdentifier, $AssemblyVersion, $IncludeBuildNumberPartsInPackageVersion)
}

Export-ModuleMember -Function New-DirectoryBuildPropsFile, RewriteDirectoryBuildPropsFile