# Changelog

## [0.9.4]

### Added
	
### Changed

### Fixed

### Breaking Changes

## [0.9.3] - 2022-09-08

### Added
- Added comments and property names to methods that construct metadata.  Makes source control diffs easier as the property name and comments provide clarity.

- Added support for MsSql 2022
	- Parity with version 2019, no 2022 version specific functionality

- Platform version specific services enabling version specific functionality
	- Scaffolding config now requires the platform version, which is generated into data services
		- Validate that scaffolding config for source.platform.version is a supported MsSql version.
	- Version specific function builders.  For example, in MsSql 2022 the [Trim function](https://docs.microsoft.com/en-us/sql/t-sql/functions/trim-transact-sql?view=sql-server-ver16) has additional method parameters.  With version specific function builders, dExpression can handle these specific cases.
	- This supports the removal of version specific configuration methods in favor of a single method:
		- dbex.AddMsSql2019Database<MyDatabase>(...) -> dbex.AddDatabase<MyDatabase>(...).

- Implemented preview version of .NET 7.0
	- Added static abstract interface method on ISqlDatabaseRuntime that enforces the runtime version of MsSql.
	- Added PlatformVersion attribute to shim this for pre .NET 7.0, with conditional compilation statements where necessary.
	- DID NOT target .NET 7.0 in projects as it causes issues with build pipeline.  Will target on release of .NET 7.0.
	- Microsoft introduced build warning CS8981, which impacts dbExpression.   This build warning states that all variables, classes, keywords, etc. that are lowercase ASCII should be changed as they should be reserved for C# (took 22 years for Microsoft to decide this?). Code generation now emits pragma warnings, will have to let the compiler catch issues with database schema naming that conflicts with “future” language keywords.  
		
### Changed
- Removed unused arg (ISqlDatabaseRuntime) from query expression builder factory.
- Removed dependency injection test project as all tests were recreations of those in other test projects.

### Fixed

### Breaking Changes
- TOOLS UPDATE IS REQUIRED
- Runtime configuration removes version specific configuration.  Any use of .Add{Platform}{Version}Database(...) (i.e. .AddMsSql2019Database(...)) must be changed to .AddDatabase(...).
- Scaffolding configuration
	- Changed "source" to be a complex object with "version" and "key".
	- "type" property name changed to "key" (source.platform.key).
	- Platform version is required and must be a supported version (source.platform.version).

## [0.9.2] - 2022-08-20

### Added
- Internal service resolution for dbExpression services are now provided by dependency injection.  Each database has it's own set of services, through separate containers.  Database container use Microsoft's dependency injection service provider as a fallback to services not registered in each container (i.e. services.AddLogging).
- Runtime configuration builders now support the ability to provide a func/delegate that receives the service provider.
- Logging has been added to internal services and uses the Microsoft standard logging framework, where services are injected with an ILogger.  The majority of internal logging uses the Trace level, and rarely is the Debug level used.  Any "higher" levels are expected to be implemented via exception handling by the user.  Logging configuration includes a flag that specifies whether parameter values should be logged in addition to the sql statements using the parameters.

### Changed
- Runtime configuration changed from using a static service locator pattern to using dependency injection for internal services.
- Folded sql statement assemblers into element appenders as they were identical in processing, the only difference being a method name.
 
### Fixed

### Breaking Changes
- TOOLS UPDATE IS REQUIRED
- Configuration has significant changes with the implementation of dependency injection for internal operations of dbExpression, and to additionally improve the API.  Specifically:
	- Value converter configuration
		- .UseDefaultFactoryFor -> .ForTypes
		- .OverrideForEnumType -> .ForEnumType
		- .OverrideForValueType -> .ForValueType
		- .OverrideForReferenceType -> .ForReferenceType
	- Entity configuration
		- .UseDefaultFactoryFor -> .ForEntityTypes
		- .OverrideForEntity -> .ForEntityType
	- Expression element configuration
		- .UseDefaultFactoryFor -> .ForElementTypesgit 
		- .ForElement -> .ForElementType
	- Query expression configuration
		- .UseDefaultFactoryFor -> .ForQueryTypes
	- Execution pipeline configuration
		- .UseDefaultFactoryFor -> .ForPipelineTypes
		
	- Any configuration/customization related to query expression assemblers were deprecated along with the assembler implementations when assembler functionality was merged into appender functionality.
	
- Dependency injection integration with Microsoft (HatTrick.DbEx.MsSql.Extensions.DependencyInjection) no longer supports registration of services specific to a database.  This has been mitigated by registration of database specific services in their own container.

- Static configuration via dbExpression class has been deprecated now that dbExpression uses dependency injection.  See [sample console app](https://github.com/HatTrickLabs/dbExpression/blob/90c82b939961ec09def5bfaf0b61ec3b2a097261/samples/mssql/NetCoreConsoleApp/Program.cs)
for an example on how to configure dbExpression in a console application.

## [0.9.1] - 2022-06-14

### Added
- Benchmark reports
- Code coverage reports
- AliasedElement to abstract AliasExpression
- NullExpression and NullElement interface for handling of null values (instead of DBNull.Value)

### Changed
- FilterExpressions- The implementation of filters was not correct. When an element is composed as a filter (i.e. "element1 < element2"), the result should be a FilterExpression, not a FilterExpressionSet.
FilterExpressionSet used the same composition of elements as FilterExpression, having a LeftArg and RightArg. But a FilterExpresionSet should hold any number N of expressions, not constrained
to LeftArg and RightArg. This work was to correct these mis-alignments:
	- Changed FilterExpressionSet to contain a list of FilterExpression/FilterExpressionSet instead of a LeftArg and RightArg, enabling chaining multiple elements that have the same conditional operator
	- Changed implicit operators for filters to return FilterExpression instead of FilterExpressionSet
	- Changed In expressions to return FilterExpression instead of FilterExpressionSet
	- Implementation of FilterExpressionSetAppender was greatly simplified
	- Removed implicit operators as they are now handled correctly via constructors and other methods
	- FilterExpression -> FilterExpressionSet
	- FilterExpression -> HavingExpression
- Arithmetic Expressions - Reduced number of appended parenthesis by changing ArithmeticExpression to contain a list of args instead of a "LeftArg" and "RightArg"
	- Elements used in arithmetic with another ArithmeticExpression are appended to the ArithmeticExpression's list if the arithmetic operator is the same
	- When composing ArithmeticExpression's with a FieldExpression, the FieldExpression is not provided to the constructed LiteralExpression, ensuring the type of the value is used to construct db parameters (this
	also fixes a discovered issue in doing arithmetic with a FieldExpression of one type and a value type that differs)
- Query Expressions
	- Added a new SelectSetQueryExpression (derives from QueryExpression), which enables composing queries with multiple queries joined as a single statement
		- Added support for Union and Union All operations
		- DOES NOT support multiple return types/mappings, uses the select expression set from the first select query expression to determine how to match ALL returned data
	- Removed BaseEntity from base QueryExpression in favor of more relevant properties on each derived QueryExpressionType:
		- InsertQueryExpression: BaseEntity -> Into
		- DeleteQueryExpression: BaseEntity -> From
		- UpdatQueryExpression: BaseEntity -> From
		- SelectQueryExpression: BaseEntity -> From		
- Reworked AssemblyContext to fully manage properties that were originally pass-thru/delegated to database configuration.  This enables changes to be made to AssemblyContext as a query expression is assembled 
	into a statement without changing global state of database configuration.
- Removed generic version of NullableObjectElement and ObjectElement, the generic constraint of object/object? provided no value.
- Added additional generic constraint to query expression builders that identifies the database the builder is building a statement for.
- Corrected IsNull function to allow for null and empty strings at termination instead of throwing ArgumentException.
- Improved query output formatting, specifically eliminating line break prior to appending a statement termination character.
- Deprecated unused classes:
	- JoinOnExpressionSet
	- JoinOnExpressionSetAppender
	- RawExpression
	- RawExpressionAppender
- Deprecated:
	- NullableObjectElement<T> (ObjectElement<T> meets requirements in both nullable and non-nullable contexts)
	- NullableObjectFieldExpression and NullableObjectFieldExpression<T>
	- NullableObjectSelectExpression<T>
- Renamed some API elements to align better with MS documentation and its use
	- AnyOrderByClause -> AnyOrderByExpression
	- AnyGroupByClause -> AnyGroupByExpression
	- AnyHavingClause -> AnyHavingExpression
	- AnyWhereClause -> AnyWhereExpression
	- AnyJoinOnClause -> AnyJoinOnExpression
- Decoupled value conversion from sql parameter building.  Previously, to convert a value before being sent to the database, it could only be done through building a sql parameter - even if the parameter itself wasn't needed.

### Fixed
- #304: type overrides were not applied in generated code if supplied in dbex.config.json

### Breaking Changes
- Deprecated use of "DBNull.Value".  All code should be migrated to use the new expression from use of "dbex.Null"

## [0.9.0] - 2022-04-01

### Added
- Support for nullable reference types

### Changed
- C# 9.0 
	- set langversion to 9.0
	- updated code base to account for new language features, for example "is not null" instead of "is object" and new() instead of new XXX() (where identified by IDE - many more left)

- Nullable Reference Types
	- reworked code base to support nullable types
	- upgraded implementation for string and object types for api, field expressions, expression mediators, and functions to use nullable reference types
	- reworked all code generation to support nullable reference types and added option to code generation configuration - same as when opting in to the feature via the csproj file, users will opt in with code generation via a config property)
	- resolved interface issues/warnings related to nullable reference types (#287) and realigned some interfaces to be in the same hierarchy to avoid blind use of "as" that could cause null reference exceptions

- Aliasing (#289)
	- better support for aliasing with addition of nullable reference types
	- added tuple ((string,string)) with various functions to allow for creating an alias from the tuple, without having to use dbex.Alias...
	- changed various functions that wrapped a literal expression with an expression mediator to work with just the literal expression in order to reduce object allocations
	- altered functions that don't have any parameters to use a static singleton instance to reduce object allocations

- Cleanup
	- renamed ExecutionPipeline classes (and related configuration classes) to QueryExecutionPipeline to more accurately reflect the purpose of the pipeline
	- renamed classes/interfaces for conformity (RuntimeSqlDatabase.. -> SqlDatabaseRuntime...)
	- added missing implicit operators to strings
	- removed unnecessary integration tests.
	- reworked code generation to have more correct implementation between using dbExpression in static vs. instance modes (#288) and (#290)

### Fixed
- issue #283: Can't use select statement as subquery with update statement
- issue #284: Can't issue an update on a field using a value from a derived table

### Breaking Changes
- Configuration
	- with the addition of nullable reference types, the fluent configuration builder for value converters (during application startup) changed.  
		The method to register a value converter for a type, where the type is a primitive data type, changed "OverrideForType" to "OverrideForValueType";
	- The property value of the property named "Type" in the code gen configuration changed from "MsSqlDb" to "MsSql" (the docs had the correct value of "MsSql", but the code used "MsSqlDb").
	- with dependency injection, the use of "UseDbExpression" in the "Configure" method is no longer required and has been removed.

## [0.8.5] - 2022-01-13

### Added
- Target .NET 6

### Changed

### Fixed
- NuGet packaging now includes symbol packages

### Breaking Changes

## [0.8.4] - 2021-10-06

### Added

### Changed

### Fixed
- issue #274: Scaffolding produces wrong CLR type when providing a configuration (A TOOLS UPDATE IS REQUIRED)
- issue #273: Sql connector's EnsureOpenAsync should not require a cancellation token

### Breaking Changes

## [0.8.3] - 2021-09-09

### Added

### Changed
- Moved Execute and ExecuteAsync methods from extension methods to interfaces (and instance implementations)

### Fixed
- Fixed issue #265

### Breaking Changes
- A TOOLS UPDATE IS REQUIRED as code scaffolding templates were changed in support of interface changes
- Selecting aliased fields requires the use of the generic version of dbex.Alias method
- SQL Statement executor factory no longer accepts the QueryExpression as a parameter for creating an executor

## [0.8.2] - 2021-09-02

### Added
- Added OnBeforeUpdateSqlStatementAssembly event to allow global changes to update sql statements prior to assembly
- Added OnBeforeInsertSqlStatementAssembly event to allow global changes to insert sql statements prior to assembly

### Changed
- Improved paging implementation on server side blazor app

### Fixed
- Fixed issue #252
- Fixed issue #259
- Fixed issue #261

### Breaking Changes

## [0.8.1] - 2021-06-23

### Added
- Added Round database function
- Added IntegralNumericElement and NullableIntegralNumericElement to provide an abstract container for numeric types that can be converted to an integer/long type

### Changed
- ByteElement, Int16Element, Int32Element, and Int64Element now implement IntegralNumericElement
- NullableByteElement, NullableInt16Element, NullableInt32Element, and NullableInt64Element now implement NullableIntegralNumericElement

### Breaking Changes


## [0.8.0] - 2021-06-14

### Added
- Support for stored procedures
- Added additional database functions:
	- Trim
	- LTrim
	- RTrim
	- Abs
	- Substring
	- Replace
	- Len
	- CharIndex
	- PatIndex
	- Right
	- Left

### Changed
- Separated fluent interfaces for selecting scalar values from dynamic objects (they were implemented using same interfaces).
- Collapsed common MsSql assemblers for versions 2012+ and simplified startup configuration.
- Reworked parameter builder to support output and input/output parameters. Provided consistency with other factories by adding Create methods that create parameters and Add method to add it to the list (Add no longer creates and adds).
- Deprecated IExpressionSet in favor of IExpressionListProvider (internal)

### Breaking Changes
- Changed SELECT operation methods that accept Action\<object\> (for custom mapping) to Action\<T\>, which ensures all returned value(s) go through value conversion.

## [0.7.1] - 2021-05-10

### Added

#### Improve Value Converters: additional configuration and features in using Value Converters have been implemented and various issue fixes with existing value converter implementation.
- Created reference to a FieldExpression in LiteralExpression, AssignmentExpression, and InsertExpression to have a direct correlation between the source FieldExpression and the using Expression.
- Deprecated FieldExpression from AssemblyContext.  As FieldExpression is now part of the creation of Expressions related to the FieldExpression, using the Push/Pop methods for a FieldExpression during assembly were no longer needed.
- Refactored parameter builders to provide consistency across all creation methods by always returning a ParameterizedExpression.
- Refactored function expressions to "hide" properties via IExpressionProvider implementation.  This ensures no confusion in the API when used (i.e. db.fx.DatePart(year, date1, date1).DatePart is confusing)
- Cosmetic change for assembling SQL statements: removed extraneous indentation while building queries containing offset and limit specifications.

### Changed
- [issue #225](https://github.com/HatTrickLabs/dbExpression/issues/225): Scaffolding generation now honors ignore configuration option.  Previous to this release, all views for a database would be scaffolded.

### Breaking Changes
- Overriding type definitions for the default value converter factory now uses syntax consistent with overriding Enums; i.e. ```x.OverrideForType<int>().Use<MyValueConverter>()``` instead of ```x.OverrideForType<int,MyValueConverter>()```