### How do I create a new database function?

Implementing a new database function is a fairly straightforward process:
- Create one or more concrete classes based on the return types supported by the function and to encapsulate 
any properties specific to the database function
- Write methods to support the fluent use of the database function
- Write an appender that writes the function to the sql statement writer
- Register the appender as the default appender for the new database function in startup registration routines
- And write unit tests

Think through the following when implementing a new database function:
- Is the database function specific to a single platform, say MySql or SqlServer?  This will determine if the implementation
will be done in the base HatTrick.DbEx.Sql assembly, or in the specific platform assembly.
- Does the database function apply to more than one platform, but has different syntax or parameters when using it?  Again, this
will determine if you implement some "common" work in HatTrick.DbEx.Sql and some work in the specific platform assembly.
- What does the database function do to data, does it aggregate, convert to a different data type, or return the same data type?
This will determine the base type the database function implements.
- What data types does the database function return?  This will determine the number of concrete
classes that will need to be implemented.  A concrete class will be required for each primitive data type returned 
by the database function.  By creating a concrete class for each primitive data type, it ensures a fluent syntax where the 
user of DbExpression doesn't have to continually provide generic arguments specifying the input/output primitive data 
types - they are inferred by the return data type of the fluent interface and the data type of the concrete class.
For reference, the standard deviaion database function accepts any numeric
data type, but always returns ```float```, so the only concrete implementation type for this database function is
```SingleStandardDeviationFunctionExpression``` (and its Nullable variant).  The average database function accepts 
any numeric data type, but it's return type is based on the input data type, i.e. ```short``` returns ```int```, 
```int``` returns ```int``` etc.  So, the average database function required implementations for the primitive data 
types ```decimal```, ```double```, ```int```, ```long```, and ```float```, realized through ```DecimalAverageFunctionExpression```,
```DoubleAverageFunctionExpression```, ```Int32AverageFunctionExpression```, ```Int64AverageFunctionExpression```, 
```SingleAverageFunctionExpression``` (and all the Nullable variants).  Implementing a concrete type per primitive data 
type also enables the function to be used in composition with other expressions.  


For example, using the Average function:
```c#
	db.Select(db.fx.Average(dbo.Order.TotalAmount))
```
is much easier to read and write than requiring the user to specify return types using generic arguments:
```c#
	db.Select(db.fx.Average<decimal>(dbo.Order.TotalAmount))
```
A database function should also support implicit conversion to the appropriate expression mediator type to support composition
with other expressions.  For example, to use the Average function in composition with the IsNull database function:
```c#
	db.fx.Average(db.fx.IsNull(dbo.Order.TotalAmount, 0m))
```
the IsNull database function must return something that can be used as input to the Average database function.  To support this, the IsNull
function, through implicit conversion, is converted to a ```DecimalExpressionMediator```, which the Average database function can work with
as the fluent syntax (and constructor args for the Average database function) accept a ```AnyElement<decimal>```.  This also means that
the IsNull database function can work with any database function (or expression) added later that accepts a ```AnyElement<decimal>```, with
no changes required to the implementation of the IsNull database function.  Also note that the IsNull database function is convertible to a
```AnyElement<string>```, but the Average fluent syntax does not have an overload that accepts a ```AnyElement<string>```, nor
is there a concrete class for the ```string``` variant of the Average database function (```StringAverageFunctionExpression```); as database 
platforms do not support performing an Average on ```string```s.

For example, let's say you intend to implement the (non-existent and hypothetical) "Log10" database function.  The fluent signature might
look like:
```c#
	db.fx.Log10(dbo.Order.TotalAmount)
```
As long as the Log10 database function can be converted to the appropriate expression mediator type, it can be used in about
any existing database function:
```c#
	db.fx.Average(db.fx.Log10(dbo.Order.TotalAmount))
	//or
	db.fx.IsNull(db.fx.Log10(dbo.Order.TotalAmount), 0m)
```

#### Ok, let's get started.

We'll use the Floor database function as an example.  The Floor database function accepts any numeric data type, and
returns the same data type.  So, an input value of ```3.1415m``` would result in ```3.0m```.  The Floor database function therefore extends
the abstract ```DataTypeFunctionExpression``` type as it is does not perform aggregation on data, nor does it change the return data type.

