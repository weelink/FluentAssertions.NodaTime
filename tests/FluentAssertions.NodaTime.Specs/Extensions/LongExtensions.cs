using FluentAssertions.Formatting;

namespace FluentAssertions.NodaTime.Specs.Extensions
{
    public static class LongExtensions
    {
        public static string AsFormatted(this long value)
        {
            var formatter = new Int64ValueFormatter();
            var graph = new FormattedObjectGraph(1);
            formatter.Format(value, graph, null, null);

            return graph.ToString();
        }
    }
}
