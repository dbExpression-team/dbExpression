# Changelog

## [unversioned]

### Added
#### Stored Procedures

### Changed
//TODO:
- Split interfaces for SelectValue and SelectValues to SelectValue and SelectDynamic and SelectValues and SelectDynamics for SELECT operations
- Change SELECT operation methods that accept Action<object> to Action<T> and ensure the value goes through value conversion
- Consistency on Pipelines that test whether reader is null
- Consistency on try/catch on any pipeline execution where the user has control of the reader
- DONE: Deprecate IValueConverterProvider parameter from Map function of IExpandoObjectMapper (it's part of the field)
- DONE: Hide all input paramters and MapOutputParameters on StoredProcedureExpression
- LOOK at deprecating IExpressionSet in favor of IExpressionListProvider
- Pipelines: "var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression);" need " ?? throw null"
- DONE: Pipeline events for sprocs
- DONE: Collapsed common MsSql assemblers for versions 2012+ and simplified startup configuration
- DONE: Reworked parameter builder to support output and input/output parameters. Provided consistency with other factories by adding Create methods that create parameters and Add to add it to the list (Add no longer creates and adds)
- DONE: ParameterExpressionAppender: name should be the database param name, not the expression param name.
- Changed fx class to a partial class
- Moved MsSqlFieldMetadata and SqlFieldMetadata to root namespaces.
- Renamed "Items" property on code generation models to more specific names like "Columns", "Entities", and "Fields"

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