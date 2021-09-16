using System;
using System.Diagnostics.CodeAnalysis;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class OffsetAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_an_offset_is_equal_to_an_other_offset_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Offset offset = Offset.FromTicks(ticks);
                Offset other = Offset.FromTicks(ticks);

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_an_offset_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Offset offset = Offset.FromTicks(ticks);

                // Act
                Action act = () => offset.Should().Be(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                Offset? offset = default;
                Offset? other = default;

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                Offset? offset = default;
                Offset other = Offset.Zero;

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                Offset offset = Offset.Zero;
                Offset? other = default;

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be equal to <null>, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_less_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be equal to {other}, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_greater_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be equal to {other}, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_equal_to_a_timespan_it_succeeds()
            {
                // Arrange
                Offset offset = Offset.FromTicks(new Random().Next());
                TimeSpan other = offset.ToTimeSpan();

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_less_than_a_timespan_it_fails()
            {
                // Arrange
                TimeSpan other = DateTimeOffset.Now.TimeOfDay;
                Offset offset = Offset.FromTimeSpan(other) - Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be equal to {Offset.FromTimeSpan(other)}, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_greater_than_a_timespan_it_fails()
            {
                // Arrange
                TimeSpan other = DateTimeOffset.Now.TimeOfDay;
                Offset offset = Offset.FromTimeSpan(other) + Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be equal to {Offset.FromTimeSpan(other)}, but found {offset}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_an_offset_is_less_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_greater_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_equal_to_an_other_offset_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Offset other = Offset.FromTicks(ticks);
                Offset offset = Offset.FromTicks(ticks);

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be equal to {other}, but found {offset}.");
            }

            [Fact]
            public void When_asserting_an_offset_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Offset offset = Offset.FromTicks(ticks);

                // Act
                Action act = () => offset.Should().NotBe(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be equal to {offset}, but found {offset}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                Offset? offset = default;
                Offset? other = default;

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be equal to <null>, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                Offset? offset = default;
                Offset other = Offset.Zero;

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                Offset offset = Offset.Zero;
                Offset? other = default;

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_equal_to_a_timespan_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromTicks(new Random().Next());
                TimeSpan other = offset.ToTimeSpan();

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be equal to {Offset.FromTimeSpan(other)}, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_less_than_a_timespan_it_succeeds()
            {
                // Arrange
                TimeSpan other = DateTimeOffset.Now.TimeOfDay;
                Offset offset = Offset.FromTimeSpan(other) - Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_greater_than_a_timespan_it_succeeds()
            {
                // Arrange
                TimeSpan other = DateTimeOffset.Now.TimeOfDay;
                Offset offset = Offset.FromTimeSpan(other) + Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class BeGreaterThan
        {
            [Fact]
            public void When_an_offset_is_greater_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeGreaterThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_less_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be greater than {other}, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_equal_to_an_other_offset_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Offset other = Offset.FromTicks(ticks);
                Offset offset = Offset.FromTicks(ticks);

                // Act
                Action act = () => offset.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be greater than {other}, but found {offset}.");
            }

            [Fact]
            public void When_asserting_an_offset_is_greater_than_itself_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromTicks(new Random().Next());

                // Act
                Action act = () => offset.Should().BeGreaterThan(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be greater than {offset}, but found {offset}.");
            }
        }

        public class BeGreaterThanOrEqualTo
        {
            [Fact]
            public void When_asserting_an_offset_is_greater_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                Offset offset = Offset.FromTicks(new Random().Next());

                // Act
                Action act = () => offset.Should().BeGreaterThanOrEqualTo(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_equal_to_an_other_offset_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Offset other = Offset.FromTicks(ticks);
                Offset offset = Offset.FromTicks(ticks);

                // Act
                Action act = () => offset.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_greater_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_less_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be greater than or equal to {other}, but found {offset}.");
            }
        }

        public class BeLessThan
        {
            [Fact]
            public void When_an_offset_is_less_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeLessThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_greater_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be less than {other}, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_equal_to_an_other_offset_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Offset other = Offset.FromTicks(ticks);
                Offset offset = Offset.FromTicks(ticks);

                // Act
                Action act = () => offset.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be less than {other}, but found {offset}.");
            }

            [Fact]
            public void When_asserting_an_offset_is_less_than_itself_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromTicks(new Random().Next());

                // Act
                Action act = () => offset.Should().BeLessThan(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be less than {offset}, but found {offset}.");
            }
        }

        public class BeLessThanOrEqualTo
        {
            [Fact]
            public void When_asserting_an_offset_is_less_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                Offset offset = Offset.FromTicks(new Random().Next());

                // Act
                Action act = () => offset.Should().BeLessThanOrEqualTo(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_equal_to_an_other_offset_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Offset other = Offset.FromTicks(ticks);
                Offset offset = Offset.FromTicks(ticks);

                // Act
                Action act = () => offset.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_less_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_greater_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be less than or equal to {other}, but found {offset}.");
            }
        }

        public class BeCloseTo
        {
            [Fact]
            public void When_the_precision_is_negative_it_fails()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(-1);
                Offset offset = Offset.FromTicks(new Random().Next());

                // Act
                Action withOffset = () => offset.Should().BeCloseTo(offset, precision);
                Action timesamp = () => offset.Should().BeCloseTo(offset, precision.ToTimeSpan());

                // Assert
                withOffset.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");

                timesamp.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");
            }

            [Fact]
            public void When_asserting_an_offset_is_close_to_itself_it_succeeds()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset offset = Offset.FromTicks(new Random().Next());

                // Act
                Action withOffset = () => offset.Should().BeCloseTo(offset, precision);
                Action timesamp = () => offset.Should().BeCloseTo(offset, precision.ToTimeSpan());

                // Assert
                withOffset.Should().NotThrow();
                timesamp.Should().NotThrow();
            }

            [Fact]
            public void When_two_offsets_are_equal_it_succeeds()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                long ticks = new Random().Next();
                Offset offset = Offset.FromTicks(ticks);
                Offset other = Offset.FromTicks(ticks);

                // Act
                Action withOffset = () => offset.Should().BeCloseTo(other, precision);
                Action timestamp = () => offset.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_close_to_but_less_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - precision;

                // Act
                Action withOffset = () => offset.Should().BeCloseTo(other, precision);
                Action timestamp = () => offset.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_close_to_but_greater_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + precision;

                // Act
                Action withOffset = () => offset.Should().BeCloseTo(other, precision);
                Action timestamp = () => offset.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_not_close_to_and_less_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - precision - Offset.FromSeconds(1);

                // Act
                Action withOffset = () => offset.Should().BeCloseTo(other, precision);
                Action timestamp = () => offset.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be within {precision} from {other}, but it was {other - offset}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be within {precision} from {other}, but it was {other - offset}.");
            }

            [Fact]
            public void When_an_offset_is_not_close_to_and_greater_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + precision + Offset.FromSeconds(1);

                // Act
                Action withOffset = () => offset.Should().BeCloseTo(other, precision);
                Action timestamp = () => offset.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(offset)} to be within {precision} from {other}, but it was {offset - other}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(offset)} to be within {precision} from {other}, but it was {offset - other}.");
            }
        }

        public class NotBeCloseTo
        {
            [Fact]
            public void When_an_offset_is_not_close_to_and_less_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - precision - Offset.FromSeconds(1);

                // Act
                Action withOffset = () => offset.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => offset.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_not_close_to_and_greater_than_an_other_offset_it_succeeds()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + precision + Offset.FromSeconds(1);

                // Act
                Action withOffset = () => offset.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => offset.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_the_precision_is_negative_it_fails()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(-1);
                Offset offset = Offset.FromTicks(new Random().Next());

                // Act
                Action withOffset = () => offset.Should().NotBeCloseTo(offset, precision);
                Action timesamp = () => offset.Should().NotBeCloseTo(offset, precision.ToTimeSpan());

                // Assert
                withOffset.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");

                timesamp.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");
            }

            [Fact]
            public void When_asserting_an_offset_is_not_close_to_itself_it_fails()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset offset = Offset.FromTicks(new Random().Next());

                // Act
                Action withOffset = () => offset.Should().NotBeCloseTo(offset, precision);
                Action timestamp = () => offset.Should().NotBeCloseTo(offset, precision.ToTimeSpan());

                // Assert
                withOffset.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be within {precision} from {offset}, but it was {Offset.Zero}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be within {precision} from {offset}, but it was {Offset.Zero}.");
            }

            [Fact]
            public void When_two_offsets_are_equal_it_fails()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                long ticks = new Random().Next();
                Offset offset = Offset.FromTicks(ticks);
                Offset other = Offset.FromTicks(ticks);

                // Act
                Action withOffset = () => offset.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => offset.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be within {precision} from {other}, but it was {Offset.Zero}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be within {precision} from {other}, but it was {Offset.Zero}.");
            }

            [Fact]
            public void When_an_offset_is_close_to_but_less_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other - precision;

                // Act
                Action withOffset = () => offset.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => offset.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be within {precision} from {other}, but it was {other - offset}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be within {precision} from {other}, but it was {other - offset}.");
            }

            [Fact]
            public void When_an_offset_is_close_to_but_greater_than_an_other_offset_it_fails()
            {
                // Arrange
                Offset precision = Offset.FromSeconds(new Random().Next(1, 100));
                Offset other = Offset.FromTicks(new Random().Next());
                Offset offset = other + precision;

                // Act
                Action withOffset = () => offset.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => offset.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withOffset.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be within {precision} from {other}, but it was {offset - other}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be within {precision} from {other}, but it was {offset - other}.");
            }
        }

        public class BePositive
        {
            [Fact]
            public void When_an_offset_is_positive_it_succeeds()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BePositive();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_negative_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(-1);

                // Act
                Action act = () => offset.Should().BePositive();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be positive, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_zero_it_fails()
            {
                // Arrange
                Offset offset = Offset.Zero;

                // Act
                Action act = () => offset.Should().BePositive();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be positive, but found {offset}.");
            }
        }

        public class BeNegative
        {
            [Fact]
            public void When_an_offset_is_negative_it_succeeds()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(-1);

                // Act
                Action act = () => offset.Should().BeNegative();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_positive_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeNegative();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be negative, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_zero_it_fails()
            {
                // Arrange
                Offset offset = Offset.Zero;

                // Act
                Action act = () => offset.Should().BeNegative();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be negative, but found {offset}.");
            }
        }

        public class BeZero
        {
            [Fact]
            public void When_an_offset_is_zero_it_succeeds()
            {
                // Arrange
                Offset offset = Offset.Zero;

                // Act
                Action act = () => offset.Should().BeZero();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_positive_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().BeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be zero, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_negative_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(-1);

                // Act
                Action act = () => offset.Should().BeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offset)} to be zero, but found {offset}.");
            }
        }

        public class NotBeZero
        {
            [Fact]
            public void When_an_offset_is_zero_it_fails()
            {
                // Arrange
                Offset offset = Offset.Zero;

                // Act
                Action act = () => offset.Should().NotBeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offset)} to be zero, but found {offset}.");
            }

            [Fact]
            public void When_an_offset_is_positive_it_suceeds()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);

                // Act
                Action act = () => offset.Should().NotBeZero();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_offset_is_negative_it_succeeds()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(-1);

                // Act
                Action act = () => offset.Should().NotBeZero();

                // Assert
                act.Should().NotThrow();
            }
        }
    }
}
