using module .\HatTrick\CodeCoverageFiles\CodeCoverageFiles.psm1

param
    (
        # The semi-colon delimited list of file paths
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CodeCoverageFilePaths,

        # The full path to the source files.
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$PathToSourceFiles,

        # The xpath to the elements to replace
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$XPathToSourceNode = "/coverage/sources/source"
   )

Write-Host "CodeCoverageFilePaths parameter: " $CodeCoverageFilePaths
Write-Host "PathToSourceFiles parameter: " $PathToSourceFiles
Write-Host "XPathToSourceNode parameter: " $XPathToSourceNode

# create an code coverage files object
try
{
    $codeCoverageFiles = New-CodeCoverageFiles `
       -CodeCoverageFilePaths $CodeCoverageFilePaths `
       -PathToSourceFiles $PathToSourceFiles `
       -XPathToSourceNode $XPathToSourceNode
    
    $CodeCoverageFiles.ReplaceSourceLocation()
}
catch
{
    Write-Host $_
    throw
}
