using FluentAssertions.Formatting;
using FluentAssertions.NodaTime.Formatters;

using NodaTime;

namespace FluentAssertions.NodaTime.Specs.Extensions
{
    public static class DateIntervalExtensions
    {
        public static string AsFormatted(this DateInterval value)
        {
            var formatter = new DateIntervalValueFormatter();
            var graph = new FormattedObjectGraph(1);
            formatter.Format(value, graph, null, null);

            return graph.ToString();
        }
    }
}
