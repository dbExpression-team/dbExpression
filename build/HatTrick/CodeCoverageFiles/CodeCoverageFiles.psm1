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
		    $xml.Load($file)
		
            $needSave = $false;
		    foreach ($node in $xml.SelectNodes($XPathToSourceNode)) 
		    {
                if ($node.InnerText -ne $this.PathToSourceFiles)
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