1.  The first step is to create the base level concrete classes, with appropriate constructors.  The Floor database function works on any 
numeeric data type, so we will need the following concrete classes (under Expression/_Function/_DataType/_Floor):
- FloorFunctionExpression.cs
- FloorFunctionExpression\{T\}.cs
- NullableFloorFunctionExpression.cs
- NullableFloorFunctionExpression\{T\}.cs
- ByteFloorFunctionExpression.cs
- DecimalFloorFunctionExpression.cs
- DoubleFloorFunctionExpression.cs
- Int16FloorFunctionExpression.cs
- Int32FloorFunctionExpression.cs
- Int64FloorFunctionExpression.cs
- SingleFloorFunctionExpression.cs
- NullableByteFloorFunctionExpression.cs
- NullableDecimalFloorFunctionExpression.cs
- NullableDoubleFloorFunctionExpression.cs
- NullableInt16FloorFunctionExpression.cs
- NullableInt32FloorFunctionExpression.cs
- NullableInt64FloorFunctionExpression.cs
- NullableSingleFloorFunctionExpression.cs

Add FloorFunctionExpression.cs, which is an abstract class extending ```DataTypeFunctionExpression```, implementing the relevant interfaces (see other functions
for examples).  Provide a protected constructor that accepts a non-generic 
```IExpressionElement``` as a constructor arg (concrete implementation classes that extend the FloorFunctionExpression
can define more concrete argument types).  Implement the interfaces similar to other database function classes.  The end result of FloorFunctionExpression.cs:
```c#
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FloorFunctionExpression : DataTypeFunctionExpression,
        IDbFunctionExpression,
        IExpressionAliasProvider,
        IEquatable<FloorFunctionExpression>
    {
        #region interface        
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected FloorFunctionExpression(IExpressionElement expression) : base(expression)
        {
        }
        #endregion

        #region to string
        public override string ToString() 
		=> $"FLOOR({Expression})";
        #endregion

        #region equals
        public bool Equals(FloorFunctionExpression obj)
         	=> base.Equals(obj);

        public override bool Equals(object obj)
         	=> obj is FloorFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
         	=> base.GetHashCode();
        #endregion
    }
}
```

Add a class named FloorFunctionExpression\{T\}.cs, which is abstract and extends ```FloorFunctionExpression```.  The class should simply provide required
constructors, generically typed to T.
```c#
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FloorFunctionExpression<TValue> : FloorFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected FloorFunctionExpression(AnyElement<TValue> expression) : base(expression)
        {
        }
        #endregion
    }
}
```
Add a concrete (non-nullable) type for each data type that extends ```FloorFunctionExpression<TValue>``` and implements ```IEquatable```.  The ```ByteFloorFunctionExpression``` should resemble:
```c#
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteFloorFunctionExpression : 
        FloorFunctionExpression<byte>,
	ByteElement,
        IEquatable<ByteFloorFunctionExpression>
    {
        #region constructors
        public ByteFloorFunctionExpression(ExpressionMediator<byte> expression) : base(expression)
        { 
        
        }
        #endregion

        #region as
        public new AnyElement<byte> As(string alias)
        	=> new SelectExpression<byte>(this).As(alias);
        #endregion

        #region equals
        public bool Equals(ByteFloorFunctionExpression obj)
            => obj is ByteFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
```

Add all other concrete implementation types for all return types of the Floor database function similar to the ```BytefloorFunctionExpression```.
 
The same implementation patterns should be used for the Nullable versions of the Floor database function.  Add a file named NullableFloorFunctionExpression.cs that
extends ```FloorFunctionExpression```:
```c#
namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableFloorFunctionExpression : FloorFunctionExpression,
        IExpressionElement<TValue,TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableFloorFunctionExpression(IExpressionElement expression) : base(expression)
        {
        }
        #endregion
    }
}
```

Add a class named NullableFloorFunctionExpression\{T,U\}.cs:
```c#
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableFloorFunctionExpression<TValue, TNullableValue> : FloorFunctionExpression
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableFloorFunctionExpression(AnyElement<byte?> expression) : base(expression)
        {

        }
        #endregion
    }
}
```

Similar to the ```ByteFloorFunctionExpression```, add NullableByteFloorFunctionExpression\{T,U\}.cs, which extends ```NullableFloorFunctionExpression<TValue,TNullableValue>```.
```c#
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteFloorFunctionExpression :
        NullableFloorFunctionExpression<byte,byte?>,
	NullableByteElement,
        IEquatable<NullableByteFloorFunctionExpression>
    {
        #region constructors
        public NullableByteFloorFunctionExpression(AnyElement<byte?> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public AnyElement<byte?> As(string alias)
            => new SelectExpression<byte?>(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableByteFloorFunctionExpression obj)
            => obj is NullableByteFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
```
Add additional concrete types that extend ```NullableFloorFunctionExpression<TValue,TNullableValue>```, one for each return type.

