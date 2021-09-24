using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="AnnualDate" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class AnnualDateAssertions : ReferenceTypeAssertions<AnnualDate?, AnnualDateAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="AnnualDateAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="AnnualDate" /> that is being asserted.</param>
        public AnnualDateAssertions(AnnualDate? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier
        {
            get { return "AnnualDate"; }
        }

        /// <summary>
        ///     Asserts that this <see cref="AnnualDate" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="AnnualDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;AnnualDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<AnnualDateAssertions> Be(AnnualDate? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition((Subject.HasValue && Subject.Equals(other)) || (!Subject.HasValue && !other.HasValue))
                .FailWith("Expected {context:AnnualDate} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<AnnualDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="AnnualDate" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="AnnualDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;AnnualDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<AnnualDateAssertions> NotBe(AnnualDate? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition((Subject.HasValue && !Subject.Equals(other)) || (!Subject.HasValue && other.HasValue))
                .FailWith("Did not expect {context:AnnualDate} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<AnnualDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="AnnualDate" /> is after <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="AnnualDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;AnnualDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<AnnualDateAssertions> BeAfter(AnnualDate other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:AnnualDate} to be after {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<AnnualDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="AnnualDate" /> is on or after <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="AnnualDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;AnnualDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<AnnualDateAssertions> BeOnOrAfter(AnnualDate other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject >= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:AnnualDate} to be on or after {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<AnnualDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="AnnualDate" /> is before <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="AnnualDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;AnnualDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<AnnualDateAssertions> BeBefore(AnnualDate other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:AnnualDate} to be before {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<AnnualDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="AnnualDate" /> is on or before <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="AnnualDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;AnnualDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<AnnualDateAssertions> BeOnOrBefore(AnnualDate other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject <= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:AnnualDate} to be on or before {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<AnnualDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="AnnualDate" /> is a valid day and month for the specified <paramref name="year" />.
        /// </summary>
        /// <param name="year">The year to check.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;AnnualDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<AnnualDateAssertions> BeValidInYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:AnnualDate} to be valid in year {0}{reason}", year);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.IsValidYear(year))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<AnnualDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="AnnualDate" /> is a valid day and month for the specified <paramref name="year" />.
        /// </summary>
        /// <param name="year">The year to check.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;AnnualDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<AnnualDateAssertions> NotBeValidInYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:AnnualDate} to be valid in year {0}{reason}", year);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.IsValidYear(year))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<AnnualDateAssertions>(this);
        }
    }
}
