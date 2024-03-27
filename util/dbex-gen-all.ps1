Param
    (
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$CONFIGURATION = 'Debug',
		[Parameter(ValueFromPipelineByPropertyName)]
        [string]$FRAMEWORK = 'net8.0'
    )

$TOOL_PATH = "../tools/DbExpression.Tools/bin/{0}/{1}/DbExpression.Tools.exe" -f  $CONFIGURATION, $FRAMEWORK

Write-Host "test: v2005"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/DbExpression.MsSql.Test/_Config/v2005MsSqlDb.dbex.config.json -o ../_Generated/v2005MsSqlDb" -Wait

Write-Host "test: v2008"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/DbExpression.MsSql.Test/_Config/v2008MsSqlDb.dbex.config.json -o ../_Generated/v2008MsSqlDb" -Wait

Write-Host "test: v2012"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/DbExpression.MsSql.Test/_Config/v2012MsSqlDb.dbex.config.json -o ../_Generated/v2012MsSqlDb" -Wait

Write-Host "test: v2014"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/DbExpression.MsSql.Test/_Config/v2014MsSqlDb.dbex.config.json -o ../_Generated/v2014MsSqlDb" -Wait

Write-Host "test: v2016"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/DbExpression.MsSql.Test/_Config/v2016MsSqlDb.dbex.config.json -o ../_Generated/v2016MsSqlDb" -Wait

Write-Host "test: v2017"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/DbExpression.MsSql.Test/_Config/v2017MsSqlDb.dbex.config.json -o ../_Generated/v2017MsSqlDb" -Wait

Write-Host "test: v2019"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/DbExpression.MsSql.Test/_Config/v2019MsSqlDb.dbex.config.json -o ../_Generated/v2019MsSqlDb" -Wait

Write-Host "test: v2022"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/DbExpression.MsSql.Test/_Config/v2022MsSqlDb.dbex.config.json -o ../_Generated/v2022MsSqlDb" -Wait

Write-Host "samples: ServerSideBlazorApp"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../samples/mssql/ServerSideBlazorApp -o ../ServerSideBlazorApp/Data/_Generated" -Wait

Write-Host "samples: NetCoreConsoleApp"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../samples/mssql/NetCoreConsoleApp -o ../NetCoreConsoleApp/Data/_Generated" -Wait

Write-Host "benchmark: Benchmark"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../benchmark/Benchmark.MsSql/dbExpression -o ../dbExpression/_dbExpression.Generated" -Wait

Write-Host "benchmark: Profiling"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../benchmark/Profiling.MsSql -o ../Profiling.MsSql/Generated" -Wait

Write-Host "docs: DocumentationExamples"
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../docs/mssql/DocumentationExamples -o ../DocumentationExamples/_Generated" -Wait

Write-Host "Code gen complete."