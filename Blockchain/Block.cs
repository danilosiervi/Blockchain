using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

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

        string jsonString = JsonSerializer.Serialize(this);
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(jsonString));
    }

    public int nonce = new Random().Next(int.MaxValue);

    public override string ToString()
    {
        if (PrevHash == null)
        {
            return $"        Hash: {BitConverter.ToString(Hash()).Replace("-", "")}\n" +
                $"        PrevHash: null\n" +
                $"        Transaction: {BitConverter.ToString(Transaction.Hash()).Replace("-", "")}\n" +
                $"        Time: {Time}\n";
        }

        return $"        Hash: {BitConverter.ToString(Hash()).Replace("-", "")}\n" +
            $"        PrevHash: {BitConverter.ToString(PrevHash).Replace("-", "")}\n" +
            $"        Transaction: {BitConverter.ToString(Transaction.Hash()).Replace("-", "")}\n" +
            $"        Time: {Time}\n";
    }
}
