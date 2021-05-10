using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class ValueConverters : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "INSERT")]
        public void Can_insert_using_nullable_enum_converter(int version, PaymentSourceType expected = PaymentSourceType.Web)
        {
            //given
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentSourceType>().Use(
                        to =>
                        {
                            toFired = true;
                            return "FOO";
                        },
                        from => {
                            fromFired = true;
                            if (from is null)
                                return null;
                            var value = from as string;
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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "UPDATE")]
        public void Can_update_using_nullable_enum_converter(int version, PaymentSourceType expected = PaymentSourceType.Web)
        {
            //given
            bool toFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentSourceType>().Use(
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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "INSERT")]
        public void Can_insert_using_enum_converter(int version, PaymentMethodType expected = PaymentMethodType.CreditCard)
        {
            //given
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentMethodType>().Use(
                        to =>
                        {
                            toFired = true;
                            return "FOO";
                        },
                        from =>
                        {
                            fromFired = true;
                            var value = from as string;
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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "UPDATE")]
        public void Can_update_using_enum_converter(int version, PaymentMethodType expected = PaymentMethodType.CreditCard)
        {
            //given
            bool toFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentMethodType>().Use(
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "INSERT")]
        public void Can_insert_using_nullable_datetime_converter(int version)
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "INSERT")]
        public void Can_insert_using_datetimeoffset_converter(int version)
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTimeOffset?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTimeOffset)from).AddYears(-5) : (DateTimeOffset?)null;
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "UPDATE")]
        public void Can_update_using_datetimeoffset_converter(int version)
        {
            //given
            DateTime expected = DateTime.UtcNow;
            bool toFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to : (DateTimeOffset?)null;
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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_enum_converter_when_value_doesnt_require_conversion(int version, PaymentMethodType expected = PaymentMethodType.CreditCard)
        {
            //given
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentMethodType>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            var value = from as string;
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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_enum_converter_when_value_requires_conversion(int version, PaymentMethodType expected = PaymentMethodType.CreditCard)
        {
            //given
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentMethodType>().Use(
                        to =>
                        {
                            toFired = true;
                            return "FOO";
                        },
                        from =>
                        {
                            fromFired = true;
                            var value = from as string;
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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_nullable_enum_converter_when_value_doesnt_require_conversion(int version, PaymentSourceType expected = PaymentSourceType.Web)
        {
            //given
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentSourceType>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            var value = from as string;
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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_nullable_enum_converter_when_value_requires_conversion(int version, PaymentSourceType expected = PaymentSourceType.Web)
        {
            //given
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentSourceType>().Use(
                        to =>
                        {
                            toFired = true;
                            return "FOO";
                        },
                        from =>
                        {
                            fromFired = true;
                            var value = from as string;
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_nullable_datetime_converter_when_value_doesnt_require_conversion(int version)
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime?)from).Value.AddYears(-5) : (DateTime?)null;
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
            birthDate.Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_nullable_datetime_converter_when_value_is_null(int version)
        {
            //given
            DateTime expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return expected.AddYears(10);
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(DBNull.Value)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var birthDate = db.SelectOne(dbo.Person.BirthDate)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            birthDate.Value.Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_datetimeoffset_converter_when_value_doesnt_require_conversion(int version)
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTimeOffset>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTimeOffset)from).AddYears(-10) : (DateTimeOffset?)null;
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_nullable_datetime_converter_when_value_requires_conversion(int version)
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
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
            birthDate.Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_scalar_value_using_datetimeoffset_converter_when_value_requires_conversion(int version)
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTimeOffset?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTimeOffset)from).AddYears(-5) : (DateTimeOffset?)null;
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_nullable_datetime_converter_when_value_doesnt_require_conversion(int version)
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime?)from).Value.AddYears(-5) : (DateTime?)null;
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
            ((DateTime?)person.BirthDate).Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_datetimeoffset_field_converter_when_value_doesnt_require_conversion(int version)
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTimeOffset>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTimeOffset)from).AddYears(-10) : (DateTimeOffset?)null;
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
            ((DateTimeOffset)person.RegistrationDate).Year.Should().Be(expected.AddYears(-10).Year);
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_nullable_datetime_converter_when_value_requires_conversion(int version)
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
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
            ((DateTime?)person.BirthDate).Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_datetimeoffset_field_converter_when_value_requires_conversion(int version)
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTimeOffset?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTimeOffset)from).AddYears(-5) : (DateTimeOffset?)null;
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
            ((DateTimeOffset)person.RegistrationDate).Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_dynamic_using_nullable_datetime_converter_when_value_is_null(int version)
        {
            //given
            DateTime expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return expected.AddYears(10);
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime)from).AddYears(-5) : (DateTime?)from;
                        }
                    )
                )
            );

            db.Update(dbo.Person.BirthDate.Set(DBNull.Value)).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //when
            var person = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.BirthDate
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            //then
            ((DateTime?)person.BirthDate).Value.Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_entity_using_nullable_datetime_converter_when_value_doesnt_require_conversion(int version)
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime?)from).Value.AddYears(-5) : (DateTime?)null;
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
            ((DateTime?)person.BirthDate).Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_entity_using_datetimeoffset_converter_when_value_doesnt_require_conversion(int version)
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTimeOffset>().Use(
                        to => throw new NotImplementedException(),
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTimeOffset)from).AddYears(-10) : (DateTimeOffset?)null;
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
            ((DateTimeOffset)person.RegistrationDate).Year.Should().Be(expected.AddYears(-10).Year);
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_entity_using_nullable_datetime_converter_when_value_requires_conversion(int version)
        {
            //given
            DateTime? expected = DateTime.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTime>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTime?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTime)from).AddYears(-5) : (DateTime?)null;
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
            ((DateTime?)person.BirthDate).Value.Year.Should().Be(expected.Value.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_entity_using_datetimeoffset_converter_when_value_requires_conversion(int version)
        {
            //given
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            bool toFired = false;
            bool fromFired = false;

            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForType<DateTimeOffset>().Use(
                        to =>
                        {
                            toFired = true;
                            return to.HasValue ? to.Value.AddYears(10) : (DateTimeOffset?)null;
                        },
                        from =>
                        {
                            fromFired = true;
                            return from is object ? ((DateTimeOffset)from).AddYears(-5) : (DateTimeOffset?)null;
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
            ((DateTimeOffset)person.RegistrationDate).Year.Should().Be(expected.AddYears(5).Year);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_select_purchases_using_in_clause_of_list_of_enums_mapped_to_strings_result_in_correct_output(int version, int expectedCount = 9)
        {
            //given
            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentMethodType>().PersistAsString()
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

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_insert_and_select_purchase_with_alteration_of_payment_method_type_enum_result_in_correct_output(int version)
        {
            //given
            bool toFired = false;
            bool fromFired = false;
            ConfigureForMsSqlVersion(version, database => database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentMethodType>().Use(
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
            persisted.PaymentMethodType.Should().Be(PaymentMethodType.PayPal);
            toFired.Should().BeTrue();
            fromFired.Should().BeTrue();
        }
    }
}
