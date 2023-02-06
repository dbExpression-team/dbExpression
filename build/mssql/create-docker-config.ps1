Param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$MSSQL_VERSION,		
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BUILD_CONFIGURATION,		
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$TARGET_FRAMEWORK_MONIKER,		
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$NET_DOCKER_TAG,		
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$MSSQL_DOCKER_TAG,		
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$ROOT_PATH,
		[Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$ASSEMBLY_NAME
    )

Write-Host "Command Line Parameters:"
Write-Host "-------------------------------"
Write-Host "MSSQL_VERSION: " $MSSQL_VERSION
Write-Host "BUILD_CONFIGURATION: " $BUILD_CONFIGURATION
Write-Host "TARGET_FRAMEWORK_MONIKER: " $TARGET_FRAMEWORK_MONIKER
Write-Host "NET_DOCKER_TAG: " $NET_DOCKER_TAG
Write-Host "MSSQL_DOCKER_TAG: " $MSSQL_DOCKER_TAG
Write-Host "ROOT_PATH: " $ROOT_PATH
Write-Host "ASSEMBLY_NAME: " $ASSEMBLY_NAME

$destination = Split-Path (Split-Path -Path (Get-Location).Path -Parent) -Parent
$destinationFile = $destination + "/.env"
$envFile = (Get-Location).Path + "/" + $MSSQL_VERSION + "/.env"

Write-Host "-------------------------------"
Write-Host "Destination: " $destination
Write-Host ".env file: " $envFile

if (Test-Path $destinationFile) {
	Clear-Content $destinationFile
}

#If NET_DOCKER_TAG is passed as 7.0, the NET_DOCKER_TAG value will actually be 7.  Must repair for any x.0 versions.
$segments = $NET_DOCKER_TAG.Split('.')
if ($segments.Length -eq 1)
{
	$NET_DOCKER_TAG = "{0:n1}" -f [int]$segments[0]
	Write-Host "Formatted NET_DOCKER_TAG:" $NET_DOCKER_TAG
}

$values = @(
			("MSSQL_VERSION", "BUILD_CONFIGURATION", "TARGET_FRAMEWORK_MONIKER", "NET_DOCKER_TAG", "MSSQL_DOCKER_TAG", "PORT", "MSSQL_PWD", "ROOT_PATH", "ASSEMBLY_NAME"),
			($MSSQL_VERSION, $BUILD_CONFIGURATION, $TARGET_FRAMEWORK_MONIKER, $NET_DOCKER_TAG, $MSSQL_DOCKER_TAG, $PORT, $MSSQL_PWD, $ROOT_PATH, $ASSEMBLY_NAME),
			($null, $null, $null, $null, $null, $null, $null, $null, $null)
		)

if ([System.IO.File]::Exists($envFile) -eq $true)
{
	foreach ($line in (Get-Content $envFile)) 
	{
		$pair = $line.Split("=", [System.StringSplitOptions]::RemoveEmptyEntries)
		$index = $values[0].indexOf($pair[0].trim());
		$values[2][$index] = $pair[1]
	}
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
	$env = [System.String]::Join("=", $key, $value)
	Write-Host $env
	Add-Content $destinationFile $env
}

$netMajorVersion = [int]$NET_DOCKER_TAG.Split('.')[0]
$dockerFile = "dockerfile-dotnet"
if ($netMajorVersion -lt 5)
{
	Write-Host "TFM is .NET Framework, switching dockerfile from dockerfile-dotnet to dockerfile-dotnet-framework"
	$dockerFile = "dockerfile-dotnet-framework"
	$baseFile = (Split-Path -Path (Get-Location).Path -Parent) + "/" + $dockerFile
	Write-Host "Copying dockerfile-dotnet-framework file from " $baseFile " to " $destination
	Copy-Item $baseFile $destination
	Rename-Item -Path ($destination + "/dockerfile-dotnet-framework") -NewName "dockerfile-dotnet"
}
else
{
	$baseFile = (Split-Path -Path (Get-Location).Path -Parent) + "/" + $dockerFile
	Write-Host "Copying dockerfile-dotnet file from " $baseFile " to " $destination
	Copy-Item $baseFile $destination
}

Write-Host "-------------------------------"
$baseFile = ((Get-Location).Path) + "/docker-compose.yml"
Write-Host "Copying docker-compose file from " $baseFile " to " $destination
Copy-Item $baseFile $destination

$baseFile = (Get-Location).Path + "/dockerfile-mssql"
Write-Host "Copying dockerfile-mssql file from " $baseFile " to " $destination
Copy-Item $baseFile $destination
