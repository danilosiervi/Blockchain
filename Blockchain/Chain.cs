using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

public class Chain
{
    private Chain()
    {
        var genesis = new Block(null, new Transaction(100, "genesis", "satoshi"));

        Blockchain = new List<Block> { genesis };
    }

    private static readonly Chain _instance = new Chain();

    public static Chain GetChain()
    {
        return _instance;
    }

    public List<Block> Blockchain;

    public Block GetLastBlock()
    {
        return Blockchain[^1];
    }

    public void AddBlock(Transaction transaction, RSAParameters senderPublicKey, byte[] signature)
    {
        using RSACryptoServiceProvider rsa = new(2048);
        rsa.ImportParameters(senderPublicKey);

        if (rsa.VerifyData(Encoding.UTF8.GetBytes(transaction.ToString()), nameof(SHA256), signature))
        {
            var newBlock = new Block(GetLastBlock().Hash(), transaction);

            Mine(newBlock.nounce);
            Blockchain.Add(newBlock);
        }
    }

    public static int Mine(int nounce)
    {
        int solution = 1;
        Console.WriteLine("mining...");

        while(true)
        {
            var secret = new Random().Next(nounce);

            if (secret.ToString().Take()
            {

            }

            solution += 1;
        }
    }
}
