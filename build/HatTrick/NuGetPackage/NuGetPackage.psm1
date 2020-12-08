function _Remove-NuspecProjectReferenceNodes()
{
    param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$NuspecPath
    )

    # remove dependency node from nuspec file for assemblies that are in the "lib" folder

    $nupkgFileNameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($NuspecPath)
    $tempPath = Split-Path -Parent $NuspecPath

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
            $dllPath = [System.IO.Path]::Combine($tempPath, "lib", $folder, $id + ".dll")
            Write-Host ("[{0}]: Removing project reference {1} from nuspec file" -f $nupkgFileNameWithoutExtension, ($id + ".dll"))
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

    foreach ($nupkgFilePath in (Get-ChildItem $outputDirectory -Filter "*.*nupkg"))
    {
        $nupkgFileNameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($nupkgFilePath)
        $nupkgFileExtension = [System.IO.Path]::GetExtension($nupkgFilePath)
        $tempPath = [System.IO.Path]::Combine((Split-Path -Parent $nupkgFilePath), $nupkgFileNameWithoutExtension)
    
        # unzip the [s]nupkg file to a temporary folder (name of the package without the extension)
        Expand-Archive -Path $nupkgFilePath -DestinationPath $tempPath -Force

        Start-Sleep -Seconds 5
    
        # remove the original package file
        Remove-Item $nupkgFilePath

        if ($nupkgFileExtension -eq ".nupkg")
        {
            Write-Host ("[{0}]: Removing .pdb files from package" -f $nupkgFileNameWithoutExtension)
            Remove-Item -Path $tempPath -Recurse -Include "*.pdb" -Force
        }
        else
        {
            Write-Host ("[{0}]: Removing .dll files from package" -f $nupkgFileNameWithoutExtension)
            Remove-Item -Path $tempPath -Recurse -Include "*.dll" -Force
        }
        
        Write-Host ("[{0}]: Removing project references from .nuspec file" -f $nupkgFileNameWithoutExtension)
        _Remove-NuspecProjectReferenceNodes (Get-ChildItem $tempPath -Filter "*.nuspec")
        
        # build the path of corrected assets to re-zip to the original package name
        $newItems = Get-ChildItem ([System.IO.Path]::Combine((Get-Item $outputDirectory), $nupkgFileNameWithoutExtension))

        Compress-Archive -Path $newItems -DestinationPath $nupkgFilePath -Force | Out-Null
    
        if (!($SkipRemovalOfTemporaryFiles))
        {
            Remove-Item ([System.IO.Path]::Combine((Get-Item $outputDirectory), $nupkgFileNameWithoutExtension)) -Recurse | Out-Null
        }
    }
}

Export-ModuleMember -Function Remove-NuspecProjectReferenceNodes
