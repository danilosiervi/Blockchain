using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Blockchain;

public class Wallet
{
    private RSACryptoServiceProvider _rsa = new(2048);

    private RSAParameters _publicKey;
    private RSAParameters _privateKey;

    public Wallet()
    {
        _privateKey = _rsa.ExportParameters(true);
        _publicKey = _rsa.ExportParameters(false);
    }

    public string GetPublicKey()
    {
        var sw = new StringWriter();
        var xs = new XmlSerializer(typeof(RSAParameters));

        xs.Serialize(sw, _publicKey);

        return sw.ToString();
    }

    public void SendMoney(double amount, string payeePublicKey)
    {
        var transaction = new Transaction(amount, GetPublicKey(), payeePublicKey);

        var signature = _rsa.SignData(transaction.Hash(), nameof(SHA256));

        Chain.GetChain().AddBlock(transaction, _publicKey, signature);
    }
}
