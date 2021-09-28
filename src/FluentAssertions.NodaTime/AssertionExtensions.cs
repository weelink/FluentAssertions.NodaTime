using System.Diagnostics;

using NodaTime;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Constains extension methods for NodaTime.
    /// </summary>
    [DebuggerNonUserCode]
    public static class AssertionExtensions
    {
        /// <summary>
        ///     Returns an <see cref="InstantAssertions"/> object that can be used to assert a <see cref="Instant" />.
        /// </summary>
        /// <param name="instant">The <see cref="Instant" /> to assert.</param>
        /// <returns>The <see cref="InstantAssertions" /> to use for asserting a <see cref="Instant" />.</returns>
        public static InstantAssertions Should(this Instant instant)
        {
            return new InstantAssertions(instant);
        }

        /// <summary>
        ///     Returns an <see cref="InstantAssertions"/> object that can be used to assert a <see cref="Instant" />.
        /// </summary>
        /// <param name="instant">The <see cref="Instant" /> to assert.</param>
        /// <returns>The <see cref="InstantAssertions" /> to use for asserting a <see cref="Instant" />.</returns>
        public static InstantAssertions Should(this Instant? instant)
        {
            return new InstantAssertions(instant);
        }

        /// <summary>
        ///     Returns an <see cref="AnnualDateAssertions"/> object that can be used to assert a <see cref="AnnualDate" />.
        /// </summary>
        /// <param name="annualDate">The <see cref="AnnualDate" /> to assert.</param>
        /// <returns>The <see cref="AnnualDateAssertions" /> to use for asserting a <see cref="AnnualDate" />.</returns>
        public static AnnualDateAssertions Should(this AnnualDate annualDate)
        {
            return new AnnualDateAssertions(annualDate);
        }

        /// <summary>
        ///     Returns an <see cref="AnnualDateAssertions"/> object that can be used to assert a <see cref="AnnualDate" />.
        /// </summary>
        /// <param name="annualDate">The <see cref="AnnualDate" /> to assert.</param>
        /// <returns>The <see cref="AnnualDateAssertions" /> to use for asserting a <see cref="AnnualDate" />.</returns>
        public static AnnualDateAssertions Should(this AnnualDate? annualDate)
        {
            return new AnnualDateAssertions(annualDate);
        }

        /// <summary>
        ///     Returns an <see cref="IntervalAssertions"/> object that can be used to assert a <see cref="Interval" />.
        /// </summary>
        /// <param name="interval">The <see cref="Interval" /> to assert.</param>
        /// <returns>The <see cref="IntervalAssertions" /> to use for asserting a <see cref="Interval" />.</returns>
        public static IntervalAssertions Should(this Interval interval)
        {
            return new IntervalAssertions(interval);
        }

        /// <summary>
        ///     Returns an <see cref="IntervalAssertions"/> object that can be used to assert a <see cref="Interval" />.
        /// </summary>
        /// <param name="interval">The <see cref="Interval" /> to assert.</param>
        /// <returns>The <see cref="IntervalAssertions" /> to use for asserting a <see cref="Interval" />.</returns>
        public static IntervalAssertions Should(this Interval? interval)
        {
            return new IntervalAssertions(interval);
        }

        /// <summary>
        ///     Returns a <see cref="DateIntervalAssertions"/> object that can be used to assert a <see cref="DateInterval" />.
        /// </summary>
        /// <param name="interval">The <see cref="DateInterval" /> to assert.</param>
        /// <returns>The <see cref="DateIntervalAssertions" /> to use for asserting a <see cref="DateInterval" />.</returns>
        public static DateIntervalAssertions Should(this DateInterval? interval)
        {
            return new DateIntervalAssertions(interval);
        }

        /// <summary>
        ///     Returns a <see cref="OffsetAssertions"/> object that can be used to assert a <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">The <see cref="Offset" /> to assert.</param>
        /// <returns>The <see cref="OffsetAssertions" /> to use for asserting a <see cref="Offset" />.</returns>
        public static OffsetAssertions Should(this Offset offset)
        {
            return new OffsetAssertions(offset);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetAssertions"/> object that can be used to assert a <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">The <see cref="Offset" /> to assert.</param>
        /// <returns>The <see cref="OffsetAssertions" /> to use for asserting a <see cref="Offset" />.</returns>
        public static OffsetAssertions Should(this Offset? offset)
        {
            return new OffsetAssertions(offset);
        }

        /// <summary>
        ///     Returns an <see cref="LocalDateTimeAssertions"/> object that can be used to assert a <see cref="LocalDateTime" />.
        /// </summary>
        /// <param name="localDateTime">The <see cref="LocalDateTime" /> to assert.</param>
        /// <returns>The <see cref="LocalDateTimeAssertions" /> to use for asserting a <see cref="LocalDateTime" />.</returns>
        public static LocalDateTimeAssertions Should(this LocalDateTime? localDateTime)
        {
            return new LocalDateTimeAssertions(localDateTime);
        }

        /// <summary>
        ///     Returns a <see cref="LocalDateTimeAssertions"/> object that can be used to assert a <see cref="LocalDateTime" />.
        /// </summary>
        /// <param name="localDateTime">The <see cref="LocalDateTime" /> to assert.</param>
        /// <returns>The <see cref="LocalDateTimeAssertions" /> to use for asserting a <see cref="LocalDateTime" />.</returns>
        public static LocalDateTimeAssertions Should(this LocalDateTime localDateTime)
        {
            return new LocalDateTimeAssertions(localDateTime);
        }

        /// <summary>
        ///     Returns a <see cref="LocalDateAssertions"/> object that can be used to assert a <see cref="LocalDate" />.
        /// </summary>
        /// <param name="localDate">The <see cref="LocalDate" /> to assert.</param>
        /// <returns>The <see cref="LocalDateAssertions" /> to use for asserting a <see cref="LocalDate" />.</returns>
        public static LocalDateAssertions Should(this LocalDate? localDate)
        {
            return new LocalDateAssertions(localDate);
        }

        /// <summary>
        ///     Returns a <see cref="LocalDateAssertions"/> object that can be used to assert a <see cref="LocalDate" />.
        /// </summary>
        /// <param name="localDate">The <see cref="LocalDate" /> to assert.</param>
        /// <returns>The <see cref="LocalDateAssertions" /> to use for asserting a <see cref="LocalDate" />.</returns>
        public static LocalDateAssertions Should(this LocalDate localDate)
        {
            return new LocalDateAssertions(localDate);
        }

        /// <summary>
        ///     Returns a <see cref="LocalTimeAssertions"/> object that can be used to assert a <see cref="LocalTime" />.
        /// </summary>
        /// <param name="localTime">The <see cref="LocalTime" /> to assert.</param>
        /// <returns>The <see cref="LocalTimeAssertions" /> to use for asserting a <see cref="LocalTime" />.</returns>
        public static LocalTimeAssertions Should(this LocalTime? localTime)
        {
            return new LocalTimeAssertions(localTime);
        }

        /// <summary>
        ///     Returns a <see cref="LocalTimeAssertions"/> object that can be used to assert a <see cref="LocalTime" />.
        /// </summary>
        /// <param name="localTime">The <see cref="LocalTime" /> to assert.</param>
        /// <returns>The <see cref="LocalTimeAssertions" /> to use for asserting a <see cref="LocalTime" />.</returns>
        public static LocalTimeAssertions Should(this LocalTime localTime)
        {
            return new LocalTimeAssertions(localTime);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetDateTimeAssertions"/> object that can be used to assert a <see cref="OffsetDateTime" />.
        /// </summary>
        /// <param name="offsetDateTime">The <see cref="OffsetDateTime" /> to assert.</param>
        /// <returns>The <see cref="OffsetDateTimeAssertions" /> to use for asserting a <see cref="OffsetDateTime" />.</returns>
        public static OffsetDateTimeAssertions Should(this OffsetDateTime? offsetDateTime)
        {
            return new OffsetDateTimeAssertions(offsetDateTime);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetDateTimeAssertions"/> object that can be used to assert a <see cref="OffsetDateTime" />.
        /// </summary>
        /// <param name="offsetDateTime">The <see cref="OffsetDateTime" /> to assert.</param>
        /// <returns>The <see cref="OffsetDateTimeAssertions" /> to use for asserting a <see cref="OffsetDateTime" />.</returns>
        public static OffsetDateTimeAssertions Should(this OffsetDateTime offsetDateTime)
        {
            return new OffsetDateTimeAssertions(offsetDateTime);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetDateAssertions"/> object that can be used to assert a <see cref="OffsetDate" />.
        /// </summary>
        /// <param name="offsetDate">The <see cref="OffsetDate" /> to assert.</param>
        /// <returns>The <see cref="OffsetDateAssertions" /> to use for asserting a <see cref="OffsetDate" />.</returns>
        public static OffsetDateAssertions Should(this OffsetDate? offsetDate)
        {
            return new OffsetDateAssertions(offsetDate);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetDateAssertions"/> object that can be used to assert a <see cref="OffsetDate" />.
        /// </summary>
        /// <param name="offsetDate">The <see cref="OffsetDate" /> to assert.</param>
        /// <returns>The <see cref="OffsetDateAssertions" /> to use for asserting a <see cref="OffsetDate" />.</returns>
        public static OffsetDateAssertions Should(this OffsetDate offsetDate)
        {
            return new OffsetDateAssertions(offsetDate);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetTimeAssertions"/> object that can be used to assert a <see cref="OffsetTime" />.
        /// </summary>
        /// <param name="offsetTime">The <see cref="OffsetTime" /> to assert.</param>
        /// <returns>The <see cref="OffsetTimeAssertions" /> to use for asserting a <see cref="OffsetTime" />.</returns>
        public static OffsetTimeAssertions Should(this OffsetTime? offsetTime)
        {
            return new OffsetTimeAssertions(offsetTime);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetTimeAssertions"/> object that can be used to assert a <see cref="OffsetTime" />.
        /// </summary>
        /// <param name="offsetTime">The <see cref="OffsetTime" /> to assert.</param>
        /// <returns>The <see cref="OffsetTimeAssertions" /> to use for asserting a <see cref="OffsetTime" />.</returns>
        public static OffsetTimeAssertions Should(this OffsetTime offsetTime)
        {
            return new OffsetTimeAssertions(offsetTime);
        }

        /// <summary>
        ///     Returns a <see cref="ZonedDateTimeAssertions"/> object that can be used to assert a <see cref="ZonedDateTime" />.
        /// </summary>
        /// <param name="zonedDateTime">The <see cref="ZonedDateTime" /> to assert.</param>
        /// <returns>The <see cref="ZonedDateTimeAssertions" /> to use for asserting a <see cref="ZonedDateTime" />.</returns>
        public static ZonedDateTimeAssertions Should(this ZonedDateTime? zonedDateTime)
        {
            return new ZonedDateTimeAssertions(zonedDateTime);
        }

        /// <summary>
        ///     Returns a <see cref="ZonedDateTimeAssertions"/> object that can be used to assert a <see cref="ZonedDateTime" />.
        /// </summary>
        /// <param name="zonedDateTime">The <see cref="ZonedDateTime" /> to assert.</param>
        /// <returns>The <see cref="ZonedDateTimeAssertions" /> to use for asserting a <see cref="ZonedDateTime" />.</returns>
        public static ZonedDateTimeAssertions Should(this ZonedDateTime zonedDateTime)
        {
            return new ZonedDateTimeAssertions(zonedDateTime);
        }

        /// <summary>
        ///     Returns a <see cref="DurationAssertions"/> object that can be used to assert a <see cref="Duration" />.
        /// </summary>
        /// <param name="duration">The <see cref="Duration" /> to assert.</param>
        /// <returns>The <see cref="DurationAssertions" /> to use for asserting a <see cref="Duration" />.</returns>
        public static DurationAssertions Should(this Duration? duration)
        {
            return new DurationAssertions(duration);
        }

        /// <summary>
        ///     Returns a <see cref="DurationAssertions"/> object that can be used to assert a <see cref="Duration" />.
        /// </summary>
        /// <param name="duration">The <see cref="Duration" /> to assert.</param>
        /// <returns>The <see cref="DurationAssertions" /> to use for asserting a <see cref="Duration" />.</returns>
        public static DurationAssertions Should(this Duration duration)
        {
            return new DurationAssertions(duration);
        }

        /// <summary>
        ///     Returns a <see cref="PeriodAssertions"/> object that can be used to assert a <see cref="Period" />.
        /// </summary>
        /// <param name="period">The <see cref="Period" /> to assert.</param>
        /// <returns>The <see cref="PeriodAssertions" /> to use for asserting a <see cref="Period" />.</returns>
        public static PeriodAssertions Should(this Period? period)
        {
            return new PeriodAssertions(period);
        }
    }
}
