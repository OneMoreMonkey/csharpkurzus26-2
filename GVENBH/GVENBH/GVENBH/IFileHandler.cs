using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace GVENBH;

internal interface IFileHandler
{
    public void Save(IEnumerable<Transaction> data, string filename="mydata");
    public IEnumerable<Transaction> Load( string filename="mydata" );
}

internal class FileHandler : IFileHandler
{
    public IEnumerable<Transaction> Load(string filename = "mydata")
    {
        filename += ".json";
        string text = File.ReadAllText(filename);

        List<Transaction>? data = JsonSerializer.Deserialize<List<Transaction>>(text);
        if (data != null)
        {
            Console.WriteLine("  -FileHnadler: is it worked?");

        }
        return data;
    }

    public void Save(IEnumerable<Transaction> data, string filename = "mydata" )
    {
        filename += ".json";
        string jsonString = JsonSerializer.Serialize(data);
        File.WriteAllText(filename, jsonString);
    }
}