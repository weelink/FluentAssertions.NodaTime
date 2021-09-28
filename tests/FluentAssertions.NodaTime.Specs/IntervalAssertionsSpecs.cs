using System;
using System.Diagnostics.CodeAnalysis;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class IntervalAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_an_interval_is_equal_to_an_other_interval_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Instant end = Instant.FromDateTimeOffset(now.AddDays(1));
                Interval interval = new Interval(start, end);
                Interval other = new Interval(start, end);

                // Act
                Action act = () => interval.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_an_interval_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Instant end = Instant.FromDateTimeOffset(now.AddDays(1));
                Interval interval = new Interval(start, end);

                // Act
                Action act = () => interval.Should().Be(interval);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                Interval? interval = default;
                Interval? other = default;

                // Act
                Action act = () => interval.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                Interval? interval = default;
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Instant end = Instant.FromDateTimeOffset(now.AddDays(1));
                Interval other = new Interval(start, end);

                // Act
                Action act = () => interval.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Instant end = Instant.FromDateTimeOffset(now.AddDays(1));
                Interval interval = new Interval(start, end);
                Interval? other = default;

                // Act
                Action act = () => interval.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to be equal to <null>, but found {interval}.");
            }

            [Fact]
            public void When_an_interval_is_not_equal_to_an_other_interval_it_fails()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, Instant.MinValue);
                Interval other = new Interval(Instant.MaxValue, Instant.MaxValue);

                // Act
                Action act = () => interval.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to be equal to {other}, but found {interval}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_an_interval_is_equal_to_an_other_interval_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Instant end = Instant.FromDateTimeOffset(now.AddDays(1));
                Interval interval = new Interval(start, end);
                Interval other = new Interval(start, end);

                // Act
                Action act = () => interval.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to be equal to {other}, but found {interval}.");
            }

            [Fact]
            public void When_asserting_an_interval_is_equal_to_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Instant end = Instant.FromDateTimeOffset(now.AddDays(1));
                Interval interval = new Interval(start, end);

                // Act
                Action act = () => interval.Should().NotBe(interval);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to be equal to {interval}, but found {interval}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                Interval? interval = default;
                Interval? other = default;

                // Act
                Action act = () => interval.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_succeeds()
            {
                // Arrange
                Interval? interval = default;
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Instant end = Instant.FromDateTimeOffset(now.AddDays(1));
                Interval other = new Interval(start, end);

                // Act
                Action act = () => interval.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Instant end = Instant.FromDateTimeOffset(now.AddDays(1));
                Interval interval = new Interval(start, end);
                Interval? other = default;

                // Act
                Action act = () => interval.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_is_not_equal_to_an_other_interval_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, Instant.MinValue);
                Interval other = new Interval(Instant.MaxValue, Instant.MaxValue);

                // Act
                Action act = () => interval.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class HaveDuration
        {
            [Fact]
            public void When_an_interval_has_the_specified_duration_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Duration duration = Duration.FromDays(new Random().Next(100));
                Instant end = start + duration;
                Interval interval = new Interval(start, end);

                // Act
                Action act = () => interval.Should().HaveDuration(duration);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_the_specified_duration_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Duration duration = Duration.FromDays(new Random().Next(100));
                Duration expecteDuration = duration.Plus(Duration.FromMilliseconds(1));
                Instant end = start + duration;
                Interval interval = new Interval(start, end);

                // Act
                Action act = () => interval.Should().HaveDuration(expecteDuration);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to have a duration of {expecteDuration}, but found {interval.Duration}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_interval_has_the_specified_duration_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(100));
                Interval? interval = null;

                // Act
                Action act = () => interval.Should().HaveDuration(duration);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to have a duration of {duration}, but found <null>.");
            }
        }

        public class NotHaveDuration
        {
            [Fact]
            public void When_an_interval_has_the_specified_duration_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Duration duration = Duration.FromDays(new Random().Next(100));
                Instant end = start + duration;
                Interval interval = new Interval(start, end);

                // Act
                Action act = () => interval.Should().NotHaveDuration(interval.Duration);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to have a duration of {interval.Duration}.");
            }

            [Fact]
            public void When_an_interval_does_not_have_the_specified_duration_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant start = Instant.FromDateTimeOffset(now.AddDays(-1));
                Duration duration = Duration.FromDays(new Random().Next(100));
                Instant end = start + duration;
                Interval interval = new Interval(start, end);

                // Act
                Action act = () => interval.Should().NotHaveDuration(duration.Plus(Duration.FromMilliseconds(1)));

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_interval_does_not_have_the_specified_duration_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(100));
                Interval? interval = null;

                // Act
                Action act = () => interval.Should().NotHaveDuration(duration);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to have a duration of {duration}, but found <null>.");
            }
        }

        public class EndAt
        {
            [Fact]
            public void When_an_interval_ends_at_the_specified_instant_it_succeeds()
            {
                // Arrange
                Instant end = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Interval interval = new Interval(null, end);

                // Act
                Action act = () => interval.Should().EndAt(end);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_end_at_the_specified_instant_it_fails()
            {
                // Arrange
                Instant expectedEnd = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant end = expectedEnd.PlusNanoseconds(1);
                Interval interval = new Interval(null, expectedEnd);

                // Act
                Action act = () => interval.Should().EndAt(end);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to end at {end}, but {nameof(interval)} ends at {expectedEnd}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_an_interval_that_does_not_end_ends_it_fails()
            {
                // Arrange
                Instant end = Instant.MaxValue;
                Interval interval = new Interval(Instant.MinValue, null);

                // Act
                Action act = () => interval.Should().EndAt(end);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to end at {end}, but {nameof(interval)} does not end.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_ends_it_fails()
            {
                // Arrange
                Instant end = Instant.MaxValue;
                Interval? interval = default;

                // Act
                Action act = () => interval.Should().EndAt(end);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to end at {end}, but found <null>.");
            }
        }

        public class NotEndAt
        {
            [Fact]
            public void When_an_interval_ends_at_the_specified_instant_it_fails()
            {
                // Arrange
                Instant end = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Interval interval = new Interval(null, end);

                // Act
                Action act = () => interval.Should().NotEndAt(end);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to end at {end}.");
            }

            [Fact]
            public void When_an_interval_does_not_end_at_the_specified_instant_it_succeeds()
            {
                // Arrange
                Instant expectedEnd = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant end = expectedEnd.PlusNanoseconds(1);
                Interval interval = new Interval(null, expectedEnd);

                // Act
                Action act = () => interval.Should().NotEndAt(end);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_an_interval_that_does_not_end_ends_it_succeeds()
            {
                // Arrange
                Instant end = Instant.MaxValue;
                Interval interval = new Interval(Instant.MinValue, null);

                // Act
                Action act = () => interval.Should().NotEndAt(end);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_ends_it_fails()
            {
                // Arrange
                Instant end = Instant.MaxValue;
                Interval? interval = default;

                // Act
                Action act = () => interval.Should().NotEndAt(end);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to end at {end}, but found <null>.");
            }
        }

        public class End
        {
            [Fact]
            public void When_an_interval_has_an_end_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(null, Instant.MaxValue);

                // Act
                Action act = () => interval.Should().End();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_an_end_it_fails()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, null);

                // Act
                Action act = () => interval.Should().End();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to have an end.");
            }

            [Fact]
            public void When_asserting_a_null_interval_has_the_specified_minutes_it_fails()
            {
                Interval? interval = null;

                // Act
                Action act = () => interval.Should().End();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to have an end, but found <null>.");
            }
        }

        public class NotEnd
        {
            [Fact]
            public void When_an_interval_does_not_have_an_end_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, null);

                // Act
                Action act = () => interval.Should().NotEnd();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_has_an_end_it_fails()
            {
                // Arrange
                Instant end = Instant.MaxValue;
                Interval interval = new Interval(null, end);

                // Act
                Action act = () => interval.Should().NotEnd();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to have an end, but found {end}.");
            }

            [Fact]
            public void When_asserting_a_null_interval_does_not_have_an_end_it_fails()
            {
                Interval? interval = null;

                // Act
                Action act = () => interval.Should().NotEnd();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to have an end, but found <null>.");
            }
        }

        public class StartAt
        {
            [Fact]
            public void When_an_interval_starts_at_the_specified_instant_it_succeeds()
            {
                // Arrange
                Instant start = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Interval interval = new Interval(start, null);

                // Act
                Action act = () => interval.Should().StartAt(start);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_start_at_the_specified_instant_it_fails()
            {
                // Arrange
                Instant expectedStart = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant start = expectedStart.PlusNanoseconds(1);
                Interval interval = new Interval(expectedStart, null);

                // Act
                Action act = () => interval.Should().StartAt(start);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to start at {start}, but {nameof(interval)} starts at {expectedStart}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_an_interval_that_does_not_start_starts_it_fails()
            {
                // Arrange
                Instant start = Instant.MinValue;
                Interval interval = new Interval(null, Instant.MaxValue);

                // Act
                Action act = () => interval.Should().StartAt(start);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to start at {start}, but {nameof(interval)} does not start.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_starts_it_fails()
            {
                // Arrange
                Instant start = Instant.MinValue;
                Interval? interval = default;

                // Act
                Action act = () => interval.Should().StartAt(start);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to start at {start}, but found <null>.");
            }
        }

        public class NotStartAt
        {
            [Fact]
            public void When_an_interval_starts_at_the_specified_instant_it_fails()
            {
                // Arrange
                Instant start = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Interval interval = new Interval(start, null);

                // Act
                Action act = () => interval.Should().NotStartAt(start);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to start at {start}.");
            }

            [Fact]
            public void When_an_interval_does_not_start_at_the_specified_instant_it_succeeds()
            {
                // Arrange
                Instant expectedStart = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant start = expectedStart.PlusNanoseconds(1);
                Interval interval = new Interval(expectedStart, null);

                // Act
                Action act = () => interval.Should().NotStartAt(start);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_an_interval_that_does_not_start_starts_it_succeeds()
            {
                // Arrange
                Instant start = Instant.MinValue;
                Interval interval = new Interval(null, Instant.MaxValue);

                // Act
                Action act = () => interval.Should().NotStartAt(start);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_starts_it_fails()
            {
                // Arrange
                Instant start = Instant.MinValue;
                Interval? interval = default;

                // Act
                Action act = () => interval.Should().NotStartAt(start);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to start at {start}, but found <null>.");
            }
        }

        public class Start
        {
            [Fact]
            public void When_an_interval_has_a_start_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, null);

                // Act
                Action act = () => interval.Should().Start();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_a_start_it_fails()
            {
                // Arrange
                Interval interval = new Interval(null, Instant.MaxValue);

                // Act
                Action act = () => interval.Should().Start();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to have a start.");
            }

            [Fact]
            public void When_asserting_a_null_interval_has_the_specified_minutes_it_fails()
            {
                Interval? interval = null;

                // Act
                Action act = () => interval.Should().Start();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to have a start, but found <null>.");
            }
        }

        public class NotStart
        {
            [Fact]
            public void When_an_interval_does_not_have_a_start_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(null, Instant.MaxValue);

                // Act
                Action act = () => interval.Should().NotStart();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_has_a_start_it_fails()
            {
                // Arrange
                Instant start = Instant.MinValue;
                Interval interval = new Interval(start, null);

                // Act
                Action act = () => interval.Should().NotStart();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to have a start, but found {start}.");
            }

            [Fact]
            public void When_asserting_a_null_interval_does_not_have_a_start_it_fails()
            {
                Interval? interval = null;

                // Act
                Action act = () => interval.Should().NotStart();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to have a start, but found <null>.");
            }
        }

        public class Contain
        {
            [Fact]
            public void When_an_interval_contains_the_instant_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, Instant.MaxValue);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => interval.Should().Contain(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_a_start_and_contains_the_instant_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(null, Instant.MaxValue);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => interval.Should().Contain(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_an_end_and_contains_the_instant_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, null);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => interval.Should().Contain(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_a_start_and_not_have_an_end_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(null, null);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => interval.Should().Contain(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_contain_the_instant_it_fails()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, Instant.MinValue);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                // Act
                Action act = () => interval.Should().Contain(instant);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to contain {instant}.");
            }

            [Fact]
            public void When_asserting_a_null_interval_contains_an_instant_it_fails()
            {
                Interval? interval = null;
                Instant instant = Instant.MaxValue;

                // Act
                Action act = () => interval.Should().Contain(instant);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(interval)} to contain {instant}, but found <null>.");
            }
        }

        public class NotContain
        {
            [Fact]
            public void When_an_interval_does_not_contain_the_instant_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(Instant.MinValue, Instant.MinValue);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => interval.Should().NotContain(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_a_start_and_does_not_contain_the_instant_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(null, Instant.MinValue);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => interval.Should().NotContain(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_an_end_and_does_not_contain_the_instant_it_succeeds()
            {
                // Arrange
                Interval interval = new Interval(Instant.MaxValue, null);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => interval.Should().NotContain(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_interval_does_not_have_a_start_and_not_have_an_end_it_fails()
            {
                // Arrange
                Interval interval = new Interval(null, null);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => interval.Should().NotContain(instant);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to contain {instant}.");
            }

            [Fact]
            public void When_asserting_a_null_interval_does_not_contain_an_instant_it_fails()
            {
                Interval? interval = null;
                Instant instant = Instant.MaxValue;

                // Act
                Action act = () => interval.Should().NotContain(instant);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(interval)} to contain {instant}, but found <null>.");
            }
        }
    }
}
