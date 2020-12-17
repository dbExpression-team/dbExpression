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
            Write-Host ("[{0}]: Inspecting project reference {1} in nuspec file" -f $nupkgFileNameWithoutExtension, $id)
            $folder = ($tfm.StartsWith(".") ? $tfm.Substring(1) : $tfm).ToLower()
            $dllPath = [System.IO.Path]::Combine($tempPath, "lib", $folder, $id + ".dll")
            if ((Get-Item $dllPath -ErrorAction SilentlyContinue))
            {
                Write-Host ("[{0}]: Removing project reference {1} from nuspec file" -f $nupkgFileNameWithoutExtension, ($id + ".dll"))
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
        [string]$Output
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
        Write-Host ("Found nuget package {0}" -f $nupkgFilePath)
        $nupkgFileNameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($nupkgFilePath)
        $nupkgFileExtension = [System.IO.Path]::GetExtension($nupkgFilePath)
        $tempPath = [System.IO.Path]::Combine((Split-Path -Parent $nupkgFilePath), "tmp", $nupkgFileNameWithoutExtension)
    
        # unzip the [s]nupkg file to a temporary folder (name of the package without the extension)
        Write-Host ("Expanding package {0} to {1}" -f $nupkgFilePath, $tempPath)
        Expand-Archive -Path $nupkgFilePath -DestinationPath $tempPath -Force

        Start-Sleep -Seconds 5
    
        # remove the original package file
        Write-Host ("[{0}]: Removing original package {1}" -f $nupkgFileNameWithoutExtension, $nupkgFilePath)
        Remove-Item $nupkgFilePath

        Write-Host ("[{0}]: Beginning alteration of package {1}" -f $nupkgFileNameWithoutExtension, $tempPath)
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
        $newItems = Get-ChildItem ([System.IO.Path]::Combine((Get-Item $outputDirectory), "tmp", $nupkgFileNameWithoutExtension))

        Write-Host ("Compressing new package to {0}" -f $nupkgFilePath)
        Compress-Archive -Path $newItems -DestinationPath $nupkgFilePath -Force | Out-Null
    
        Start-Sleep -Seconds 5
    }
 
    $tempDirectory = [System.IO.Path]::Combine($outputDirectory, "tmp")
    if (Test-Path -Path $tempDirectory -PathType Container)
    {
        Write-Host ("Removing temp directory {0}" -f $tempDirectory)
        Get-ChildItem -Path $tempDirectory -Recurse | Remove-Item -Force -Recurse
        Remove-Item $tempDirectory -Force
    }
}

Export-ModuleMember -Function Remove-NuspecProjectReferenceNodes
