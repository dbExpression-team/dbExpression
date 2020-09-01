Param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BranchName,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$CommitSHA,
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$VersionFilePath = "version.json"
    )

Write-Host "The branch name provided as input was: " $BranchName
Write-Host "The SHA provided as input was: " $CommitSHA

. .\GenerateVersion.ps1

# read configuration from file
$config = Get-Content $VersionFilePath | ConvertFrom-Json

foreach ($project in $config.projects) 
{
    $version = Generate-Version $BranchName $project.major $project.minor $project.nuGet.patch $project.nuGet.suffix

    $file = New-Item -Path $project.nuGet.nuSpecPath -ItemType "file" -Force
    
    $nuspec = New-Object System.Xml.XmlTextWriter($file, $null)
    $nuspec.Formatting = "Indented"
    $nuspec.Indentation = 1
    $nuspec.IndentChar = "`t"
    $nuspec.WriteStartDocument()

    $nuspec.WriteStartElement("package")

    $nuspec.WriteStartElement("metadata")

    $nuspec.WriteElementString("id", $project.nuGet.id)
    $nuspec.WriteElementString("version", $version.AssemblyInformationalVersion)
    $nuspec.WriteElementString("title", $project.nuGet.title)
    $nuspec.WriteElementString("authors", $project.nuGet.authors)
    $nuspec.WriteElementString("requireLicenseAcceptance", "false")
    
    $nuspec.WriteStartElement("license")
    $nuspec.WriteAttributeString("type", "expression")
    $nuspec.WriteString($project.nuGet.licenseType)
    $nuspec.WriteEndElement()
    $nuspec.WriteElementString("projectUrl", $project.nuGet.projectUrl)
    $nuspec.WriteElementString("description", $project.nuGet.description)
    $nuspec.WriteElementString("releaseNotes", $project.nuGet.releaseNotes)
    $nuspec.WriteElementString("copyright",  ("Copyright {0} {1}" -f $(Get-Date).year, $config.companyName))

    if (($project.nuGet.tags -ne $null) -and ($project.nuGet.tags.Length -gt 0))
    {
        $nuspec.WriteElementString("tags", ([string]::Join(",", $project.nuGet.tags)))
    }

    $nuspec.WriteStartElement("repository")
    $nuspec.WriteAttributeString("type", "git")
    $nuspec.WriteAttributeString("url", $project.nuGet.projectUrl)
    $nuspec.WriteAttributeString("branch", $BranchName)
    $nuspec.WriteAttributeString("commit", $CommitSHA)
    $nuspec.WriteEndElement()

    $nuspec.WriteEndElement()

    $nuspec.WriteEndElement()

    $nuspec.Flush()
    $nuspec.Close()
}