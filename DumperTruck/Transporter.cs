using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Spectre.Console;

namespace DumperTruck;

public static class Transporter
{
    public static T Dump<T>(this T input, string text = null)
    {
        var table = input.ToTable();
        if (!string.IsNullOrEmpty(text))
            AnsiConsole.WriteLine(text);
        AnsiConsole.Write(table);
        return input;
    }

    private static Table ToTable<T>(this T input)
    {
        var inputType = input.GetType();
        var table = new Table();  
        if (IsList(input) || inputType.IsArray)
        {
            table.AddColumn("Value");
            foreach (var item in (IEnumerable)input)
            {
                table.AddRow(item.ToString());
            }
        }
  
        else
        {         
            if (input is IDictionary)
            {
                table.AddColumn("Key");
                table.AddColumn("Value");
                var dic = input as IDictionary;
                foreach (DictionaryEntry item in dic)
                {
                    table.AddRow(item.Key.ToString(), item.Value.ToString());
                }
            }
            else
            {     
                table.AddColumn("Value");
                table.AddRow(input.ToString());
            }
        }

        return table;
    }

    private static bool IsList(object obj)
    {
        if (obj == null) return false;
        return obj is IList &&
               obj.GetType().IsGenericType &&
               obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
    }
    
  
}