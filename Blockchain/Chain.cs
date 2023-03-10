using System.Security.Cryptography;

namespace Blockchain;

public class Chain
{
    private Chain()
    {
        var genesis = new Block(null, new Transaction(100, "genesis", "satoshi"));

        Blockchain = new List<Block> { genesis };
    }

    private static readonly Chain _instance = new();

    public static Chain GetChain() => _instance;

    public List<Block> Blockchain;

    public Block GetLastBlock() => Blockchain[^1];

    public void AddBlock(Transaction transaction, RSAParameters senderPublicKey, byte[] signature)
    {
        using RSACryptoServiceProvider rsa = new(2048);
        rsa.ImportParameters(senderPublicKey);

        if (rsa.VerifyData(transaction.Hash(), nameof(SHA256), signature))
        {
            var newBlock = new Block(GetLastBlock().Hash(), transaction);

            Mine(newBlock.nonce);
            Blockchain.Add(newBlock);
        }
    }

    public static void Mine(int nonce)
    {
        int solution = 1;
        Console.WriteLine("mining...");

        while(true)
        {
            if (solution.CompareTo(nonce) > 0)
            {
                Console.WriteLine($"solved: {solution}\n");
                return;
            }

            solution += 1;
        }
    }

    public void ViewBlockchain()
    {
        Console.WriteLine("Blockchain [");
        Blockchain.ForEach(block => Console.WriteLine("    Block {\n" + block + "    },\n"));
        Console.WriteLine("]");
    }
}
