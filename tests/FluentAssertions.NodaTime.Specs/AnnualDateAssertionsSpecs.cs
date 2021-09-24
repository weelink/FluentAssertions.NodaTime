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

        public class BeAfter
        {
            [Fact]
            public void When_an_annual_date_is_after_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeAfter(other);

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
                Action act = () => annualDate.Should().BeAfter(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be after {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_an_annual_date_is_equal_to_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeAfter(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be after {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_asserting_an_annual_date_is_after_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeAfter(annualDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be after {annualDate}, but found {annualDate}.");
            }
        }

        public class BeOnOrAfter
        {
            [Fact]
            public void When_asserting_an_annual_date_is_on_or_after_itself_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeOnOrAfter(annualDate);

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
                Action act = () => annualDate.Should().BeOnOrAfter(other);

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
                Action act = () => annualDate.Should().BeOnOrAfter(other);

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
                Action act = () => annualDate.Should().BeOnOrAfter(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be on or after {other}, but found {annualDate}.");
            }
        }

        public class BeBefore
        {
            [Fact]
            public void When_an_annual_date_is_before_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(-1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeBefore(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_after_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeBefore(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be before {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_an_annual_date_is_equal_to_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeBefore(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be before {other}, but found {annualDate}.");
            }

            [Fact]
            public void When_asserting_an_annual_date_is_before_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeBefore(annualDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be before {annualDate}, but found {annualDate}.");
            }
        }

        public class BeOnOrBefore
        {
            [Fact]
            public void When_asserting_an_annual_date_is_on_or_before_itself_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate annualDate = new AnnualDate(now.Month, 1);

                // Act
                Action act = () => annualDate.Should().BeOnOrBefore(annualDate);

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
                Action act = () => annualDate.Should().BeOnOrBefore(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_before_an_other_annual_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(-1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeOnOrBefore(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_annual_date_is_after_an_other_annual_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                AnnualDate other = new AnnualDate(now.Month, 1);
                AnnualDate annualDate = new AnnualDate(now.AddMonths(1).Month, 1);

                // Act
                Action act = () => annualDate.Should().BeOnOrBefore(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(annualDate)} to be on or before {other}, but found {annualDate}.");
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
    }
}
