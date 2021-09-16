using System;

using FluentAssertions.Formatting;

namespace FluentAssertions.NodaTime.Specs.Extensions
{
    public static class EnumExtensions
    {
        public static string AsFormatted(this Enum value)
        {
            var formatter = new EnumValueFormatter();
            var graph = new FormattedObjectGraph(1);
            formatter.Format(value, graph, null, null);

            return graph.ToString();
        }
    }
}
