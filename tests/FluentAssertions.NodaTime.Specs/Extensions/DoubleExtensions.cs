using FluentAssertions.Formatting;

namespace FluentAssertions.NodaTime.Specs.Extensions
{
    public static class DoubleExtensions
    {
        public static string AsFormatted(this double value)
        {
            var formatter = new DoubleValueFormatter();
            var graph = new FormattedObjectGraph(1);
            formatter.Format(value, graph, null, null);

            return graph.ToString();
        }
    }
}
