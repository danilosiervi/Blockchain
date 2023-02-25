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

        string contains = string.Concat(PrevHash, Transaction.Hash());
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(contains));
    }

    public int nounce = new Random().Next(int.MaxValue);

    public override string ToString()
    {
        if (PrevHash == null)
        {
            return $"    Hash: {Encoding.UTF8.GetString(Hash())} \n    PrevHash: null" +
                $"\n    Transaction: {Encoding.UTF8.GetString(Transaction.Hash())} \n    Time: {Time}";
        }

        return $"    Hash: {Encoding.UTF8.GetString(Hash())} \n    PrevHash: {Encoding.UTF8.GetString(PrevHash)}" +
            $"\n    Transaction: {Encoding.UTF8.GetString(Transaction.Hash())} \n    Time: {Time}";
    }
}
