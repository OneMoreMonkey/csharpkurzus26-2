using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;


namespace GVENBH;

internal class Transaction
{
    //[JsonInclude]
    public DateOnly Date { get; }
    //[JsonInclude]
    public string Subject { get; }
    //[JsonInclude]
    public int Amount { get; }
    [JsonConstructor]
    public Transaction(DateOnly date, string subject, int amount)
    {
        Date = date;
        Subject = subject;
        Amount = amount;
    }

    public Transaction(string date, string subject, string amountStr)
    {
        if (date.Equals("now"))
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
        }
        else
        {
            DateOnly.TryParse(date, out DateOnly dateOnly);
            Date = dateOnly;
        }

        Subject = subject;

        if (Int32.TryParse(amountStr, out int amount))
        {
            Amount = amount;
            Console.WriteLine("siker: " + this);

        }
        else
        {
            Console.WriteLine("String could not be parsed.");
        }
    }

    public override string ToString()
    {
        return  Date.ToString("o")+" "+Subject+" "+Amount;
    }
}
