using NUnit.Framework;

namespace DumperTruck;

[TestFixture]
public class Test
{
    [Test]
    public void TableTest()
    {
        var obj = new List<string>()
        {
            "f","t"
        }.Dump();

        var myName = new
        {
            Name = "Ali"
        }.Dump("my Name is");

    }
}