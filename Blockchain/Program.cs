namespace Blockchain;

class Program
{
    static void Main()
    {
        var satoshi = new Wallet();
        var danilo = new Wallet();
        var marina = new Wallet();

        satoshi.SendMoney(50, danilo.GetPublicKey());
        danilo.SendMoney(20, marina.GetPublicKey());
        marina.SendMoney(5, satoshi.GetPublicKey());
        satoshi.SendMoney(10, marina.GetPublicKey());

        Chain.GetChain().ExibirBlockchain();
    }
}
