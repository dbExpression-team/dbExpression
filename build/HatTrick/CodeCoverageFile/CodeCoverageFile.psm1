Set-StrictMode -Version Latest

class CodeCoverageFile
{
    [ValidateNotNullOrEmpty()][string]$CodeCoverageFilePath
    [ValidateNotNullOrEmpty()][string]$PathToSourceFiles
    [ValidateNotNullOrEmpty()][string]$XPathToSourceNode

    CodeCoverageFile(
        [string]$CodeCoverageFilePath,
        [string]$PathToSourceFiles,
        [string]$XPathToSourceNode
    )
    {
        $this.CodeCoverageFilePath = $CodeCoverageFilePath
        $this.PathToSourceFiles = $PathToSourceFiles
        $this.XPathToSourceNode = $XPathToSourceNode    
    }
	
	[void] ReplaceSourceLocation()
    {
		$xml = New-Object Xml
		try
		{
			$xml.Load($this.CodeCoverageFilePath)
		}
		catch [System.IO.FileNotFoundException]
		{
			"Cannot load xml as the file was not found:" + $this.CodeCoverageFilePath
		}
	
		$needSave = $false;
		foreach ($node in $xml.SelectNodes($this.XPathToSourceNode)) 
		{
			if (!$node.InnerText.StartsWith($this.PathToSourceFiles))
			{
				$node.InnerText = $this.PathToSourceFiles
				$needSave = $true;
			}                
		}
		if ($needSave -eq $true)
		{
			$xml.Save($this.CodeCoverageFilePath)
			$needSave = $false
		}
    }
}

function New-CodeCoverageFile()
{
    param
    (
        [string]$CodeCoverageFilePath,
        [string]$PathToSourceFiles,
        [string]$XPathToSourceNode
    )

    return [CodeCoverageFile]::new($CodeCoverageFilePath, $PathToSourceFiles, $XPathToSourceNode)
}

Export-ModuleMember -Function New-CodeCoverageFile