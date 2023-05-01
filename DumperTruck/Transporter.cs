using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using Spectre.Console;

namespace DumperTruck;

public static class Transporter
{
    public static T Dump<T>(this T input,string text = null)
    {
        var table = input.ToTable();
        if (!string.IsNullOrEmpty(text))
            AnsiConsole.WriteLine(text);
        AnsiConsole.Write(table);
        return input;
    }

    private static Table ToTable<T>(this T input)
    {
        var table = new Table();
        if (!IsList(input))
        {
            table.AddColumn("Key");
            table.AddColumn("Value");
            foreach (var prop in input.GetType().GetProperties())
            {
                table.AddRow(prop.Name, prop.GetValue(input, null).ToString());
            }
        }
        else
        {
            table.AddColumn("Value");
            foreach (var item in (IEnumerable)input)
            {
                table.AddRow(item.ToString());
            }
        }
        return table;
    }

    private static bool IsList(object obj)
    {
        if(obj == null) return false;
        return obj is IList &&
               obj.GetType().IsGenericType &&
               obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
    }
}