using Shouldly;
using Spectre.Console.Composition;
using Xunit;

namespace Spectre.Console.Tests.Unit.Composition
{
    public sealed class SegmentTests
    {
        [Fact]
        public void Should_Split_Segment()
        {
            var lines = Segment.Split(new[]
            {
                new Segment("Foo"),
                new Segment("Bar"),
                new Segment("\n"),
                new Segment("Baz"),
                new Segment("Qux"),
                new Segment("\n"),
                new Segment("Corgi"),
            });

            // Then
            lines.Count.ShouldBe(3);

            lines[0].Count.ShouldBe(2);
            lines[0][0].Text.ShouldBe("Foo");
            lines[0][1].Text.ShouldBe("Bar");

            lines[1].Count.ShouldBe(2);
            lines[1][0].Text.ShouldBe("Baz");
            lines[1][1].Text.ShouldBe("Qux");

            lines[2].Count.ShouldBe(1);
            lines[2][0].Text.ShouldBe("Corgi");
        }

        [Fact]
        public void Should_Split_Segments_With_Linebreak_In_Text()
        {
            var lines = Segment.Split(new[]
            {
                new Segment("Foo\n"),
                new Segment("Bar\n"),
                new Segment("Baz"),
                new Segment("Qux\n"),
                new Segment("Corgi"),
            });

            // Then
            lines.Count.ShouldBe(4);

            lines[0].Count.ShouldBe(1);
            lines[0][0].Text.ShouldBe("Foo");

            lines[1].Count.ShouldBe(1);
            lines[1][0].Text.ShouldBe("Bar");

            lines[2].Count.ShouldBe(2);
            lines[2][0].Text.ShouldBe("Baz");
            lines[2][1].Text.ShouldBe("Qux");

            lines[3].Count.ShouldBe(1);
            lines[3][0].Text.ShouldBe("Corgi");
        }
    }
}