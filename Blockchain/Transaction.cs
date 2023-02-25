using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

public class Transaction
{
    public double Amount { get; set; }
    public string Payer { get; set; }
    public string Payee { get; set; }

    public Transaction(double amount, string payer, string payee)
    {
        Amount = amount;
        Payer = payer;
        Payee = payee;
    }

    public byte[] Hash()
    {
        using HashAlgorithm algorithm = SHA256.Create();

        string contains = string.Concat(Amount, Payer, Payee);
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(contains));
    }
}
