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
	
	[void] ReplaceVersionPrefixInDirectoryBuildPropsFile()
    {
		$path = Resolve-Path -Path $this.OutputPath
		$xml = New-Object Xml
		$xml.Load($path)
		
		$propertyGroupNode = $xml.SelectSingleNode("/Project/PropertyGroup")
		$versionPrefixNode = $propertyGroupNode.SelectSingleNode("VersionPrefix")
		if ($versionPrefixNode -ne $null)
		{
			$propertyGroupNode.RemoveChild($versionPrefixNode)
		}
		$versionNode = $xml.CreateElement("Version")
		$packageVersionNode = $xml.CreateElement("PackageVersion")
		$informationalVersionNode = $xml.CreateElement("InformationalVersion")

        if ($this.IncludeBuildNumberPartsInPackageVersion)
        {
            $versionNode.InnerText = ("{0}.{1}.{2}-{3}{4}-{5}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Build, $this.AssemblyVersion.Revision, $this.AssemblyVersion.Suffix)
            $packageVersionNode.InnerText = ("{0}.{1}.{2}-{3}{4}-{5}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Build, $this.AssemblyVersion.Revision, $this.AssemblyVersion.Suffix)
			$informationalVersionNode.InnerText = ("{0}.{1}.{2}-{3}{4}-{5}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Build, $this.AssemblyVersion.Revision, $this.AssemblyVersion.Suffix)
        }
        else
        {
            $versionNode.InnerText = ("{0}.{1}.{2}-{3}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Suffix)
            $packageVersionNode.InnerText = ("{0}.{1}.{2}-{3}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Suffix)
			$informationalVersionNode.InnerText = ("{0}.{1}.{2}-{3}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch, $this.AssemblyVersion.Suffix)
        }
		$propertyGroupNode.AppendChild($versionNode)
		$propertyGroupNode.AppendChild($packageVersionNode)
		$propertyGroupNode.AppendChild($informationalVersionNode)
		
		$xml.Save($path)
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