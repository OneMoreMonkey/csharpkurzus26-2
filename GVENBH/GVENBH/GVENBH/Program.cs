namespace GVENBH;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        DateOnly currentDate;
        //DateOnly.TryParse("2000-10-23", out date);
        currentDate = DateOnly.FromDateTime(DateTime.Now);
        Console.WriteLine(currentDate.ToString("o"));

        ITransactionManager transactionManager = new TransactionManager();

        transactionManager.Load();

        while (true)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            string[] inputTokens = line.Split(" ");
            if (inputTokens.Length == 4 && inputTokens[0].ToLower().Equals("new"))
            {
                transactionManager.MakeNew(inputTokens[1], inputTokens[2], inputTokens[3]);
            }
            if (inputTokens[0].ToLower().Equals("list"))
            {
                var transactionList = transactionManager.GetTransactions();
                foreach (var transaction in transactionList) {
                    Console.WriteLine(transaction.ToString());
                }
            }
            if (inputTokens[0].ToLower().Equals("save"))
            {
                transactionManager.Save();
            }
        }
    }
}
//TODO: listázás paraméterezése, funkciói; BETÖLTÉS; további tagolás?; input tokenizációja?; parancsok kiszervezése?
// #megtanulni vakon gépelni