using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="Instant" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class InstantAssertions : ReferenceTypeAssertions<Instant?, InstantAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="InstantAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="Instant" /> that is being asserted.</param>
        public InstantAssertions(Instant? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier
        {
            get { return "Instant"; }
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> Be(Instant? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition((Subject.HasValue && Subject.Equals(other)) || (!Subject.HasValue && !other.HasValue))
                .FailWith("Expected {context:Instant} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<InstantAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is equal to <paramref name="dateTimeOffset" />.
        /// </summary>
        /// <param name="dateTimeOffset">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> Be(DateTimeOffset? dateTimeOffset, string because = "", params object[] becauseArgs)
        {
            return Be(dateTimeOffset.HasValue ? Instant.FromDateTimeOffset(dateTimeOffset.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is equal to <paramref name="dateTimeUtc" />.
        /// </summary>
        /// <param name="dateTimeUtc">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> Be(DateTime? dateTimeUtc, string because = "", params object[] becauseArgs)
        {
            return Be(dateTimeUtc.HasValue ? Instant.FromDateTimeUtc(dateTimeUtc.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> NotBe(Instant? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition((Subject.HasValue && !Subject.Equals(other)) || (!Subject.HasValue && other.HasValue))
                .FailWith("Did not expect {context:Instant} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<InstantAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is not equal to <paramref name="dateTimeOffset" />.
        /// </summary>
        /// <param name="dateTimeOffset">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> NotBe(DateTimeOffset? dateTimeOffset, string because = "", params object[] becauseArgs)
        {
            return NotBe(dateTimeOffset.HasValue ? Instant.FromDateTimeOffset(dateTimeOffset.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is not equal to <paramref name="dateTimeUtc" />.
        /// </summary>
        /// <param name="dateTimeUtc">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> NotBe(DateTime? dateTimeUtc, string because = "", params object[] becauseArgs)
        {
            return NotBe(dateTimeUtc.HasValue ? Instant.FromDateTimeUtc(dateTimeUtc.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> BeCloseTo(Instant other, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return BeCloseTo(other, Duration.FromTimeSpan(precision), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> BeCloseTo(Instant other, Duration precision, string because = "", params object[] becauseArgs)
        {
            if (precision < Duration.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), $"The value of {nameof(precision)} must be non-negative.");
            }

            Duration? distance = other > Subject ? other - Subject : Subject - other;
            Execute.Assertion
                .ForCondition(distance <= precision)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Instant} to be within {0} from {1}{reason}, but it was {2}.", precision, other, distance);

            return new AndConstraint<InstantAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is not within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> NotBeCloseTo(Instant other, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return NotBeCloseTo(other, Duration.FromTimeSpan(precision), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is not within <paramref name="precision" /> of <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> NotBeCloseTo(Instant other, Duration precision, string because = "", params object[] becauseArgs)
        {
            if (precision < Duration.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), $"The value of {nameof(precision)} must be non-negative.");
            }

            Duration? distance = other > Subject ? other - Subject : Subject - other;
            Execute.Assertion
                .ForCondition(distance > precision)
                .BecauseOf(because, becauseArgs)
                .FailWith("Did not expect {context:Instant} to be within {0} from {1}{reason}, but it was {2}.", precision, other, distance);

            return new AndConstraint<InstantAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is greater than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> GreaterThan(Instant other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Instant} to be greater than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<InstantAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is greater than or equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> GreaterThanOrEqualTo(Instant other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject >= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Instant} to be greater than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<InstantAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is less than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> LessThan(Instant other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Instant} to be less than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<InstantAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="Instant" /> is less than or equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="Instant" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;InstantAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<InstantAssertions> LessThanOrEqualTo(Instant other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject <= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Instant} to be less than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<InstantAssertions>(this);
        }
    }
}
