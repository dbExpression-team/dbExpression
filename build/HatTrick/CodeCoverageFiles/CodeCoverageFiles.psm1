Set-StrictMode -Version Latest

class CodeCoverageFiles
{
    [ValidateNotNullOrEmpty()][string]$CodeCoverageFilePaths
	[ValidateNotNullOrEmpty()][string]$PathToSourceFiles

    CodeCoverageFiles(
        [string]$CodeCoverageFilePaths,
        [string]$PathToSourceFiles
    )
    {
        $this.CodeCoverageFilePaths = $CodeCoverageFilePaths
        $this.PathToSourceFiles = $PathToSourceFiles
    }
	
	[void] ReplaceSourceLocation()
    {
        $files = $this.CodeCoverageFilePaths -Split ";"
        foreach ($file in $files)
        {
		    $xml = New-Object Xml
		    $xml.Load($file)
		
            $needSave = $false;
		    foreach ($node in $xml.SelectNodes("/coverage/sources/source")) 
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
        [string]$PathToSourceFiles
    )

    return [CodeCoverageFiles]::new($CodeCoverageFilePaths, $PathToSourceFiles)
}

Export-ModuleMember -Function New-CodeCoverageFiles