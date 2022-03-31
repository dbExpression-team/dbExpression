Param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$MSSQL_VERSION,		
		[Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BUILD_CONFIGURATION,		
		[Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$TARGET_FRAMEWORK_MONIKER
    )

Write-Host "Command Line Parameters:"
Write-Host "-------------------------------"
Write-Host "MSSQL_VERSION: " $MSSQL_VERSION
Write-Host "BUILD_CONFIGURATION: " $BUILD_CONFIGURATION
Write-Host "TARGET_FRAMEWORK_MONIKER: " $TARGET_FRAMEWORK_MONIKER

$destination = Split-Path (Split-Path -Path (Get-Location).Path -Parent) -Parent
$destinationFile = $destination + "/.env"

$baseFile =(Get-Location).Path + "/.env"
$overridesFile = (Get-Location).Path + "/" + $MSSQL_VERSION + "/.env"

Write-Host "-------------------------------"
Write-Host "Destination: " $destination
Write-Host "Base file: " $baseFile
Write-Host "Overrides file: " $overridesFile

if (Test-Path $destinationFile) {
	Clear-Content $destinationFile
}

$values = @(
			("MSSQL_VERSION", "BUILD_CONFIGURATION", "TARGET_FRAMEWORK_MONIKER", "PORT", "MSSQL_PWD"),
			($MSSQL_VERSION, $BUILD_CONFIGURATION, $TARGET_FRAMEWORK_MONIKER, $PORT, $MSSQL_PWD),
			($null, $null, $null, $null, $null),
			($null, $null, $null, $null, $null)
		)

if ([System.IO.File]::Exists($overridesFile) -eq $true)
{
	foreach ($override in (Get-Content $overridesFile)) 
	{
		$pair = $override.Split("=", [System.StringSplitOptions]::RemoveEmptyEntries)
		$index = $values[0].indexOf($pair[0].trim());
		$values[2][$index] = $pair[1]
	}
}

foreach ($value in (Get-Content $baseFile)) 
{
	$pair = $value.Split("=", [System.StringSplitOptions]::RemoveEmptyEntries)
	$index = $values[0].indexOf($pair[0].trim());
	$values[3][$index] = $pair[1]
}

Write-Host "-------------------------------"
Write-Host ".env values:"
for ($keyIndex=0; $keyIndex -lt $values[0].length; $keyIndex++)
{
	$key = $values[0][$keyIndex]
	$value = $values[1][$keyIndex]
	if ([System.String]::IsNullOrWhiteSpace($value))
	{
		$value = $values[2][$keyIndex]
	}
	if ([System.String]::IsNullOrWhiteSpace($value))
	{
		$value = $values[3][$keyIndex]
	}
	$env = [System.String]::Join("=", $key, $value)
	Write-Host $env
	Add-Content $destinationFile $env
}

Write-Host "-------------------------------"
$baseFile = ((Get-Location).Path) + "/docker-compose.yml"
Write-Host "Copying docker-compose file from " $baseFile " to " $destination
Copy-Item $baseFile $destination

$baseFile = (Get-Location).Path + "/dockerfile-mssql"
Write-Host "Copying dockerfile-mssql file from " $baseFile " to " $destination
Copy-Item $baseFile $destination

$baseFile = (Split-Path -Path (Get-Location).Path -Parent) + "/dockerfile-dotnetcore"
Write-Host "Copying dockerfile-dotnetcore file from " $baseFile " to " $destination
Copy-Item $baseFile $destination
