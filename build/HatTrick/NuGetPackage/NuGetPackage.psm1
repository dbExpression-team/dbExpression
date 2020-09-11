function _Remove-NuspecProjectReferenceNodes()
{
    param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$NuspecPath
    )

    Write-Host "NuspecPath parameter: " $NuspecPath

    # remove dependency node from nuspec file for assemblies that are in the "lib" folder

    $nupkgNoExtension = [System.IO.Path]::GetFileNameWithoutExtension($NuspecPath)
    $destination = Split-Path -Parent $NuspecPath

    [xml]$xml = (Get-Content $NuspecPath)
    $mgr = [System.Xml.XmlNamespaceManager]::new($xml.Psbase.NameTable)
    $mgr.AddNamespace("x", $xml.package.xmlns)

    foreach ($targetFramework in $xml.SelectNodes("/x:package/x:metadata/x:dependencies/x:group", $mgr))
    {
        $tfm = $targetFramework.GetAttribute("targetFramework");
        foreach ($dependency in $targetFramework.SelectNodes("//x:dependency", $mgr))
        {
            $id = $dependency.GetAttribute("id")
            $folder = $tfm.StartsWith(".") ? $tfm.Substring(1) : $tfm
            $dllPath = [System.IO.Path]::Combine($destination, "lib", $folder, $id + ".dll")
            Write-Host ("Removing project reference {0} from nuspec file {1}" -f ($id + ".dll"), $NuspecPath)
            if ((Get-Item $dllPath -ErrorAction SilentlyContinue))
            {
                $dependency.ParentNode.RemoveChild($dependency) | Out-Null
            }
        }
    }

    $xml.Save($NuspecPath)
}

function Remove-NuspecProjectReferenceNodes()
{
    Param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$Solution,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$Configuration,
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$Output,
        [switch]$SkipRemovalOfTemporaryFiles
    )

    Write-Host "Solution parameter: " $Solution
    Write-Host "Configuration parameter: " $Configuration
    Write-Host "Output parameter: " $Output

    $slnDirectory = Split-Path (Resolve-Path -Path (Join-Path -Path (Resolve-Path -Path $pwd.Path) -ChildPath $Solution)) -Parent
    if (!(Test-Path -Path $slnDirectory -PathType Container))
    {
        throw "'$Solution' is not a valid file path."
    }
    $slnDirectory = Join-Path -Path $slnDirectory -ChildPath (Split-Path $Solution -Leaf)

    $outputDirectory = Resolve-Path -Path (Join-Path -Path (Resolve-Path -Path $pwd.Path) -ChildPath $Output)
    if (!(Test-Path -Path $outputDirectory -PathType Container))
    {
        New-Item $outputDirectory | Out-Null
    }

    foreach ($nupkgFile in (Get-ChildItem $outputDirectory -Filter *.nupkg))
    {
        $nupkgNoExtension = [System.IO.Path]::GetFileNameWithoutExtension($nupkgFile)
        $destination = [System.IO.Path]::Combine((Split-Path -Parent $nupkgFile), $nupkgNoExtension)

        Expand-Archive -Path $nupkgFile -DestinationPath $destination -Force
    }

    Start-Sleep -Seconds 5

    foreach ($package in (Get-ChildItem $outputDirectory -Directory))
    {
        _Remove-NuspecProjectReferenceNodes (Get-ChildItem $package -Filter *.nuspec)
    }

    Start-Sleep -Seconds 5

    foreach ($nupkgFile in (Get-ChildItem $outputDirectory -Filter *.nupkg))
    {
        $nupkgFile = [System.IO.Path]::Combine((Get-Item $outputDirectory), $nupkgFile)
        $nupkgNoExtension = [System.IO.Path]::GetFileNameWithoutExtension($nupkgFile)
        $newItems = Get-ChildItem ([System.IO.Path]::Combine((Get-Item $outputDirectory), $nupkgNoExtension))
        Compress-Archive -Path $newItems -Update -DestinationPath $nupkgFile | Out-Null

        if (!($SkipRemovalOfTemporaryFiles))
        {
            Remove-Item ([System.IO.Path]::Combine((Get-Item $outputDirectory), $nupkgNoExtension)) -Recurse | Out-Null
        }
    }
}

Export-ModuleMember -Function Remove-NuspecProjectReferenceNodes
