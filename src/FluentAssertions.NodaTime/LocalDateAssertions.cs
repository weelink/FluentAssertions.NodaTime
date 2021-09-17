using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;
using NodaTime.Calendars;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="LocalDate" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class LocalDateAssertions : ReferenceTypeAssertions<LocalDate?, LocalDateAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="LocalDateAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="LocalDate" /> that is being asserted.</param>
        public LocalDateAssertions(LocalDate? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier => "LocalDate";

        /// <summary>
        ///     Asserts that this <see cref="LocalDate" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> Be(LocalDate? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.HasValue && Subject.Equals(other) || !Subject.HasValue && !other.HasValue)
                .FailWith("Expected {context:LocalDate} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDate" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotBe(LocalDate? other, string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.HasValue && !Subject.Equals(other) || !Subject.HasValue && other.HasValue)
                .FailWith("Did not expect {context:LocalDate} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> has the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="LocalDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;LocalDateAssertions, CalendarSystem&gt;</see>
        ///     which can be used to assert the <see cref="CalendarSystem" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<LocalDateAssertions, CalendarSystem> BeInCalendar(CalendarSystem calendar,
            string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDate} to be in calendar {0}{reason}", calendar);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Calendar.Equals(calendar))
                    .FailWith(", but found {0}.", Subject.Value.Calendar);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndWhichConstraint<LocalDateAssertions, CalendarSystem>(this, calendar);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> does not have the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="LocalDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotBeInCalendar(CalendarSystem calendar, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDate} to be in calendar {0}{reason}", calendar);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Calendar.Equals(calendar))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> has the specified day of the month.
        /// </summary>
        /// <param name="day">
        ///     The day of the month that the current <see cref="LocalDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> HaveDay(int day, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDate} to have day {0}{reason}", day);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Day.Equals(day))
                    .FailWith(", but found {0}.", Subject.Value.Day);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> does not have the specified day of the month.
        /// </summary>
        /// <param name="day">
        ///     The day of the month that the current <see cref="LocalDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotHaveDay(int day, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDate} to have day {0}{reason}", day);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Day.Equals(day))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> has the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">
        ///     The day of the week that the current <see cref="LocalDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> HaveDayOfWeek(IsoDayOfWeek dayOfWeek, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDate} to have day of week {0}{reason}", dayOfWeek);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.DayOfWeek.Equals(dayOfWeek))
                    .FailWith(", but found {0}.", Subject.Value.DayOfWeek);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> does not have the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">
        ///     The day of the week that the current <see cref="LocalDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotHaveDayOfWeek(IsoDayOfWeek dayOfWeek, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDate} to have day of week {0}{reason}", dayOfWeek);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.DayOfWeek.Equals(dayOfWeek))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> has the specified day of the year.
        /// </summary>
        /// <param name="dayOfYear">
        ///     The day of the year that the current <see cref="LocalDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> HaveDayOfYear(int dayOfYear, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDate} to have day of year {0}{reason}", dayOfYear);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.DayOfYear.Equals(dayOfYear))
                    .FailWith(", but found {0}.", Subject.Value.DayOfYear);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> does not have the specified day of the year.
        /// </summary>
        /// <param name="dayOfYear">
        ///     The day of the year that the current <see cref="LocalDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotHaveDayOfYear(int dayOfYear, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDate} to have day of year {0}{reason}", dayOfYear);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.DayOfYear.Equals(dayOfYear))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> has the specified year.
        /// </summary>
        /// <param name="year">
        ///     The year that the current <see cref="LocalDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> HaveYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDate} to have year {0}{reason}", year);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Year.Equals(year))
                    .FailWith(", but found {0}.", Subject.Value.Year);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> does not have the specified year.
        /// </summary>
        /// <param name="year">
        ///     The year that the current <see cref="LocalDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotHaveYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDate} to have year {0}{reason}", year);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Year.Equals(year))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> has the specified month.
        /// </summary>
        /// <param name="month">
        ///     The month that the current <see cref="LocalDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> HaveMonth(int month, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDate} to have month {0}{reason}", month);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Month.Equals(month))
                    .FailWith(", but found {0}.", Subject.Value.Month);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> does not have the specified month.
        /// </summary>
        /// <param name="month">
        ///     The month that the current <see cref="LocalDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotHaveMonth(int month, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDate} to have month {0}{reason}", month);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Month.Equals(month))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> has the specified year of era.
        /// </summary>
        /// <param name="yearOfEra">
        ///     The year of era that the current <see cref="LocalDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> HaveYearOfEra(int yearOfEra, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDate} to have year of era {0}{reason}", yearOfEra);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.YearOfEra.Equals(yearOfEra))
                    .FailWith(", but found {0}.", Subject.Value.YearOfEra);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> does not have the specified year of era.
        /// </summary>
        /// <param name="yearOfEra">
        ///     The year of era that the current <see cref="LocalDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotHaveYearOfEra(int yearOfEra, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDate} to have year of era {0}{reason}", yearOfEra);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.YearOfEra.Equals(yearOfEra))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> has the specified era.
        /// </summary>
        /// <param name="era">
        ///     The era that the current <see cref="LocalDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> HaveEra(Era era, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDate} to have era {0}{reason}", era);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Era.Equals(era))
                    .FailWith(", but found {0}.", Subject.Value.Era);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDate" /> does not have the specified era.
        /// </summary>
        /// <param name="era">
        ///     The era that the current <see cref="LocalDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> NotHaveEra(Era era, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDate} to have era {0}{reason}", era);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Era.Equals(era))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDate} was <null>.");
            }

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDate" /> is greater than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> BeGreaterThan(LocalDate other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalDate} to be greater than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDate" /> is on or after <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> BeGreaterThanOrEqualTo(LocalDate other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject >= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalDate} to be greater than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDate" /> is less than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> BeLessThan(LocalDate other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalDate} to be less than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDate" /> is less than or equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateAssertions> BeLessThanOrEqualTo(LocalDate other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject <= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalDate} to be less than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateAssertions>(this);
        }
    }
}
