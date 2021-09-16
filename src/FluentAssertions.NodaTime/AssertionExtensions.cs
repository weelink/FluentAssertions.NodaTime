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
        ///     Returns an <see cref="InstantAssertions"/> object that can be used to assert an <see cref="Instant" />.
        /// </summary>
        /// <param name="instant">The <see cref="Instant" /> to assert.</param>
        /// <returns>The <see cref="InstantAssertions" /> to use for asserting an <see cref="Instant" />.</returns>
        public static InstantAssertions Should(this Instant instant)
        {
            return new InstantAssertions(instant);
        }

        /// <summary>
        ///     Returns an <see cref="InstantAssertions"/> object that can be used to assert an <see cref="Instant" />.
        /// </summary>
        /// <param name="instant">The <see cref="Instant" /> to assert.</param>
        /// <returns>The <see cref="InstantAssertions" /> to use for asserting an <see cref="Instant" />.</returns>
        public static InstantAssertions Should(this Instant? instant)
        {
            return new InstantAssertions(instant);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetAssertions"/> object that can be used to assert an <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">The <see cref="Offset" /> to assert.</param>
        /// <returns>The <see cref="OffsetAssertions" /> to use for asserting an <see cref="Offset" />.</returns>
        public static OffsetAssertions Should(this Offset offset)
        {
            return new OffsetAssertions(offset);
        }

        /// <summary>
        ///     Returns an <see cref="OffsetAssertions"/> object that can be used to assert an <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">The <see cref="Offset" /> to assert.</param>
        /// <returns>The <see cref="OffsetAssertions" /> to use for asserting an <see cref="Offset" />.</returns>
        public static OffsetAssertions Should(this Offset? offset)
        {
            return new OffsetAssertions(offset);
        }

        /// <summary>
        ///     Returns an <see cref="LocalDateTimeAssertions"/> object that can be used to assert an <see cref="LocalDateTime" />.
        /// </summary>
        /// <param name="localDateTime">The <see cref="LocalDateTime" /> to assert.</param>
        /// <returns>The <see cref="LocalDateTimeAssertions" /> to use for asserting an <see cref="LocalDateTime" />.</returns>
        public static LocalDateTimeAssertions Should(this LocalDateTime? localDateTime)
        {
            return new LocalDateTimeAssertions(localDateTime);
        }

        /// <summary>
        ///     Returns an <see cref="LocalDateTimeAssertions"/> object that can be used to assert an <see cref="LocalDateTime" />.
        /// </summary>
        /// <param name="localDateTime">The <see cref="LocalDateTime" /> to assert.</param>
        /// <returns>The <see cref="LocalDateTimeAssertions" /> to use for asserting an <see cref="LocalDateTime" />.</returns>
        public static LocalDateTimeAssertions Should(this LocalDateTime localDateTime)
        {
            return new LocalDateTimeAssertions(localDateTime);
        }

        /// <summary>
        ///     Returns an <see cref="DurationAssertions"/> object that can be used to assert an <see cref="Duration" />.
        /// </summary>
        /// <param name="duration">The <see cref="Duration" /> to assert.</param>
        /// <returns>The <see cref="DurationAssertions" /> to use for asserting an <see cref="Duration" />.</returns>
        public static DurationAssertions Should(this Duration? duration)
        {
            return new DurationAssertions(duration);
        }

        /// <summary>
        ///     Returns an <see cref="DurationAssertions"/> object that can be used to assert an <see cref="Duration" />.
        /// </summary>
        /// <param name="duration">The <see cref="Duration" /> to assert.</param>
        /// <returns>The <see cref="DurationAssertions" /> to use for asserting an <see cref="Duration" />.</returns>
        public static DurationAssertions Should(this Duration duration)
        {
            return new DurationAssertions(duration);
        }
    }
}
