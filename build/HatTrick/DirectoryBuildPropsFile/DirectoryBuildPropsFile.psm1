using module ..\AssemblyVersion\AssemblyVersion.psm1
Set-StrictMode -Version Latest

class DirectoryBuildPropsFile
{
    [ValidateNotNullOrEmpty()][string]$OutputPath
    [AssemblyVersion]$AssemblyVersion
    [boolean]$IncludeBuildNumberPartsInPackageVersion

    DirectoryBuildPropsFile(
        [string]$OutputPath,
        [AssemblyVersion]$AssemblyVersion,
        [boolean]$IncludeBuildNumberPartsInPackageVersion
    )
    {
        $this.OutputPath = $OutputPath
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
        [AssemblyVersion]$AssemblyVersion,
        [boolean]$IncludeBuildNumberPartsInPackageVersion
    )

    return [DirectoryBuildPropsFile]::new($OutputPath, $AssemblyVersion, $IncludeBuildNumberPartsInPackageVersion)
}

Export-ModuleMember -Function New-DirectoryBuildPropsFile, RewriteDirectoryBuildPropsFile