using System;
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
            Formatter.AddFormatter(new DateIntervalValueFormatter());
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
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Nullable.Equals(Subject, other))
                .FailWith("Expected {context:DateInterval} to be equal to {0}{reason}, but found {1}.", other, Subject);

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
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!Nullable.Equals(Subject, other))
                .FailWith("Did not expect {context:DateInterval} to be equal to {0}{reason}.", other, Subject);

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the length of this <see cref="DateInterval" /> is equal to <paramref name="days" /> days.
        /// </summary>
        /// <param name="days">The length of this date interval in days..</param>
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
        public AndConstraint<DateIntervalAssertions> BeInDays(int days, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:DateInterval} to be {0} days{reason}", days);

            if (Subject != null)
            {
                scope.ForCondition(Subject.Length == days)
                    .FailWith(", but found {0}.", Subject.Length);
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
        ///     Asserts that the length of this <see cref="DateInterval" /> is not equal to <paramref name="days" /> days.
        /// </summary>
        /// <param name="days">The length of this date interval in days..</param>
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
        public AndConstraint<DateIntervalAssertions> NotBeInDays(int days, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:DateInterval} to be {0} days{reason}", days);

            if (Subject != null)
            {
                scope.ForCondition(Subject.Length != days)
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
                    .FailWith(", but found <null>.");
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
                    .FailWith(", but found <null>.");
            }
            else
            {
                scope
                    .ForCondition(!Subject.Contains(localDate))
                    .FailWith(".");
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> contains <paramref name="dateInterval" />.
        /// </summary>
        /// <param name="dateInterval">The inclusive lower bound of the interval.</param>
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
        public AndConstraint<DateIntervalAssertions> Contain(DateInterval dateInterval, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:DateInterval} to contain {0}{reason}", dateInterval);

            if (Subject != null)
            {
                scope
                    .ForCondition(Subject.Contains(dateInterval))
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
        ///     Asserts that the current <see cref="DateInterval" /> does not contain <paramref name="dateInterval" />.
        /// </summary>
        /// <param name="dateInterval">The inclusive lower bound of the interval.</param>
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
        public AndConstraint<DateIntervalAssertions> NotContain(DateInterval dateInterval, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:DateInterval} to contain {0}{reason}", dateInterval);

            if (Subject == null)
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }
            else
            {
                scope
                    .ForCondition(!Subject.Contains(dateInterval))
                    .FailWith(".");
            }

            return new AndConstraint<DateIntervalAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> has the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="DateInterval" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;DateIntervalAssertions, CalendarSystem&gt;</see>
        ///     which can be used to assert the <see cref="CalendarSystem" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<DateIntervalAssertions, CalendarSystem> BeInCalendar(CalendarSystem calendar,
            string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:DateInterval} to be in calendar {0}{reason}", calendar);

            if (Subject != null)
            {
                scope
                    .ForCondition(Subject.Calendar.Equals(calendar))
                    .FailWith(", but found {0}.", Subject.Calendar);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndWhichConstraint<DateIntervalAssertions, CalendarSystem>(this, calendar);
        }

        /// <summary>
        ///     Asserts that the current <see cref="DateInterval" /> does not have the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="DateInterval" /> is not expected to have.
        /// </param>
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
        public AndConstraint<DateIntervalAssertions> NotBeInCalendar(CalendarSystem calendar, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:DateInterval} to be in calendar {0}{reason}", calendar);

            if (Subject != null)
            {
                scope
                    .ForCondition(!Subject.Calendar.Equals(calendar))
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
    }
}
