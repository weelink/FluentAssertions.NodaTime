using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="Offset" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class OffsetAssertions : ReferenceTypeAssertions<Offset?, OffsetAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="OffsetAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="Offset" /> that is being asserted.</param>
        public OffsetAssertions(Offset? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier
        {
            get { return "Offset"; }
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> Be(Offset? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition((Subject.HasValue && Subject.Equals(other)) || (!Subject.HasValue && !other.HasValue))
                .FailWith("Expected {context:Offset} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> Be(TimeSpan? other, string because = "", params object[] becauseArgs)
        {
            return Be(other.HasValue ? Offset.FromTimeSpan(other.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotBe(Offset? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition((Subject.HasValue && !Subject.Equals(other)) || (!Subject.HasValue && other.HasValue))
                .FailWith("Did not expect {context:Offset} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotBe(TimeSpan? other, string because = "", params object[] becauseArgs)
        {
            return NotBe(other.HasValue ? Offset.FromTimeSpan(other.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is positive.
        /// </summary>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BePositive(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > Offset.Zero)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Offset} to be positive, but found {0}.", Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is negative.
        /// </summary>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BeNegative(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < Offset.Zero)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Offset} to be negative, but found {0}.", Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is zero.
        /// </summary>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BeZero(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject == Offset.Zero)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Offset} to be zero, but found {0}.", Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is not zero.
        /// </summary>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotBeZero(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject != Offset.Zero)
                .BecauseOf(because, becauseArgs)
                .FailWith("Did not expect {context:Offset} to be zero, but found {0}.", Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BeCloseTo(Offset other, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return BeCloseTo(other, Offset.FromTimeSpan(precision), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BeCloseTo(Offset other, Offset precision, string because = "", params object[] becauseArgs)
        {
            if (precision < Offset.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), $"The value of {nameof(precision)} must be non-negative.");
            }

            Offset? distance = other > Subject ? other - Subject : Subject - other;
            Execute.Assertion
                .ForCondition(distance <= precision)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Offset} to be within {0} from {1}{reason}, but it was {2}.", precision, other, distance);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is not within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotBeCloseTo(Offset other, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return NotBeCloseTo(other, Offset.FromTimeSpan(precision), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is not within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotBeCloseTo(Offset other, Offset precision, string because = "", params object[] becauseArgs)
        {
            if (precision < Offset.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), $"The value of {nameof(precision)} must be non-negative.");
            }

            Offset? distance = other > Subject ? other - Subject : Subject - other;
            Execute.Assertion
                .ForCondition(distance > precision)
                .BecauseOf(because, becauseArgs)
                .FailWith("Did not expect {context:Offset} to be within {0} from {1}{reason}, but it was {2}.", precision, other, distance);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is greater than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BeGreaterThan(Offset other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Offset} to be greater than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is on or after <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BeGreaterThanOrEqualTo(Offset other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject >= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Offset} to be greater than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is less than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BeLessThan(Offset other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Offset} to be less than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Offset" /> is less than or equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Offset" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> BeLessThanOrEqualTo(Offset other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject <= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Offset} to be less than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Offset" /> has the specified seconds.
        /// </summary>
        /// <param name="seconds">
        ///     The seconds that the current <see cref="Offset" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> HaveSeconds(int seconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Offset} to have {0} seconds{reason}", seconds);

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
                    .FailWith(", but {context:Offset} was <null>.");
            }

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Offset" /> does not have the specified seconds.
        /// </summary>
        /// <param name="seconds">
        ///     The seconds that the current <see cref="Offset" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotHaveSeconds(int seconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Offset} to have {0} seconds{reason}", seconds);

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
                    .FailWith(", but {context:Offset} was <null>.");
            }

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Offset" /> has the specified milliseconds.
        /// </summary>
        /// <param name="milliseconds">
        ///     The milliseconds that the current <see cref="Offset" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> HaveMilliseconds(int milliseconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Offset} to have {0} milliseconds{reason}", milliseconds);

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
                    .FailWith(", but {context:Offset} was <null>.");
            }

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Offset" /> does not have the specified milliseconds.
        /// </summary>
        /// <param name="milliseconds">
        ///     The milliseconds that the current <see cref="Offset" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotHaveMilliseconds(int milliseconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Offset} to have {0} milliseconds{reason}", milliseconds);

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
                    .FailWith(", but {context:Offset} was <null>.");
            }

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Offset" /> has the specified nanoseconds.
        /// </summary>
        /// <param name="nanoseconds">
        ///     The nanoseconds that the current <see cref="Offset" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> HaveNanoseconds(long nanoseconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Offset} to have {0} nanoseconds{reason}", nanoseconds);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Nanoseconds.Equals(nanoseconds))
                    .FailWith(", but found {0}.", Subject.Value.Nanoseconds);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Offset} was <null>.");
            }

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Offset" /> does not have the specified nanoseconds.
        /// </summary>
        /// <param name="nanoseconds">
        ///     The nanoseconds that the current <see cref="Offset" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotHaveNanoseconds(long nanoseconds, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Offset} to have {0} nanoseconds{reason}", nanoseconds);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Nanoseconds.Equals(nanoseconds))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Offset} was <null>.");
            }

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Offset" /> has the specified ticks.
        /// </summary>
        /// <param name="ticks">
        ///     The ticks that the current <see cref="Offset" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> HaveTicks(long ticks, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:Offset} to have {0} ticks{reason}", ticks);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Ticks.Equals(ticks))
                    .FailWith(", but found {0}.", Subject.Value.Ticks);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Offset} was <null>.");
            }

            return new AndConstraint<OffsetAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="Offset" /> does not have the specified ticks.
        /// </summary>
        /// <param name="ticks">
        ///     The ticks that the current <see cref="Offset" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetAssertions> NotHaveTicks(long ticks, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:Offset} to have {0} ticks{reason}", ticks);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Ticks.Equals(ticks))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:Offset} was <null>.");
            }

            return new AndConstraint<OffsetAssertions>(this);
        }
    }
}
