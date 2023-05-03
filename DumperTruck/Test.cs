using NUnit.Framework;

namespace DumperTruck;

[TestFixture]
public class Test
{
    [Test]
    public void TableTest()
    {
        var arr =
            new int[3]
            {
                1, 2, 3
            }.Dump("Array Test");
        
       var obj = new List<string>()
       {
           "f","t"
       }.Dump("List Test");
       
       Dictionary<string, string> dic = new Dictionary<string, string>()
       {
           { "myname", "Ali" }      
        }.Dump("Dictionary Test");
       
       "Today 5/3/2023".Dump("String Test");

    }
}