using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="LocalTime" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class LocalTimeAssertions : ReferenceTypeAssertions<LocalTime?, LocalTimeAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="LocalTimeAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="LocalTime" /> that is being asserted.</param>
        public LocalTimeAssertions(LocalTime? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier => "LocalTime";

        /// <summary>
        ///     Asserts that this <see cref="LocalTime" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> Be(LocalTime? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Nullable.Equals(Subject, other))
                .FailWith("Expected {context:LocalTime} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalTime" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotBe(LocalTime? other, string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!Nullable.Equals(Subject, other))
                .FailWith("Did not expect {context:LocalTime} to be equal to {0}{reason}.", other);

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified hour of the half-day.
        /// </summary>
        /// <param name="clockHourOfHalfDay">
        ///     The hour of the half-day that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveClockHourOfHalfDay(int clockHourOfHalfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have clock hour of the half-day of {0}{reason}",
                        clockHourOfHalfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.ClockHourOfHalfDay.Equals(clockHourOfHalfDay))
                    .FailWith(", but found {0}.", Subject.Value.ClockHourOfHalfDay);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified hour of the half-day.
        /// </summary>
        /// <param name="clockHourOfHalfDay">
        ///     The hour of the half-day that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveClockHourOfHalfDay(int clockHourOfHalfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have clock hour of the half-day of {0}{reason}",
                        clockHourOfHalfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.ClockHourOfHalfDay.Equals(clockHourOfHalfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified hour of the day.
        /// </summary>
        /// <param name="hourOfDay">
        ///     The hour of the day that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveHour(int hourOfDay, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have hour of day {0}{reason}", hourOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Hour.Equals(hourOfDay))
                    .FailWith(", but found {0}.", Subject.Value.Hour);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified hour of the day.
        /// </summary>
        /// <param name="hourOfDay">
        ///     The hour of the day that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveHour(int hourOfDay, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have hour of day {0}{reason}", hourOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Hour.Equals(hourOfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified second.
        /// </summary>
        /// <param name="second">
        ///     The second that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveSecond(int second, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have second {0}{reason}", second);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Second.Equals(second))
                    .FailWith(", but found {0}.", Subject.Value.Second);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified second.
        /// </summary>
        /// <param name="second">
        ///     The second that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveSecond(int second, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have second {0}{reason}", second);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Second.Equals(second))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified minute.
        /// </summary>
        /// <param name="minute">
        ///     The minute that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveMinute(int minute, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have minute {0}{reason}", minute);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Minute.Equals(minute))
                    .FailWith(", but found {0}.", Subject.Value.Minute);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified minute.
        /// </summary>
        /// <param name="minute">
        ///     The minute that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveMinute(int minute, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have minute {0}{reason}", minute);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Minute.Equals(minute))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified millisecond.
        /// </summary>
        /// <param name="millisecond">
        ///     The millisecond that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveMillisecond(int millisecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have millisecond {0}{reason}", millisecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Millisecond.Equals(millisecond))
                    .FailWith(", but found {0}.", Subject.Value.Millisecond);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified millisecond.
        /// </summary>
        /// <param name="millisecond">
        ///     The millisecond that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveMillisecond(int millisecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have millisecond {0}{reason}", millisecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Millisecond.Equals(millisecond))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified nanoseconds within the day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanoseconds within the day that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveNanosecondsWithinDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have {0} nanoseconds within the day{reason}", nanosecondOfDay);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified nanoseconds within the day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanoseconds within the day that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveNanosecondsWithinDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have {0} nanoseconds within the day{reason}",
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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified nanoseconds within the second.
        /// </summary>
        /// <param name="nanosecondOfSecond">
        ///     The nanoseconds within the second that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveNanosecondsWithinSecond(int nanosecondOfSecond, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have {0} nanoseconds within the second{reason}", nanosecondOfSecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.NanosecondOfSecond.Equals(nanosecondOfSecond))
                    .FailWith(", but found {0}.", Subject.Value.NanosecondOfSecond);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified nanoseconds within the second.
        /// </summary>
        /// <param name="nanosecondOfSecond">
        ///     The nanoseconds within the second that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveNanosecondsWithinSecond(int nanosecondOfSecond, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have {0} nanoseconds within the second{reason}", nanosecondOfSecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.NanosecondOfSecond.Equals(nanosecondOfSecond))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified tick of second.
        /// </summary>
        /// <param name="tickOfSecond">
        ///     The tick of second that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveTicksWithinSecond(int tickOfSecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have {0} ticks within the second{reason}", tickOfSecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TickOfSecond.Equals(tickOfSecond))
                    .FailWith(", but found {0}.", Subject.Value.TickOfSecond);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified tick of second.
        /// </summary>
        /// <param name="tickOfSecond">
        ///     The tick of second that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveTicksWithinSecond(int tickOfSecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have {0} ticks within the second{reason}", tickOfSecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TickOfSecond.Equals(tickOfSecond))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> has the specified tick of day.
        /// </summary>
        /// <param name="tickOfDay">
        ///     The tick of day that the current <see cref="LocalTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> HaveTicksWithinDay(long tickOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalTime} to have {0} ticks within the day{reason}", tickOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TickOfDay.Equals(tickOfDay))
                    .FailWith(", but found {0}.", Subject.Value.TickOfDay);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalTime" /> does not have the specified tick of day.
        /// </summary>
        /// <param name="tickOfDay">
        ///     The tick of day that the current <see cref="LocalTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> NotHaveTicksWithinDay(long tickOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalTime} to have {0} ticks within the day{reason}", tickOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TickOfDay.Equals(tickOfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalTime" /> is greater than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> BeGreaterThan(LocalTime other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalTime} to be greater than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalTime" /> is on or after <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> BeGreaterThanOrEqualTo(LocalTime other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject >= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalTime} to be greater than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalTime" /> is less than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> BeLessThan(LocalTime other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalTime} to be less than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalTime" /> is less than or equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalTimeAssertions> BeLessThanOrEqualTo(LocalTime other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject <= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalTime} to be less than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalTimeAssertions>(this);
        }
    }
}
