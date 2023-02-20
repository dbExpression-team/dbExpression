Param
    (
        [Parameter(ValueFromPipelineByPropertyName)]
        [string]$CONFIGURATION = 'Debug',
		[Parameter(ValueFromPipelineByPropertyName)]
        [string]$FRAMEWORK = 'net7.0'
    )

$TOOL_PATH = "../tools/HatTrick.DbEx.Tools/bin/{0}/{1}/HatTrick.DbEx.Tools.exe" -f  $CONFIGURATION, $FRAMEWORK

Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/HatTrick.DbEx.MsSql.Test/MsSqlDb.dbex.config.json -o ../HatTrick.DbEx.MsSql.Test/Generated/MsSqlDb" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/HatTrick.DbEx.MsSql.Test/MsSqlDb.net48.dbex.config.json -o ../HatTrick.DbEx.MsSql.Test/Generated/MsSqlDb_net48" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/HatTrick.DbEx.MsSql.Test/MsSqlDbAlt.dbex.config.json -o ../HatTrick.DbEx.MsSql.Test/Generated/MsSqlDbAlt" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/HatTrick.DbEx.MsSql.Test/MsSqlDbAlt.net48.dbex.config.json -o ../HatTrick.DbEx.MsSql.Test/Generated/MsSqlDbAlt_net48" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/HatTrick.DbEx.MsSql.Test/v2005MsSqlDb.dbex.config.json -o ../HatTrick.DbEx.MsSql.Test/Generated/v2005MsSqlDb" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../test/HatTrick.DbEx.MsSql.Test/v2016MsSqlDb.dbex.config.json -o ../HatTrick.DbEx.MsSql.Test/Generated/v2016MsSqlDb" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../samples/mssql/ServerSideBlazorApp -o ../mssql/ServerSideBlazorApp/Data/_Generated" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../samples/mssql/NetCoreConsoleApp -o ../mssql/NetCoreConsoleApp/Data/_Generated" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../benchmark/Benchmark.MsSql/dbExpression -o ../dbExpression/_dbExpression.Generated" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../benchmark/Profiling.MsSql -o ../Profiling.MsSql/Generated" -Wait
Start-Process -FilePath $TOOL_PATH -ArgumentList "gen -p ../docs/mssql/DocumentationExamples -o ../mssql/DocumentationExamples/_Generated" -Wait