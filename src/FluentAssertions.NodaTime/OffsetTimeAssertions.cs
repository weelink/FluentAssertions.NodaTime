using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="OffsetTime" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class OffsetTimeAssertions : ReferenceTypeAssertions<OffsetTime?, OffsetTimeAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="OffsetTimeAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="OffsetTime" /> that is being asserted.</param>
        public OffsetTimeAssertions(OffsetTime? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier => "OffsetTime";

        /// <summary>
        ///     Asserts that this <see cref="OffsetTime" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="OffsetTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> Be(OffsetTime? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Nullable.Equals(Subject, other))
                .FailWith("Expected {context:OffsetTime} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="OffsetTime" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="OffsetTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotBe(OffsetTime? other, string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!Nullable.Equals(Subject, other))
                .FailWith("Did not expect {context:OffsetTime} to be equal to {0}{reason}.", other);

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">
        ///     The <see cref="OffsetTime" /> that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;OffsetTimeAssertions, OffsetTime&gt;</see>
        ///     which can be used to assert the <see cref="OffsetTime" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<OffsetTimeAssertions, Offset> HaveOffset(Offset offset, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have offset {0}{reason}", offset);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Offset.Equals(offset))
                    .FailWith(", but found {0}.", Subject.Value.Offset);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndWhichConstraint<OffsetTimeAssertions, Offset>(this, offset);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="timeSpan">
        ///     The <see cref="OffsetTime" /> that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;OffsetTimeAssertions, OffsetTime&gt;</see>
        ///     which can be used to assert the <see cref="OffsetTime" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<OffsetTimeAssertions, Offset> HaveOffset(TimeSpan timeSpan, string because = "",
            params object[] becauseArgs)
        {
            return HaveOffset(Offset.FromTimeSpan(timeSpan), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">
        ///     The <see cref="OffsetTime" /> that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveOffset(Offset offset, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have offset {0}{reason}", offset);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Offset.Equals(offset))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="timeSpan">
        ///     The <see cref="OffsetTime" /> that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveOffset(TimeSpan timeSpan, string because = "",
            params object[] becauseArgs)
        {
            return NotHaveOffset(Offset.FromTimeSpan(timeSpan), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified <see cref="LocalTime" />.
        /// </summary>
        /// <param name="timeOfDay">
        ///     The <see cref="LocalTime" /> that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;OffsetTimeAssertions, LocalTime&gt;</see>
        ///     which can be used to assert the <see cref="OffsetTime" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<OffsetTimeAssertions, LocalTime> HaveTimeOfDay(LocalTime timeOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have time of day {0}{reason}", timeOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TimeOfDay.Equals(timeOfDay))
                    .FailWith(", but found {0}.", Subject.Value.TimeOfDay);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndWhichConstraint<OffsetTimeAssertions, LocalTime>(this, timeOfDay);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified <see cref="LocalTime" />.
        /// </summary>
        /// <param name="timeOfDay">
        ///     The <see cref="LocalTime" /> that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveTimeOfDay(LocalTime timeOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have time of day {0}{reason}", timeOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TimeOfDay.Equals(timeOfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified hour of the half-day.
        /// </summary>
        /// <param name="clockHourOfHalfDay">
        ///     The hour of the half-day that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveClockHourOfHalfDay(int clockHourOfHalfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have clock hour of the half-day of {0}{reason}",
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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified hour of the half-day.
        /// </summary>
        /// <param name="clockHourOfHalfDay">
        ///     The hour of the half-day that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveClockHourOfHalfDay(int clockHourOfHalfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have clock hour of the half-day of {0}{reason}",
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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified hour of the day.
        /// </summary>
        /// <param name="hourOfDay">
        ///     The hour of the day that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveHour(int hourOfDay, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have hour of day {0}{reason}", hourOfDay);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified hour of the day.
        /// </summary>
        /// <param name="hourOfDay">
        ///     The hour of the day that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveHour(int hourOfDay, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have hour of day {0}{reason}", hourOfDay);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified second.
        /// </summary>
        /// <param name="second">
        ///     The second that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveSecond(int second, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have second {0}{reason}", second);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified second.
        /// </summary>
        /// <param name="second">
        ///     The second that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveSecond(int second, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have second {0}{reason}", second);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified minute.
        /// </summary>
        /// <param name="minute">
        ///     The minute that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveMinute(int minute, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have minute {0}{reason}", minute);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified minute.
        /// </summary>
        /// <param name="minute">
        ///     The minute that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveMinute(int minute, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have minute {0}{reason}", minute);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified millisecond.
        /// </summary>
        /// <param name="millisecond">
        ///     The millisecond that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveMillisecond(int millisecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have millisecond {0}{reason}", millisecond);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified millisecond.
        /// </summary>
        /// <param name="millisecond">
        ///     The millisecond that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveMillisecond(int millisecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have millisecond {0}{reason}", millisecond);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified nanoseconds within the day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanoseconds within the day that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveNanosecondsWithinDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have {0} nanoseconds within the day{reason}", nanosecondOfDay);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified nanoseconds within the day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanoseconds within the day that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveNanosecondsWithinDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have {0} nanoseconds within the day{reason}",
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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified nanoseconds within the second.
        /// </summary>
        /// <param name="nanosecondOfSecond">
        ///     The nanoseconds within the second that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveNanosecondsWithinSecond(int nanosecondOfSecond, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have {0} nanoseconds within the second{reason}", nanosecondOfSecond);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified nanoseconds within the second.
        /// </summary>
        /// <param name="nanosecondOfSecond">
        ///     The nanoseconds within the second that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveNanosecondsWithinSecond(int nanosecondOfSecond, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have {0} nanoseconds within the second{reason}", nanosecondOfSecond);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified tick of second.
        /// </summary>
        /// <param name="tickOfSecond">
        ///     The tick of second that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveTicksWithinSecond(int tickOfSecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have {0} ticks within the second{reason}", tickOfSecond);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified tick of second.
        /// </summary>
        /// <param name="tickOfSecond">
        ///     The tick of second that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveTicksWithinSecond(int tickOfSecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have {0} ticks within the second{reason}", tickOfSecond);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> has the specified tick of day.
        /// </summary>
        /// <param name="tickOfDay">
        ///     The tick of day that the current <see cref="OffsetTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> HaveTicksWithinDay(long tickOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetTime} to have {0} ticks within the day{reason}", tickOfDay);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetTime" /> does not have the specified tick of day.
        /// </summary>
        /// <param name="tickOfDay">
        ///     The tick of day that the current <see cref="OffsetTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetTimeAssertions> NotHaveTicksWithinDay(long tickOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetTime} to have {0} ticks within the day{reason}", tickOfDay);

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

            return new AndConstraint<OffsetTimeAssertions>(this);
        }
    }
}
