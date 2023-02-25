using System.Xml.Serialization;

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

    public override string ToString()
    {
        return string.Concat(Amount, Payer, Payee);
    }
}
