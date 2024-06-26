using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public class ValueConvertersTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [Trait("Statement", "INSERT")]
        [InlineData(PaymentSourceType.Web)]
        public void Can_insert_using_nullable_enum_converter(PaymentSourceType expected)
        {
            //given
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentSourceType>().Use(
                        to =>
                        {
                            toFired = true;
                            return "FOO";
                        },
                        from => {
                            fromFired = true;
                            if (from is not string value)
                                return null;
                            if (value == "FOO")
                                return expected;
                            return (PaymentSourceType?)Enum.Parse(typeof(PaymentSourceType), value, true);
                        }
                    )
                )
            );

            //when
            var purchase = new Purchase
            {
                PersonId = 1,
                OrderNumber = $"{DateTime.Now.Date:yyyymmdd}00099",
                PaymentMethodType = PaymentMethodType.ACH,
                PaymentSourceType = expected,
                PurchaseDate = DateTime.Now,
                TotalPurchaseAmount = 12.0,
                TotalPurchaseQuantity = "2",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            db.Insert(
                purchase
            )
            .Into(dbo.Purchase)
            .Execute();

            //then
            purchase.PaymentSourceType.Should().Be(expected);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [Trait("Statement", "UPDATE")]
        [InlineData(PaymentSourceType.Web)]
        public void Can_update_using_nullable_enum_converter(PaymentSourceType expected)
        {
            //given
            bool toFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentSourceType>().Use(
                        to =>
                        {
                            toFired = true;
                            if (to is null)
                                return null;
                            return to == expected ? "FOO" : expected.ToString();
                        },
                        from => throw new NotImplementedException()
                    )
                )
            );

            //when
            db.Update(dbo.Purchase.PaymentSourceType.Set(expected))
                .From(dbo.Purchase)
                .Execute();

            //then
            toFired.Should().BeTrue();
        }

        [Theory]
        [Trait("Statement", "INSERT")]
        [InlineData(PaymentMethodType.CreditCard)]
        public void Can_insert_using_enum_converter(PaymentMethodType expected)
        {
            //given
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentMethodType>().Use(
                        to =>
                        {
                            toFired = true;
                            return "FOO";
                        },
                        from =>
                        {
                            fromFired = true;
                            if (from is not string value)
                                return null;
                            if (value == "FOO")
                                return expected;
                            return (PaymentMethodType)Enum.Parse(typeof(PaymentMethodType), value, true);
                        }
                    )
                )
            );

            //when
            var purchase = new Purchase
            {
                PersonId = 1,
                OrderNumber = $"{DateTime.Now.Date:yyyymmdd}00099",
                PaymentMethodType = expected,
                PaymentSourceType = PaymentSourceType.Web,
                PurchaseDate = DateTime.Now,
                TotalPurchaseAmount = 12.0,
                TotalPurchaseQuantity = "2",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            db.Insert(
                purchase
            )
            .Into(dbo.Purchase)
            .Execute();

            //then
            purchase.PaymentMethodType.Should().Be(expected);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [Trait("Statement", "UPDATE")]
        [InlineData(PaymentMethodType.CreditCard)]
        public void Can_update_using_enum_converter(PaymentMethodType expected)
        {
            //given
            bool toFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentMethodType>().Use(
                        to =>
                        {
                            toFired = true;
                            return to == expected ? "FOO" : expected.ToString();
                        },
                        from => throw new NotImplementedException()
                    )
                )
            );

            //when
            db.Update(dbo.Purchase.PaymentMethodType.Set(expected))
                .From(dbo.Purchase)
                .Execute();

            //then
            toFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "INSERT")]
        public void Can_insert_using_nullable_datetime_converter()
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            //when
            var person = new Person
            {
                FirstName = "a",
                LastName = "b",
                GenderType = GenderType.Female,
                RegistrationDate = DateTime.Now,
                BirthDate = expected
            };

            db.Insert(
                person
            )
            .Into(dbo.Person)
            .Execute();

            //then
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
            person.BirthDate.Value.Year.Should().Be(expected.Value.AddYears(5).Year);
        }

        [Fact]
        [Trait("Statement", "INSERT")]
        public void Can_insert_using_datetimeoffset_converter()
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.AddYears(10);
                        },
                        from =>
                        {
                            fromFired = true;
                            return ((DateTimeOffset)from!).AddYears(-5);
                        }
                    )
                )
            );

            //when
            var person = new Person
            {
                FirstName = "a",
                LastName = "b",
                GenderType = GenderType.Female,
                RegistrationDate = expected
            };

            db.Insert(
                person
            )
            .Into(dbo.Person)
            .Execute();

            //then
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
            person.RegistrationDate.Year.Should().Be(expected.AddYears(5).Year);
        }

        [Fact]
        [Trait("Statement", "UPDATE")]
        public void Can_update_using_datetimeoffset_converter()
        {
            //given
            DateTime expected = DateTime.UtcNow;
            bool toFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to;
                        },
                        from => throw new NotImplementedException()
                    )
                )
            );

            //when
            db.Update(dbo.Person.RegistrationDate.Set(expected))
                .From(dbo.Person)
                .Execute();

            //then
            toFired.Should().BeTrue();
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(PaymentMethodType.CreditCard)]
        public void Can_select_scalar_value_using_enum_converter_when_value_doesnt_require_conversion(PaymentMethodType expected)
        {
            //given
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentMethodType>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            if (from is not string value)
                                return null;
                            if (value == "FOO")
                                return expected;
                            return (PaymentMethodType)Enum.Parse(typeof(PaymentMethodType), value, true);
                        }
                    )
                )
            );

            //when
            var paymentMethod = db.SelectOne(dbo.Purchase.PaymentMethodType)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 1)
                .Execute();

            //then
            paymentMethod.Should().Be(expected);
            fromFired.Should().BeTrue();
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(PaymentMethodType.CreditCard)]
        public void Can_select_scalar_value_using_enum_converter_when_value_requires_conversion(PaymentMethodType expected)
        {
            //given
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentMethodType>().Use(
                        to =>
                        {
                            toFired = true;
                            return "FOO";
                        },
                        from =>
                        {
                            fromFired = true;
                            if (from is not string value)
                                return null;
                            if (value == "FOO")
                                return expected;
                            return (PaymentMethodType)Enum.Parse(typeof(PaymentMethodType), value, true);
                        }
                    )
                )
            );

            //update a record to store "FOO"
            db.Update(dbo.Purchase.PaymentMethodType.Set(PaymentMethodType.PayPal)).From(dbo.Purchase).Where(dbo.Purchase.Id == 1).Execute();

            //when
            var paymentMethod = db.SelectOne(dbo.Purchase.PaymentMethodType)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 1)
                .Execute();

            //then
            paymentMethod.Should().Be(expected);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(PaymentSourceType.Web)]
        public void Can_select_scalar_value_using_nullable_enum_converter_when_value_doesnt_require_conversion(PaymentSourceType expected)
        {
            //given
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentSourceType>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            if (from is not string value)
                                return null;
                            if (value == "FOO")
                                return expected;
                            return (PaymentSourceType)Enum.Parse(typeof(PaymentSourceType), value, true);
                        }
                    )
                )
            );

            //when
            var paymentMethod = db.SelectOne(dbo.Purchase.PaymentSourceType)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 1)
                .Execute();

            //then
            paymentMethod.Should().Be(expected);
            fromFired.Should().BeTrue();
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(PaymentSourceType.Web)]
        public void Can_select_scalar_value_using_nullable_enum_converter_when_value_requires_conversion(PaymentSourceType expected)
        {
            //given
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentSourceType>().Use(
                        to =>
                        {
                            toFired = true;
                            return "FOO";
                        },
                        from =>
                        {
                            fromFired = true;
                            if (from is not string value)
                                return null;
                            if (value == "FOO")
                                return expected;
                            return (PaymentSourceType)Enum.Parse(typeof(PaymentSourceType), value, true);
                        }
                    )
                )
            );

            //update a record to store "FOO"
            db.Update(dbo.Purchase.PaymentSourceType.Set(PaymentSourceType.Web)).From(dbo.Purchase).Where(dbo.Purchase.Id == 1).Execute();

            //when
            var paymentSource = db.SelectOne(dbo.Purchase.PaymentSourceType)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 1)
                .Execute();

            //then
            paymentSource.Should().Be(expected);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_nullable_datetime_converter_when_value_doesnt_require_conversion()
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime?)from).Value.AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var birthDate = db.SelectOne(dbo.Person.BirthDate)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            birthDate!.Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_nullable_datetime_converter_when_value_is_null()
        {
            //given
            DateTime expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return expected.AddYears(10);
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(dbex.Null)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var birthDate = db.SelectOne(dbo.Person.BirthDate)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            birthDate!.Value.Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_datetimeoffset_converter_when_value_doesnt_require_conversion()
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTimeOffset>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            return ((DateTimeOffset)from!).AddYears(-10);
                        }
                    )
                )
            );

            db.Update(dbo.Person.RegistrationDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1);

            //when
            var registrationDate = db.SelectOne(dbo.Person.RegistrationDate)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            registrationDate.Year.Should().Be(expected.AddYears(-10).Year);
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_nullable_datetime_converter_when_value_requires_conversion()
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var birthDate = db.SelectOne(dbo.Person.BirthDate)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            birthDate!.Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_datetimeoffset_converter_when_value_requires_conversion()
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.AddYears(10);
                        },
                        from =>
                        {
                            fromFired = true;
                            return ((DateTimeOffset)from!).AddYears(-5);
                        }
                    )
                )
            );

            db.Update(dbo.Person.RegistrationDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var registrationDate = db.SelectOne(dbo.Person.RegistrationDate)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            registrationDate.Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_nullable_datetime_converter_when_value_doesnt_require_conversion()
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime?)from).Value.AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var person = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.BirthDate
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            ((DateTime?)person!.BirthDate).Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_datetimeoffset_field_converter_when_value_doesnt_require_conversion()
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTimeOffset>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            return ((DateTimeOffset)from!).AddYears(-10);
                        }
                    )
                )
            );

            db.Update(dbo.Person.RegistrationDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1);

            //when
            var person = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.RegistrationDate
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            ((DateTimeOffset)person!.RegistrationDate).Year.Should().Be(expected.AddYears(-10).Year);
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_nullable_datetime_converter_when_value_requires_conversion()
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var person = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.BirthDate
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            ((DateTime?)person!.BirthDate).Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_datetimeoffset_field_converter_when_value_requires_conversion()
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.AddYears(10);
                        },
                        from =>
                        {
                            fromFired = true;
                            return ((DateTimeOffset)from!).AddYears(-5);
                        }
                    )
                )
            );

            db.Update(dbo.Person.RegistrationDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var person = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.RegistrationDate
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            ((DateTimeOffset)person!.RegistrationDate).Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_nullable_datetime_converter_when_value_is_null()
        {
            //given
            DateTime expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return expected.AddYears(10);
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime)from).AddYears(-5) : (DateTime?)from;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(dbex.Null)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var person = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.BirthDate
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            ((DateTime?)person!.BirthDate).Value.Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_entity_using_nullable_datetime_converter_when_value_doesnt_require_conversion()
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime?)from).Value.AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var person = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            person!.BirthDate!.Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_entity_using_datetimeoffset_converter_when_value_doesnt_require_conversion()
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTimeOffset>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            return ((DateTimeOffset)from!).AddYears(-10);
                        }
                    )
                )
            );

            db.Update(dbo.Person.RegistrationDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1);

            //when
            var person = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            person!.RegistrationDate!.Year.Should().Be(expected.AddYears(-10).Year);
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_entity_using_nullable_datetime_converter_when_value_requires_conversion()
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTime?>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is not null ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var person = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            person!.BirthDate!.Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_entity_using_datetimeoffset_converter_when_value_requires_conversion()
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForValueType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.AddYears(10);
                        },
                        from =>
                        {
                            fromFired = true;
                            return ((DateTimeOffset)from!).AddYears(-5);
                        }
                    )
                )
            );

            db.Update(dbo.Person.RegistrationDate.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var person = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            person!.RegistrationDate.Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(9)]
        public void Can_select_purchases_using_in_clause_of_list_of_enums_mapped_to_strings_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentMethodType>().PersistAsString()
                )
            );

            var exp = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentMethodType.In(PaymentMethodType.ACH, PaymentMethodType.PayPal));

            //when
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Fact]
        [Trait("Statement", "INSERT")]
        public void Can_insert_and_select_purchase_with_alteration_of_payment_method_type_enum_result_in_correct_output()
        {
            //given
            bool toFired = false;
            bool fromFired = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(x =>
                    x.ForEnumType<PaymentMethodType>().Use(
                        to => {
                            toFired = true;
                            if (to == PaymentMethodType.PayPal)
                                return $"_{PaymentMethodType.PayPal}";
                            return to;
                        },
                        from => {
                            fromFired = true;
                            var paymentType = from as string;
                            if (string.IsNullOrWhiteSpace(paymentType))
                                return null;
                            if (paymentType == $"_{PaymentMethodType.PayPal}")
                                return PaymentMethodType.PayPal;
                            return (PaymentMethodType?)Enum.Parse(typeof(PaymentMethodType), paymentType, true);
                        }
                    )
                )
            );

            var purchase = new Purchase { OrderNumber = "abc", PaymentMethodType = PaymentMethodType.PayPal, PaymentSourceType = PaymentSourceType.Web, PersonId = 1, PurchaseDate = DateTime.UtcNow, TotalPurchaseQuantity = "1", TotalPurchaseAmount = 1.0 };
            db.Insert(purchase).Into(dbo.Purchase).Execute();

            //when
            var persisted = db.SelectOne<Purchase>()
                .From(dbo.Purchase)
                .Where(dbo.Purchase.Id == purchase.Id).Execute();

            //then
            persisted!.PaymentMethodType.Should().Be(PaymentMethodType.PayPal);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_product_and_deserialize_description_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var persisted = db.SelectOne<Product>()
                .From(dbo.Product)
                .Execute();

            //then
            persisted!.Description.Should().NotBeNull();
            persisted.Description?.Long.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        [Trait("Statement", "INSERT")]
        public void Can_insert_a_product_and_serialize_description_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var product = new Product
            {
                Description = new ProductDescription { Long = "Long", Short = "Short" },
                Name = "Test",
                ListPrice = 1,
                Price = 1,
                Quantity = 1,
                ShippingWeight = 1
            };

            //when
            db.Insert(product).Into(dbo.Product).Execute();

            var persisted = db.SelectOne<Product>()
                .From(dbo.Product)
                .Where(dbo.Product.Id == product.Id)
                .Execute();

            //then
            persisted!.Description.Should().NotBeNull();
            persisted.Description?.Long.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        [Trait("Statement", "UPDATE")]
        public void Can_update_a_product_and_json_serialize_description_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            db.Update(
                    dbo.Product.Description.Set(
                        new ProductDescription 
                        { 
                            Long = "This is a really long description", 
                            Short = "Description" 
                        }
                    )
                )
                .From(dbo.Product)
                .InnerJoin(
                    db.SelectOne(dbo.Product.Id)
                        .From(dbo.Product)
                        .OrderBy(dbo.Product.Id)
                ).As("top1").On(dbo.Product.Id == ("top1", nameof(dbo.Product.Id)))
                .Execute();

            var updated = db.SelectOne<Product>()
                .From(dbo.Product)
                .InnerJoin(
                    db.SelectOne(dbo.Product.Id)
                    .From(dbo.Product)
                    .OrderBy(dbo.Product.Id)
                ).As("top1").On(dbo.Product.Id == ("top1", nameof(dbo.Product.Id)))
                .Execute();

            //then
            updated!.Description.Should().NotBeNull();
            updated.Description?.Long.Should().Be("This is a really long description");
        }
    }
}
