using module .\HatTrick\CodeCoverageFile\CodeCoverageFile.psm1

param
    (
        # The semi-colon delimited list of file paths
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CodeCoverageFilePath,

        # The full path to the source files.
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$PathToSourceFiles,

        # The xpath to the elements to replace
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$XPathToSourceNode = "/coverage/sources/source"
   )

Write-Host "CodeCoverageFilePath parameter: " $CodeCoverageFilePath
Write-Host "PathToSourceFiles parameter: " $PathToSourceFiles
Write-Host "XPathToSourceNode parameter: " $XPathToSourceNode

# create an code coverage files object
try
{
    $codeCoverageFile = New-CodeCoverageFile `
       -CodeCoverageFilePath $CodeCoverageFilePath `
       -PathToSourceFiles $PathToSourceFiles `
       -XPathToSourceNode $XPathToSourceNode
    
    $codeCoverageFile.ReplaceSourceLocation()
}
catch
{
    Write-Host $_
    throw
}
