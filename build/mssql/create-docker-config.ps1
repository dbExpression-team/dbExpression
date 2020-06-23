Param
    (
        [Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$MSSQL_VERSION,		
		[Parameter(Mandatory,ValueFromPipelineByPropertyName)]
        [string]$BUILD_CONFIGURATION,
		[Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
        [string]$TEST_PROJECT_PATH,
		[Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
        [string]$TEST_PROJECT_FILENAME,
		[Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
        [string]$CREATE_DB_SCRIPT_PATH,
		[Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
        [string]$CREATE_DB_SCRIPT_FILENAME,
		[Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]			
		[string]$TEST_OUTPUT_FILE_PATH,
		[Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
		[string]$TEST_OUTPUT_FILE_NAME,		
		[Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
		[string]$CODE_COVERAGE_OUTPUT_FILE_PATH,			
        [Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
		[string]$CODE_COVERAGE_OUTPUT_FILE_NAME,			
        [Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
		[string]$PORT,
		[Parameter(Mandatory=$false,ValueFromPipelineByPropertyName)]
        [string]$MSSQL_PWD
    )

Write-Host "Command Line Parameters:"
Write-Host "-------------------------------"
Write-Host "MSSQL_VERSION: " $MSSQL_VERSION
Write-Host "BUILD_CONFIGURATION: " $BUILD_CONFIGURATION
Write-Host "TEST_PROJECT_PATH: " $TEST_PROJECT_PATH
Write-Host "TEST_PROJECT_FILENAME: " $TEST_PROJECT_FILENAME
Write-Host "CREATE_DB_SCRIPT_PATH: " $CREATE_DB_SCRIPT_PATH
Write-Host "CREATE_DB_SCRIPT_FILENAME: " $CREATE_DB_SCRIPT_FILENAME
Write-Host "TEST_OUTPUT_FILE_PATH: " $TEST_OUTPUT_FILE_PATH
Write-Host "TEST_OUTPUT_FILE_NAME: " $TEST_OUTPUT_FILE_NAME
Write-Host "CODE_COVERAGE_OUTPUT_FILE_PATH: " $CODE_COVERAGE_OUTPUT_FILE_PATH
Write-Host "CODE_COVERAGE_OUTPUT_FILE_NAME: " $CODE_COVERAGE_OUTPUT_FILE_NAME
Write-Host "PORT: " $PORT
Write-Host "MSSQL_PWD: " $MSSQL_PWD

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
			("MSSQL_VERSION", "BUILD_CONFIGURATION", "TEST_PROJECT_PATH", "TEST_PROJECT_FILENAME", "CREATE_DB_SCRIPT_PATH", "CREATE_DB_SCRIPT_FILENAME", "TEST_OUTPUT_FILE_PATH", "TEST_OUTPUT_FILE_NAME", "CODE_COVERAGE_OUTPUT_FILE_PATH", "CODE_COVERAGE_OUTPUT_FILE_NAME", "PORT", "MSSQL_PWD"),
			($MSSQL_VERSION, $BUILD_CONFIGURATION, $TEST_PROJECT_PATH, $TEST_PROJECT_FILENAME, $CREATE_DB_SCRIPT_PATH, $CREATE_DB_SCRIPT_FILENAME, $TEST_OUTPUT_FILE_PATH, $TEST_OUTPUT_FILE_NAME, $CODE_COVERAGE_OUTPUT_FILE_PATH, $CODE_COVERAGE_OUTPUT_FILE_NAME, $PORT, $MSSQL_PWD),
			($null, $null, $null, $null, $null, $null, $null, $null, $null, $null, $null, $null),
			($null, $null, $null, $null, $null, $null, $null, $null, $null, $null, $null, $null)
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
