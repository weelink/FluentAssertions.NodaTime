using FluentAssertions.Formatting;

using NodaTime;

namespace FluentAssertions.NodaTime.Formatters
{
    /// <summary>
    ///     Formats a <see cref="DateInterval" /> into a human-readable string representation.
    /// </summary>
    internal sealed class DateIntervalValueFormatter : IValueFormatter
    {
        /// <inheritdoc />
        public bool CanHandle(object value)
        {
            return value is DateInterval;
        }

        /// <inheritdoc />
        public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext? context, FormatChild? formatChild)
        {
            formattedGraph.AddFragment(value.ToString());
        }
    }
}
