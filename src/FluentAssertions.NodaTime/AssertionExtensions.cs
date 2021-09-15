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
    }
}
