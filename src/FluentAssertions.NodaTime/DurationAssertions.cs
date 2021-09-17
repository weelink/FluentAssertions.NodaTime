using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.NodaTime.Extensions;
using FluentAssertions.Primitives;

using NodaTime;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="Duration" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class DurationAssertions : ReferenceTypeAssertions<Duration?, DurationAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="DurationAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="Duration" /> that is being asserted.</param>
        public DurationAssertions(Duration? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier
        {
            get { return "Duration"; }
        }
        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> Be(Duration? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition((Subject.HasValue && Subject.Equals(other)) || (!Subject.HasValue && !other.HasValue))
                .FailWith("Expected {context:Duration} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> Be(TimeSpan? other, string because = "", params object[] becauseArgs)
        {
            return Be(other.HasValue ? Duration.FromTimeSpan(other.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotBe(Duration? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition((Subject.HasValue && !Subject.Equals(other)) || (!Subject.HasValue && other.HasValue))
                .FailWith("Did not expect {context:Duration} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotBe(TimeSpan? other, string because = "", params object[] becauseArgs)
        {
            return NotBe(other.HasValue ? Duration.FromTimeSpan(other.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is positive.
        /// </summary>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BePositive(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > Duration.Zero)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Duration} to be positive, but found {0}.", Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is negative.
        /// </summary>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BeNegative(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < Duration.Zero)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Duration} to be negative, but found {0}.", Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is zero.
        /// </summary>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BeZero(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject == Duration.Zero)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Duration} to be zero, but found {0}.", Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is not zero.
        /// </summary>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotBeZero(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject != Duration.Zero)
                .BecauseOf(because, becauseArgs)
                .FailWith("Did not expect {context:Duration} to be zero, but found {0}.", Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BeCloseTo(Duration other, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return BeCloseTo(other, Duration.FromTimeSpan(precision), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BeCloseTo(Duration other, Duration precision, string because = "", params object[] becauseArgs)
        {
            if (precision < Duration.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), $"The value of {nameof(precision)} must be non-negative.");
            }

            Duration? distance = other > Subject ? other - Subject : Subject - other;
            Execute.Assertion
                .ForCondition(distance <= precision)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Duration} to be within {0} from {1}{reason}, but it was {2}.", precision, other, distance);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is not within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotBeCloseTo(Duration other, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return NotBeCloseTo(other, Duration.FromTimeSpan(precision), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is not within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotBeCloseTo(Duration other, Duration precision, string because = "", params object[] becauseArgs)
        {
            if (precision < Duration.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), $"The value of {nameof(precision)} must be non-negative.");
            }

            Duration? distance = other > Subject ? other - Subject : Subject - other;
            Execute.Assertion
                .ForCondition(distance > precision)
                .BecauseOf(because, becauseArgs)
                .FailWith("Did not expect {context:Duration} to be within {0} from {1}{reason}, but it was {2}.", precision, other, distance);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is greater than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BeGreaterThan(Duration other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Duration} to be greater than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is on or after <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BeGreaterThanOrEqualTo(Duration other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject >= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Duration} to be greater than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is less than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BeLessThan(Duration other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Duration} to be less than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Duration" /> is less than or equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Duration" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> BeLessThanOrEqualTo(Duration other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject <= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Duration} to be less than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified seconds.
        /// </summary>
        /// <param name="seconds">
        ///     The seconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveSeconds(int seconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} seconds{reason}", seconds);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Seconds.Equals(seconds))
                    .FailWith(", but found {0}.", Subject.Value.Seconds);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified seconds.
        /// </summary>
        /// <param name="seconds">
        ///     The seconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveSeconds(int seconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} seconds{reason}", seconds);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Seconds.Equals(seconds))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified days.
        /// </summary>
        /// <param name="days">
        ///     The days that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveDays(int days, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} days{reason}", days);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Days.Equals(days))
                    .FailWith(", but found {0}.", Subject.Value.Days);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified days.
        /// </summary>
        /// <param name="days">
        ///     The days that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveDays(int days, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} days{reason}", days);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Days.Equals(days))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of days.
        /// </summary>
        /// <param name="totalDays">
        ///     The total number of days that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalDays(double totalDays, string because = "", params object[] becauseArgs)
        {
            return HaveTotalDays(totalDays, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of days.
        /// </summary>
        /// <param name="totalDays">
        ///     The total number of days that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalDays(double totalDays, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} total number of days (+/- {1}){reason}", totalDays, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TotalDays.IsApproximatelyEqual(totalDays, precision))
                    .FailWith(", but found {0}.", Subject.Value.TotalDays);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of days.
        /// </summary>
        /// <param name="totalDays">
        ///     The total number of days that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalDays(double totalDays, string because = "", params object[] becauseArgs)
        {
            return NotHaveTotalDays(totalDays, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of days.
        /// </summary>
        /// <param name="totalDays">
        ///     The total number of days that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalDays(double totalDays, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} total number of days (+/- {1}){reason}", totalDays, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TotalDays.IsApproximatelyEqual(totalDays, precision))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of milliseconds.
        /// </summary>
        /// <param name="totalMilliseconds">
        ///     The total number of milliseconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalMilliseconds(double totalMilliseconds, string because = "", params object[] becauseArgs)
        {
            return HaveTotalMilliseconds(totalMilliseconds, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of milliseconds.
        /// </summary>
        /// <param name="totalMilliseconds">
        ///     The total number of milliseconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalMilliseconds(double totalMilliseconds, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} total number of milliseconds (+/- {1}){reason}", totalMilliseconds, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TotalMilliseconds.IsApproximatelyEqual(totalMilliseconds, precision))
                    .FailWith(", but found {0}.", Subject.Value.TotalMilliseconds);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of milliseconds.
        /// </summary>
        /// <param name="totalMilliseconds">
        ///     The total number of milliseconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalMilliseconds(double totalMilliseconds, string because = "", params object[] becauseArgs)
        {
            return NotHaveTotalMilliseconds(totalMilliseconds, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of milliseconds.
        /// </summary>
        /// <param name="totalMilliseconds">
        ///     The total number of milliseconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalMilliseconds(double totalMilliseconds, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} total number of milliseconds (+/- {1}){reason}", totalMilliseconds, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TotalMilliseconds.IsApproximatelyEqual(totalMilliseconds, precision))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of minutes.
        /// </summary>
        /// <param name="totalMinutes">
        ///     The total number of minutes that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalMinutes(double totalMinutes, string because = "", params object[] becauseArgs)
        {
            return HaveTotalMinutes(totalMinutes, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of minutes.
        /// </summary>
        /// <param name="totalMinutes">
        ///     The total number of minutes that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalMinutes(double totalMinutes, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} total number of minutes (+/- {1}){reason}", totalMinutes, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TotalMinutes.IsApproximatelyEqual(totalMinutes, precision))
                    .FailWith(", but found {0}.", Subject.Value.TotalMinutes);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of minutes.
        /// </summary>
        /// <param name="totalMinutes">
        ///     The total number of minutes that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalMinutes(double totalMinutes, string because = "", params object[] becauseArgs)
        {
            return NotHaveTotalMinutes(totalMinutes, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of minutes.
        /// </summary>
        /// <param name="totalMinutes">
        ///     The total number of minutes that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalMinutes(double totalMinutes, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} total number of minutes (+/- {1}){reason}", totalMinutes, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TotalMinutes.IsApproximatelyEqual(totalMinutes, precision))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of nanoseconds.
        /// </summary>
        /// <param name="totalNanoseconds">
        ///     The total number of nanoseconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalNanoseconds(double totalNanoseconds, string because = "", params object[] becauseArgs)
        {
            return HaveTotalNanoseconds(totalNanoseconds, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of nanoseconds.
        /// </summary>
        /// <param name="totalNanoseconds">
        ///     The total number of nanoseconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalNanoseconds(double totalNanoseconds, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} total number of nanoseconds (+/- {1}){reason}", totalNanoseconds, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TotalNanoseconds.IsApproximatelyEqual(totalNanoseconds, precision))
                    .FailWith(", but found {0}.", Subject.Value.TotalNanoseconds);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of nanoseconds.
        /// </summary>
        /// <param name="totalNanoseconds">
        ///     The total number of nanoseconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalNanoseconds(double totalNanoseconds, string because = "", params object[] becauseArgs)
        {
            return NotHaveTotalNanoseconds(totalNanoseconds, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of nanoseconds.
        /// </summary>
        /// <param name="totalNanoseconds">
        ///     The total number of nanoseconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalNanoseconds(double totalNanoseconds, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} total number of nanoseconds (+/- {1}){reason}", totalNanoseconds, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TotalNanoseconds.IsApproximatelyEqual(totalNanoseconds, precision))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of seconds.
        /// </summary>
        /// <param name="totalSeconds">
        ///     The total number of seconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalSeconds(double totalSeconds, string because = "", params object[] becauseArgs)
        {
            return HaveTotalSeconds(totalSeconds, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of seconds.
        /// </summary>
        /// <param name="totalSeconds">
        ///     The total number of seconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalSeconds(double totalSeconds, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} total number of seconds (+/- {1}){reason}", totalSeconds, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TotalSeconds.IsApproximatelyEqual(totalSeconds, precision))
                    .FailWith(", but found {0}.", Subject.Value.TotalSeconds);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of seconds.
        /// </summary>
        /// <param name="totalSeconds">
        ///     The total number of seconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalSeconds(double totalSeconds, string because = "", params object[] becauseArgs)
        {
            return NotHaveTotalSeconds(totalSeconds, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of seconds.
        /// </summary>
        /// <param name="totalSeconds">
        ///     The total number of seconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalSeconds(double totalSeconds, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} total number of seconds (+/- {1}){reason}", totalSeconds, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TotalSeconds.IsApproximatelyEqual(totalSeconds, precision))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of ticks.
        /// </summary>
        /// <param name="totalTicks">
        ///     The total number of ticks that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalTicks(double totalTicks, string because = "", params object[] becauseArgs)
        {
            return HaveTotalTicks(totalTicks, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified total number of ticks.
        /// </summary>
        /// <param name="totalTicks">
        ///     The total number of ticks that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTotalTicks(double totalTicks, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} total number of ticks (+/- {1}){reason}", totalTicks, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TotalTicks.IsApproximatelyEqual(totalTicks, precision))
                    .FailWith(", but found {0}.", Subject.Value.TotalTicks);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of ticks.
        /// </summary>
        /// <param name="totalTicks">
        ///     The total number of ticks that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalTicks(double totalTicks, string because = "", params object[] becauseArgs)
        {
            return NotHaveTotalTicks(totalTicks, 0.01, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified total number of ticks.
        /// </summary>
        /// <param name="totalTicks">
        ///     The total number of ticks that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="precision">The maximum amount of which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTotalTicks(double totalTicks, double precision, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} total number of ticks (+/- {1}){reason}", totalTicks, precision);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TotalTicks.IsApproximatelyEqual(totalTicks, precision))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified milliseconds.
        /// </summary>
        /// <param name="milliseconds">
        ///     The milliseconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveMilliseconds(int milliseconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} milliseconds{reason}", milliseconds);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Milliseconds.Equals(milliseconds))
                    .FailWith(", but found {0}.", Subject.Value.Milliseconds);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified milliseconds.
        /// </summary>
        /// <param name="milliseconds">
        ///     The milliseconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveMilliseconds(int milliseconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} milliseconds{reason}", milliseconds);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Milliseconds.Equals(milliseconds))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified minutes.
        /// </summary>
        /// <param name="minutes">
        ///     The minutes that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveMinutes(int minutes, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} minutes{reason}", minutes);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Minutes.Equals(minutes))
                    .FailWith(", but found {0}.", Subject.Value.Minutes);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified minutes.
        /// </summary>
        /// <param name="minutes">
        ///     The minutes that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveMinutes(int minutes, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} minutes{reason}", minutes);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Minutes.Equals(minutes))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified nanosecond of day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanosecond of day that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveNanosecondOfDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have nanosecond of day {0}{reason}", nanosecondOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.NanosecondOfDay.Equals(nanosecondOfDay))
                    .FailWith(", but found {0}.", Subject.Value.NanosecondOfDay);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified nanosecond of day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanosecond of day that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveNanosecondOfDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have nanosecond of day {0}{reason}",
                        nanosecondOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.NanosecondOfDay.Equals(nanosecondOfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified subseconds in nanoseconds.
        /// </summary>
        /// <param name="nanoseconds">
        ///     The subseconds in nanoseconds that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveSubsecondInNanoseconds(int nanoseconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} subseconds in nanoseconds{reason}", nanoseconds);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.SubsecondNanoseconds.Equals(nanoseconds))
                    .FailWith(", but found {0}.", Subject.Value.SubsecondNanoseconds);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified subseconds in nanoseconds.
        /// </summary>
        /// <param name="nanoseconds">
        ///     The subseconds in nanoseconds that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveSubsecondInNanoseconds(int nanoseconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} subseconds in nanoseconds{reason}", nanoseconds);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.SubsecondNanoseconds.Equals(nanoseconds))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified subseconds in ticks.
        /// </summary>
        /// <param name="ticks">
        ///     The subseconds in ticks that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveSubsecondInTicks(int ticks, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} subseconds in ticks{reason}", ticks);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.SubsecondTicks.Equals(ticks))
                    .FailWith(", but found {0}.", Subject.Value.SubsecondTicks);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified subseconds in ticks.
        /// </summary>
        /// <param name="ticks">
        ///     The subseconds in ticks that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveSubsecondInTicks(int ticks, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} subseconds in ticks{reason}", ticks);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.SubsecondTicks.Equals(ticks))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> has the specified ticks.
        /// </summary>
        /// <param name="ticks">
        ///     The ticks that the current <see cref="Duration" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> HaveTicks(long ticks, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Duration} to have {0} ticks{reason}", ticks);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.BclCompatibleTicks.Equals(ticks))
                    .FailWith(", but found {0}.", Subject.Value.BclCompatibleTicks);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Duration" /> does not have the specified ticks.
        /// </summary>
        /// <param name="ticks">
        ///     The ticks that the current <see cref="Duration" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DurationAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DurationAssertions> NotHaveTicks(long ticks, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Duration} to have {0} ticks{reason}", ticks);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.BclCompatibleTicks.Equals(ticks))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Duration} was <null>.");
            }

            return new AndConstraint<DurationAssertions>(this);
        }
    }
}
