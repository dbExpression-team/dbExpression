# Changelog

## [0.8.2] - 2021-09-2

### Added
- Added OnBeforeUpdateSqlStatementAssembly event to allow global changes to update sql statements prior to assembly
- Added OnBeforeInsertSqlStatementAssembly event to allow global changes to insert sql statements prior to assembly

### Changed
- Fixed issue #252
- Fixed issue #259
- Fixed issue #261
- Improved paging implementation on server side blazor app

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