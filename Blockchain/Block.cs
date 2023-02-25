using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

public class Block
{
    public byte[] PrevHash { get; }
    public Transaction Transaction { get; }
    public DateTime Time { get; }

    public Block(byte[] prevHash, Transaction transaction)
    {
        PrevHash = prevHash;
        Transaction = transaction;

        Time = DateTime.UtcNow;
    }

    public byte[] Hash()
    {
        using HashAlgorithm algorithm = SHA256.Create();

        string contains = string.Concat(PrevHash, Transaction.ToString());
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(contains));
    }

    public int nounce = new Random().Next(999999) * 999999;
}
