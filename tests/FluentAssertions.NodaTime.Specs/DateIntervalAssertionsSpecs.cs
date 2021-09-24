using System;
using System.Diagnostics.CodeAnalysis;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class DateIntervalAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_a_date_interval_is_equal_to_an_other_date_interval_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate start = LocalDate.FromDateTime(now.AddDays(-1));
                LocalDate end = LocalDate.FromDateTime(now.AddDays(1));
                DateInterval dateInterval = new DateInterval(start, end);
                DateInterval other = new DateInterval(start, end);

                // Act
                Action act = () => dateInterval.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_date_interval_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate start = LocalDate.FromDateTime(now.AddDays(-1));
                LocalDate end = LocalDate.FromDateTime(now.AddDays(1));
                DateInterval dateInterval = new DateInterval(start, end);

                // Act
                Action act = () => dateInterval.Should().Be(dateInterval);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                DateInterval? dateInterval = default;
                DateInterval? other = default;

                // Act
                Action act = () => dateInterval.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                DateInterval? dateInterval = default;
                DateTime now = DateTime.Now;
                LocalDate start = LocalDate.FromDateTime(now.AddDays(-1));
                LocalDate end = LocalDate.FromDateTime(now.AddDays(1));
                DateInterval other = new DateInterval(start, end);

                // Act
                Action act = () => dateInterval.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate start = LocalDate.FromDateTime(now.AddDays(-1));
                LocalDate end = LocalDate.FromDateTime(now.AddDays(1));
                DateInterval dateInterval = new DateInterval(start, end);
                DateInterval? other = default;

                // Act
                Action act = () => dateInterval.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to be equal to <null>, but found {dateInterval}.");
            }

            [Fact]
            public void When_a_date_interval_is_not_equal_to_an_other_date_interval_it_fails()
            {
                // Arrange
                DateInterval dateInterval = new DateInterval(LocalDate.MinIsoValue, LocalDate.MinIsoValue);
                DateInterval other = new DateInterval(LocalDate.MaxIsoValue, LocalDate.MaxIsoValue);

                // Act
                Action act = () => dateInterval.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to be equal to {other}, but found {dateInterval}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_a_date_interval_is_equal_to_an_other_date_interval_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate start = LocalDate.FromDateTime(now.AddDays(-1));
                LocalDate end = LocalDate.FromDateTime(now.AddDays(1));
                DateInterval dateInterval = new DateInterval(start, end);
                DateInterval other = new DateInterval(start, end);

                // Act
                Action act = () => dateInterval.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(dateInterval)} to be equal to {other}, but found {dateInterval}.");
            }

            [Fact]
            public void When_asserting_a_date_interval_is_equal_to_itself_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate start = LocalDate.FromDateTime(now.AddDays(-1));
                LocalDate end = LocalDate.FromDateTime(now.AddDays(1));
                DateInterval dateInterval = new DateInterval(start, end);

                // Act
                Action act = () => dateInterval.Should().NotBe(dateInterval);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(dateInterval)} to be equal to {dateInterval}, but found {dateInterval}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                DateInterval? dateInterval = default;
                DateInterval? other = default;

                // Act
                Action act = () => dateInterval.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(dateInterval)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_succeeds()
            {
                // Arrange
                DateInterval? dateInterval = default;
                DateTime now = DateTime.Now;
                LocalDate start = LocalDate.FromDateTime(now.AddDays(-1));
                LocalDate end = LocalDate.FromDateTime(now.AddDays(1));
                DateInterval other = new DateInterval(start, end);

                // Act
                Action act = () => dateInterval.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate start = LocalDate.FromDateTime(now.AddDays(-1));
                LocalDate end = LocalDate.FromDateTime(now.AddDays(1));
                DateInterval dateInterval = new DateInterval(start, end);
                DateInterval? other = default;

                // Act
                Action act = () => dateInterval.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_date_interval_is_not_equal_to_an_other_date_interval_it_succeeds()
            {
                // Arrange
                DateInterval dateInterval = new DateInterval(LocalDate.MinIsoValue, LocalDate.MinIsoValue);
                DateInterval other = new DateInterval(LocalDate.MaxIsoValue, LocalDate.MaxIsoValue);

                // Act
                Action act = () => dateInterval.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class EndAt
        {
            [Fact]
            public void When_a_date_interval_ends_at_the_specified_local_date_it_succeeds()
            {
                // Arrange
                LocalDate end = LocalDate.FromDateTime(DateTime.Now);
                DateInterval dateInterval = new DateInterval(LocalDate.MinIsoValue, end);

                // Act
                Action act = () => dateInterval.Should().EndAt(end);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_date_interval_does_not_end_at_the_specified_local_date_it_fails()
            {
                // Arrange
                LocalDate end = LocalDate.FromDateTime(DateTime.Now);
                LocalDate expectedEnd = end.PlusDays(1);
                DateInterval dateInterval = new DateInterval(end, end);

                // Act
                Action act = () => dateInterval.Should().EndAt(expectedEnd);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to end at {expectedEnd}, but {nameof(dateInterval)} ends at {end}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_ends_it_fails()
            {
                // Arrange
                LocalDate end = LocalDate.MaxIsoValue;
                DateInterval? dateInterval = default;

                // Act
                Action act = () => dateInterval.Should().EndAt(end);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to end at {end}, but found <null>.");
            }
        }

        public class NotEndAt
        {
            [Fact]
            public void When_a_date_interval_ends_at_the_specified_local_date_it_fails()
            {
                // Arrange
                LocalDate end = LocalDate.FromDateTime(DateTime.Now);
                DateInterval dateInterval = new DateInterval(LocalDate.MinIsoValue, end);

                // Act
                Action act = () => dateInterval.Should().NotEndAt(end);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(dateInterval)} to end at {end}.");
            }

            [Fact]
            public void When_a_date_interval_does_not_end_at_the_specified_local_date_it_succeeds()
            {
                // Arrange
                LocalDate end = LocalDate.FromDateTime(DateTime.Now);
                LocalDate expectedEnd = end.PlusDays(1);
                DateInterval dateInterval = new DateInterval(LocalDate.MinIsoValue, end);

                // Act
                Action act = () => dateInterval.Should().NotEndAt(expectedEnd);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_ends_it_fails()
            {
                // Arrange
                LocalDate end = LocalDate.MaxIsoValue;
                DateInterval? dateInterval = default;

                // Act
                Action act = () => dateInterval.Should().NotEndAt(end);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(dateInterval)} to end at {end}, but found <null>.");
            }
        }

        public class StartAt
        {
            [Fact]
            public void When_a_date_interval_starts_at_the_specified_local_date_it_succeeds()
            {
                // Arrange
                LocalDate start = LocalDate.FromDateTime(DateTime.Now);
                DateInterval dateInterval = new DateInterval(start, LocalDate.MaxIsoValue);

                // Act
                Action act = () => dateInterval.Should().StartAt(start);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_date_interval_does_not_start_at_the_specified_local_date_it_fails()
            {
                // Arrange
                LocalDate start = LocalDate.FromDateTime(DateTime.Now);
                LocalDate expectedStart = start.PlusDays(-1);
                DateInterval dateInterval = new DateInterval(start, LocalDate.MaxIsoValue);

                // Act
                Action act = () => dateInterval.Should().StartAt(expectedStart);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to start at {expectedStart}, but {nameof(dateInterval)} starts at {start}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_starts_it_fails()
            {
                // Arrange
                LocalDate start = LocalDate.MinIsoValue;
                DateInterval? dateInterval = default;

                // Act
                Action act = () => dateInterval.Should().StartAt(start);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to start at {start}, but found <null>.");
            }
        }

        public class NotStartAt
        {
            [Fact]
            public void When_a_date_interval_starts_at_the_specified_local_date_it_fails()
            {
                // Arrange
                LocalDate start = LocalDate.FromDateTime(DateTime.Now);
                DateInterval dateInterval = new DateInterval(start, LocalDate.MaxIsoValue);

                // Act
                Action act = () => dateInterval.Should().NotStartAt(start);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(dateInterval)} to start at {start}.");
            }

            [Fact]
            public void When_a_date_interval_does_not_start_at_the_specified_local_date_it_succeeds()
            {
                // Arrange
                LocalDate start = LocalDate.FromDateTime(DateTime.Now);
                LocalDate expectedStart = start.PlusDays(-1);
                DateInterval dateInterval = new DateInterval(start, LocalDate.MaxIsoValue);

                // Act
                Action act = () => dateInterval.Should().NotStartAt(expectedStart);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_starts_it_fails()
            {
                // Arrange
                LocalDate start = LocalDate.MinIsoValue;
                DateInterval? dateInterval = default;

                // Act
                Action act = () => dateInterval.Should().NotStartAt(start);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(dateInterval)} to start at {start}, but found <null>.");
            }
        }


        public class Contain
        {
            [Fact]
            public void When_a_date_interval_contains_the_local_date_it_succeeds()
            {
                // Arrange
                DateInterval dateInterval = new DateInterval(LocalDate.MinIsoValue, LocalDate.MaxIsoValue);
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now);

                // Act
                Action act = () => dateInterval.Should().Contain(localDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_date_interval_does_not_contain_the_local_date_it_fails()
            {
                // Arrange
                DateInterval dateInterval = new DateInterval(LocalDate.MaxIsoValue, LocalDate.MaxIsoValue);
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now);

                // Act
                Action act = () => dateInterval.Should().Contain(localDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to contain {localDate}.");
            }

            [Fact]
            public void When_asserting_a_null_date_interval_contains_an_local_date_it_fails()
            {
                DateInterval? dateInterval = null;
                LocalDate localDate = LocalDate.MaxIsoValue;

                // Act
                Action act = () => dateInterval.Should().Contain(localDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(dateInterval)} to contain {localDate}, but {nameof(dateInterval)} was <null>.");
            }
        }

        public class NotContain
        {
            [Fact]
            public void When_a_date_interval_does_not_contain_the_local_date_it_succeeds()
            {
                // Arrange
                DateInterval dateInterval = new DateInterval(LocalDate.MinIsoValue, LocalDate.MinIsoValue);
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now);

                // Act
                Action act = () => dateInterval.Should().NotContain(localDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_date_interval_does_not_contain_an_local_date_it_fails()
            {
                DateInterval? dateInterval = null;
                LocalDate localDate = LocalDate.MaxIsoValue;

                // Act
                Action act = () => dateInterval.Should().NotContain(localDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(dateInterval)} to contain {localDate}, but {nameof(dateInterval)} was <null>.");
            }
        }
    }
}
