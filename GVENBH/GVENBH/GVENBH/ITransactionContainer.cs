using System;
using System.Collections.Generic;
using System.Text;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GVENBH;

internal interface ITransactionContainer
{
    public IEnumerable<Transaction> GetTransactions();
    public void Add(string date, string subject, string amountStr);
    public void Populate(IEnumerable<Transaction> transactions);
}

internal class TransactionContainer : ITransactionContainer
{
    private List<Transaction> _transactions = new();
    public void Add(string date, string subject, string amountStr)
    {
        _transactions.Add( new Transaction(date,  subject,  amountStr));
    }

    public IEnumerable<Transaction> GetTransactions()
    {
        return _transactions.AsReadOnly();
    }

    public void Populate(IEnumerable<Transaction> transactions)
    {
        _transactions = transactions.ToList();
    }
}