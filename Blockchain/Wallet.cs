using System.Security.Cryptography;

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
        return BitConverter.ToString(_publicKey.Modulus) + BitConverter.ToString(_publicKey.Exponent);
    }

    public void SendMoney(double amount, string payeePublicKey)
    {
        var transaction = new Transaction(amount, GetPublicKey(), payeePublicKey);
        var signature = _rsa.SignData(transaction.Hash(), nameof(SHA256));

        Chain.GetChain().AddBlock(transaction, _publicKey, signature);
    }
}
