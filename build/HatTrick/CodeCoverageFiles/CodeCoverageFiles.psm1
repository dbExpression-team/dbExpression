Set-StrictMode -Version Latest

class CodeCoverageFiles
{
    [ValidateNotNullOrEmpty()][string]$CodeCoverageFilePaths
    [ValidateNotNullOrEmpty()][string]$PathToSourceFiles
    [ValidateNotNullOrEmpty()][string]$XPathToSourceNode

    CodeCoverageFiles(
        [string]$CodeCoverageFilePaths,
        [string]$PathToSourceFiles,
        [string]$XPathToSourceNode
    )
    {
        $this.CodeCoverageFilePaths = $CodeCoverageFilePaths
        $this.PathToSourceFiles = $PathToSourceFiles
        $this.XPathToSourceNode = $XPathToSourceNode    
    }
	
	[void] ReplaceSourceLocation()
    {
        $files = $this.CodeCoverageFilePaths -Split ";"
        foreach ($file in $files)
        {
		    $xml = New-Object Xml
            try
            {
		        $xml.Load($file)
            }
            catch [System.IO.FileNotFoundException]
            {
                "Cannot load xml as the file was not found:" + $file
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
                $xml.Save($file)
                $needSave = $false
            }
        }
    }
}

function New-CodeCoverageFiles()
{
    param
    (
        [string]$CodeCoverageFilePaths,
        [string]$PathToSourceFiles,
        [string]$XPathToSourceNode
    )

    return [CodeCoverageFiles]::new($CodeCoverageFilePaths, $PathToSourceFiles, $XPathToSourceNode)
}

Export-ModuleMember -Function New-CodeCoverageFiles