2.  Next, create the metadata required to code generate additional implementation details of each of the concrete FloorFunctionExpression classes (things like
 implicit converters) for each data type (there's a lot for each one, so code generation is used to cut down on the amount of hand-written code).  In the 
 HatTrick.DbEx.CodeTemplating project, add FloorFunctionExpressionCodeGenerator.cs.
This class should extend ```CodeGenerator<FunctionTemplateModel>```.  The sole purpose of this class is to define the code generation metadata that
is used to generate all of the additional code related to the Floor database function.
```c#
using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using System.Linq;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class FloorFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Floor";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;
            model.IsGroupBySupported = true;
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddNumericTypes().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = TypeBuilder.Get<int>(),
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddNumericTypes().ToList())
                Generate(templatePath, outputSubdirectory, $"{@type.Name}{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.Sql.Expression", @type));
        }
    }
}
```
The ```model.ArithmeticOperators``` property assignment defines the type of arithmetic operations the Floor database function supports for each of the return data types
it supports.  This metadata indicates that it supports all numeric data types (```.AddNumericTypes()```), the return type of all arithmetic operations is the data type 
passed in (i.e. a "ByteFloorFunctionExpression" arithmetic operation with another "ByteExpressionMediator" results in a "ByteExpressionMediator".  In the example of 
the standard deviation function, the return type is always ```single```.  The ```.InferArithmeticOperations()``` simply infers what arithmetic operations work for the 
type; i.e. it won't return a divide for a ```string``` type.

3. Configure the metadata in ```Program.cs``` of the HatTrick.DbEx.CodeTemplating project.

```c#
	.Generate<FloorFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Floor")
	.Generate<NullableFloorFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Floor")
```
4. Run the code generation project.  This will output all of the floor function generated files.

5. Add the fluent syntax to support the function in the appropriate file.  The floor function is used in SqlServer, MySql, Oracle, and Postres, so syntax should be added to the base sql
builder (```SqlFunctionExpressionBuilder```).  Here we are defining what happens when someone types ```db.fx.Floor(...``` so provide all the appropriate overloads:
```c#
public static ByteFloorFunctionExpression Floor(AnyElement<byte> element)
	=> new ByteFloorFunctionExpression(element);

public static NullableByteFloorFunctionExpression Floor(AnyElement<byte?> element)
	=> new NullableByteFloorFunctionExpression(element);

public static Int16FloorFunctionExpression Floor(AnyElement<int> element)
	=> new Int16FloorFunctionExpression(element);

public static NullableInt16FloorFunctionExpression Floor(AnyElement<int?> element)
	=> new NullableInt16FloorFunctionExpression(element);

//continue with other data types
```
Note that each accepts some form of an ```AnyElement```.  This means that any expression that can be converted to this interface type can be used with the floor function.

6.  Add an appender for the function.  Using the floor function example, add FloorFunctionExpressionPartAppender.cs to HatTrick.DbEx.Sql/Assembler/_Appenders/_Functions.  The role of the appender
is simply to accept a FloorFunctionExpression and append it to the sql statement writer.  As such, the FloorFunctionExpressionPartAppender class looks like:
```c#
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FloorFunctionExpressionPartAppender : ExpressionElementAppender<FloorFunctionExpression>
    {
        #region methods
        public override void AppendElement(FloorFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("FLOOR(");
            builder.AppendElement((expression as IExpressionProvider<IExpressionElement>).Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
```
Ensure to allow the builder to append parts that don't have anything to do with the Floor database function (```builder.AppendPart(expression.Expression, context```).  This is because
this could be any expression type supported by the floor function, like a ```FieldExpression```, another database function, a literal value, etc.  For example, the function expression could be
one of:
```c#
db.fx.Floor(dbo.Purchase.TotalAmount)
//or
db.fx.Floor(db.IsNull(dbo.DatePart(DateParts.Year, dbo.Person.BirthDate),0)
//or
db.fx.Floor(237.19m) //don't know why anyone would do this, but you get the point
```

7.  Add default registrations for the appender.  In ```HatTrick.DbEx.Sql.Assembler.SqlStatementBuilderFactory```, add a static readonly property referencing a ```FloorFunctionExpressionPartAppender``` (the appender
is thread-safe and can be used/re-used by any thread).  In ```RegisterDefaultAppenders```, add the appender to the dictionary, creating a func that simply returns the static instance:
```c#
private static readonly FloorFunctionExpressionAppender floorFunctionAppender = new FloorFunctionExpressionAppender();

RegisterElementAppender(floorFunctionAppender);
```
8.  Add unit tests.
