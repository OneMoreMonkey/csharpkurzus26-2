using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GVENBH;

internal interface ITransactionManager
{
    public void MakeNew(string date, string subject, string amountStr);
    public IEnumerable<Transaction> GetTransactions();
    public void Save();
    public void Load();
}

internal class TransactionManager : ITransactionManager
{
    private readonly ITransactionContainer _transactionContainer = new TransactionContainer();
    private readonly IFileHandler _fileHandler = new FileHandler();
    public IEnumerable<Transaction> GetTransactions()
    {
        return _transactionContainer.GetTransactions();
    }

    public void MakeNew(string date, string subject, string amountStr)
    {
        _transactionContainer.Add(date, subject, amountStr);
    }

    public void Save()
    {
        _fileHandler.Save(_transactionContainer.GetTransactions());
    }

    public void Load()
    {
        _transactionContainer.Populate( _fileHandler.Load() );
    }
}