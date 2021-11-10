using System;
using System.Diagnostics.CodeAnalysis;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class AnnualDateAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_an_annual_date_is_equal_to_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);
                AnnualDate other = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_an_annual_date_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().Be(annualDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                AnnualDate? annualDate = default;
                AnnualDate? other = default;

                // Act
                Action act = () => annualDate.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate? annualDate = default;
                AnnualDate other = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);
                AnnualDate? other = default;

                // Act
                Action act = () => annualDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be equal to <null>, but found {annualDate}.");
            }

            [Fact]
            public void When_an_annual_date_is_before_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(-1).Month, 1);

                // Act
                Action act = () => annualDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be equal to {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_an_annual_date_is_after_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be equal to {other}, but found {annualDate}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_an_annual_date_is_before_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(-1).Month, 1);

                // Act
                Action act = () => annualDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_after_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_equal_to_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);
                AnnualDate other = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to be equal to {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_asserting_an_annual_date_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().NotBe(annualDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to be equal to {annualDate}, but found {annualDate}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                AnnualDate? annualDate = default;
                AnnualDate? other = default;

                // Act
                Action act = () => annualDate.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to be equal to <null>, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate? annualDate = default;
                AnnualDate other = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);
                AnnualDate? other = default;

                // Act
                Action act = () => annualDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class BeGreaterThan
        {
            [Fact]
            public void When_an_annual_date_is_greater_than_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeGreaterThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_less_than_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(-1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be greater than {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_an_annual_date_is_equal_to_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be greater than {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_asserting_an_annual_date_is_greater_than_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeGreaterThan(annualDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be greater than {annualDate}, but found {annualDate}.");
            }
        }

        public class BeGreaterThanOrEqualTo
        {
            [Fact]
            public void When_asserting_an_annual_date_is_greater_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeGreaterThanOrEqualTo(annualDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_equal_to_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);
                AnnualDate other = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_greater_than_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_before_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(-1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be greater than or equal to {other}, but found {annualDate}.");
            }
        }

        public class BeLessThan
        {
            [Fact]
            public void When_an_annual_date_is_less_than_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(-1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeLessThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_greater_than_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be less than {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_an_annual_date_is_equal_to_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be less than {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_asserting_an_annual_date_is_less_than_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeLessThan(annualDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be less than {annualDate}, but found {annualDate}.");
            }
        }

        public class BeLessThanOrEqualTo
        {
            [Fact]
            public void When_asserting_an_annual_date_is_less_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeLessThanOrEqualTo(annualDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_equal_to_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_less_than_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(-1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_greater_than_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be less than or equal to {other}, but found {annualDate}.");
            }
        }

        public class BeValidInYear
        {
            [Fact]
            public void When_an_annual_date_is_valid_for_the_specified_year_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);

                // Act
                Action act = () => annualDate.Should().BeValidInYear(now.Year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_not_valid_for_the_specified_year_it_fails()
            {
                // Arrange
                const int nonLeapYear = 2021;
                AnnualDate annualDate = new AnnualDate(2, 29);

                // Act
                Action act = () => annualDate.Should().BeValidInYear(nonLeapYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be valid in year {nonLeapYear}.");
            }

            [Fact]
            public void When_asserting_an_null_annual_date_it_fails()
            {
                // Arrange
                const int year = 2021;
                AnnualDate? annualDate = default;

                // Act
                Action act = () => annualDate.Should().BeValidInYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be valid in year {year}, but found <null>.");
            }
        }

        public class NotBeValidInYear
        {
            [Fact]
            public void When_an_annual_date_is_valid_for_the_specified_year_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);

                // Act
                Action act = () => annualDate.Should().NotBeValidInYear(now.Year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to be valid in year {now.Year}.");
            }

            [Fact]
            public void When_an_annual_date_is_not_valid_for_the_specified_year_it_succeeds()
            {
                // Arrange
                const int nonLeapYear = 2021;
                AnnualDate annualDate = new AnnualDate(2, 29);

                // Act
                Action act = () => annualDate.Should().NotBeValidInYear(nonLeapYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_an_null_annual_date_it_fails()
            {
                // Arrange
                const int year = 2021;
                AnnualDate? annualDate = default;

                // Act
                Action act = () => annualDate.Should().NotBeValidInYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to be valid in year {year}, but found <null>.");
            }
        }
        public class HaveDay
        {
            [Fact]
            public void When_a_annual_date_has_the_specified_day_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);

                // Act
                Action act = () => annualDate.Should().HaveDay(annualDate.Day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_annual_date_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);
                int day = annualDate.Day + 1;

                // Act
                Action act = () => annualDate.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to have day {day}, but found {annualDate.Day}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_annual_date_has_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                AnnualDate? annualDate = null;

                // Act
                Action act = () => annualDate.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to have day {day}, but found <null>.");
            }
        }

        public class NotHaveDay
        {
            [Fact]
            public void When_a_annual_date_has_the_specified_day_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);

                // Act
                Action act = () => annualDate.Should().NotHaveDay(annualDate.Day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to have day {annualDate.Day}.");
            }

            [Fact]
            public void When_a_annual_date_does_not_have_the_specified_day_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);
                int day = annualDate.Day + 1;

                // Act
                Action act = () => annualDate.Should().NotHaveDay(day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_annual_date_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                AnnualDate? annualDate = null;

                // Act
                Action act = () => annualDate.Should().NotHaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to have day {day}, but found <null>.");
            }
        }

        public class HaveMonth
        {
            [Fact]
            public void When_a_annual_date_has_the_specified_month_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);

                // Act
                Action act = () => annualDate.Should().HaveMonth(annualDate.Month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_annual_date_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);
                int month = annualDate.Month + 1;

                // Act
                Action act = () => annualDate.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to have month {month}, but found {annualDate.Month}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_annual_date_has_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                AnnualDate? annualDate = null;

                // Act
                Action act = () => annualDate.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to have month {month}, but found <null>.");
            }
        }

        public class NotHaveMonth
        {
            [Fact]
            public void When_a_annual_date_has_the_specified_month_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);

                // Act
                Action act = () => annualDate.Should().NotHaveMonth(annualDate.Month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to have month {annualDate.Month}.");
            }

            [Fact]
            public void When_a_annual_date_does_not_have_the_specified_month_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, now.Day);
                int month = annualDate.Month + 1;

                // Act
                Action act = () => annualDate.Should().NotHaveMonth(month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_annual_date_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                AnnualDate? annualDate = null;

                // Act
                Action act = () => annualDate.Should().NotHaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(annualDate)} to have month {month}, but found <null>.");
            }
        }
    }
}
