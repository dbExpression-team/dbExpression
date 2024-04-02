using module ..\AssemblyVersion\AssemblyVersion.psm1
Set-StrictMode -Version Latest

class DirectoryBuildPropsFile
{
    [ValidateNotNullOrEmpty()][string]$OutputPath
    [AssemblyVersion]$AssemblyVersion
	[string]$CommitSHA
    
    DirectoryBuildPropsFile(
        [string]$OutputPath,
        [AssemblyVersion]$AssemblyVersion,
		[string]$CommitSHA
    )
    {
        $this.OutputPath = $OutputPath
        $this.AssemblyVersion = $AssemblyVersion
		$this.CommitSHA = $CommitSHA
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

		# set the version to the AssemblyVersion
		$versionNode.InnerText = $this.AssemblyVersion.AssemblyVersion
		# set the informational version to the AssemblyInformationalVersion
		$informationalVersionNode.InnerText = $this.AssemblyVersion.AssemblyInformationalVersion
		
		# construct a new version for packaging
		$version = "{0}.{1}.{2}" -f $this.AssemblyVersion.Major, $this.AssemblyVersion.Minor, $this.AssemblyVersion.Patch
		if (![string]::IsNullOrWhiteSpace($this.AssemblyVersion.Suffix))
		{
			$version = "{0}-{1}" -f $version, $this.AssemblyVersion.Suffix
		} 
        if (![string]::IsNullOrWhiteSpace($this.CommitSHA))
		{
			$version = "{0}-{1}" -f $version, $this.CommitSHA.Substring(0,7)
		} 
		$packageVersionNode.InnerText = $version
		
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
		[string]$CommitSHA        
    )

    return [DirectoryBuildPropsFile]::new($OutputPath, $AssemblyVersion, $CommitSHA)
}

Export-ModuleMember -Function New-DirectoryBuildPropsFile