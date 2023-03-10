using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Blockchain;

public class Transaction
{
    public double Amount { get; }
    public string Payer { get; }
    public string Payee { get; }

    public Transaction(double amount, string payer, string payee)
    {
        Amount = amount;
        Payer = payer;
        Payee = payee;
    }

    public byte[] Hash()
    {
        using HashAlgorithm algorithm = SHA256.Create();

        string jsonString = JsonSerializer.Serialize(this);
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(jsonString));
    }
}
