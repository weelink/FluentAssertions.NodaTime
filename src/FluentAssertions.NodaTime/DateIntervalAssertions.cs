using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Formatting;
using FluentAssertions.NodaTime.Formatters;
using FluentAssertions.Primitives;

using NodaTime;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="DateInterval" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class DateIntervalAssertions : ReferenceTypeAssertions<DateInterval?, DateIntervalAssertions>
    {
        static DateIntervalAssertions()
        {
            Formatter.AddFormatter(new DateIntervalFormatter());
        }

        /// <summary>
        ///     Initializes a new <see cref="DateIntervalAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="DateInterval" /> that is being asserted.</param>
        public DateIntervalAssertions(DateInterval? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier
        {
            get { return "DateInterval"; }
        }

        /// <summary>
        ///     Asserts that this <see cref="DateInterval" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="DateInterval" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DateIntervalAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DateIntervalAssertions> Be(DateInterval? other, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:DateInterval} to be equal to {0}{reason}", other);

            if (Subject != null)
            {
                scope.ForCondition((Subject != null && Subject.Equals(other)) || (Subject == null && other == null))
                    .FailWith(", but found {0}.", Subject);
            }
            else if (other != null)
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="DateInterval" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="DateInterval" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DateIntervalAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DateIntervalAssertions> NotBe(DateInterval? other, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:DateInterval} to be equal to {0}{reason}", other);

            if (Subject != null)
            {
                scope
                    .ForCondition(!Subject.Equals(other))
                    .FailWith(", but found {0}.", Subject);
            }
            else if (other == null)
            {
                scope
                    .ForCondition(false)
                    .FailWith(".");
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> ends at <paramref name="localDate" />.
        /// </summary>
        /// <param name="localDate">The exclusive upper bound of the interval.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DateIntervalAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DateIntervalAssertions> EndAt(LocalDate? localDate, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:DateInterval} to end at {0}{reason}", localDate);

            if (Subject == null)
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }
            else
            {
                scope
                    .ForCondition(Subject.End.Equals(localDate))
                    .FailWith(", but {context:DateInterval} ends at {0}.", Subject.End);
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> does not end at <paramref name="localDate" />.
        /// </summary>
        /// <param name="localDate">The exclusive upper bound of the interval.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DateIntervalAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DateIntervalAssertions> NotEndAt(LocalDate? localDate, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:DateInterval} to end at {0}{reason}", localDate);

            if (Subject != null)
            {
                scope
                    .ForCondition(!Subject.End.Equals(localDate))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> starts at <paramref name="localDate" />.
        /// </summary>
        /// <param name="localDate">The inclusive lower bound of the interval.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepstarted automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DateIntervalAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DateIntervalAssertions> StartAt(LocalDate? localDate, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:DateInterval} to start at {0}{reason}", localDate);

            if (Subject == null)
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }
            else
            {
                scope
                    .ForCondition(Subject.Start.Equals(localDate))
                    .FailWith(", but {context:DateInterval} starts at {0}.", Subject.Start);
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> does not start at <paramref name="localDate" />.
        /// </summary>
        /// <param name="localDate">The inclusive lower bound of the interval.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepstarted automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DateIntervalAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DateIntervalAssertions> NotStartAt(LocalDate? localDate, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:DateInterval} to start at {0}{reason}", localDate);

            if (Subject != null)
            {
                scope
                    .ForCondition(!Subject.Start.Equals(localDate))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> contains <paramref name="localDate" />.
        /// </summary>
        /// <param name="localDate">The inclusive lower bound of the interval.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not contain with the word <i>because</i>, it is prepcontained automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DateIntervalAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DateIntervalAssertions> Contain(LocalDate localDate, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:DateInterval} to contain {0}{reason}", localDate);

            if (Subject != null)
            {
                scope
                    .ForCondition(Subject.Contains(localDate))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:DateInterval} was <null>.");
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> does not contain <paramref name="localDate" />.
        /// </summary>
        /// <param name="localDate">The inclusive lower bound of the interval.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not contain with the word <i>because</i>, it is prepcontained automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;DateIntervalAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<DateIntervalAssertions> NotContain(LocalDate localDate, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:DateInterval} to contain {0}{reason}", localDate);

            if (Subject == null)
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:DateInterval} was <null>.");
            }
            else
            {
                scope
                    .ForCondition(!Subject.Contains(localDate))
                    .FailWith(".");
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }
    }
}
