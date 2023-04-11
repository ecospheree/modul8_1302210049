// See https://aka.ms/new-console-template for more information
using System.Text.Json;

public class Program
{
    private static void Main(string[] args)
    {

    }
}

public class BankTransferConfig
{
    public BTConfig config;
    String pathfile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    String banktransferfile = "bank_transfer_config.json";\
    
    public BankTransferConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch 
        {
            writeConfigFile();
        }
    }

    private BTConfig ReadConfigFile()
    {
        string filepath = File.ReadAllText(pathfile + "/" + banktransferfile);
        config = JsonSerializer.Deserialize<BTConfig>(filepath);
        return config;
    }
    private void writeConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };
        string textTulis = JsonSerializer.Serialize(banktransferfile, options);
        string FullFilePath = pathfile + banktransferfile + pathfile + "/" + banktransferfile;
        File.WriteAllText(pathfile, textTulis);
    }

    private void setDefaultConfig()
    {
        BankTransfer bankTransfer = new BankTransfer(25000000, 6500, 15000);
        BankTransferConfirmation confirmation = new BankTransferConfirmation("yes", "ya");
        List<String> list = new List<String>() { "RTO(real-time)", "SKN", "RTGS", "BIFAST"  };
        config = new BTConfig("en", bankTransfer, list, confirmation);
    }
}

public class BTConfig
{
    public string lang {  get; set; }
    public BankTransfer banktf { get; set; }
    public List<String> BankTransferMethod { get; set;  }
    public BankTransferConfirmation confirmation { get; set; }

    public BTConfig()
    {

    }

    public BTConfig(string lang, BankTransfer banktransfer, List<String> bankTransferMethod, BankTransferConfirmation confirmation)
    {
        this.lang = lang;
        this.banktf = banktransfer;
        this.BankTransferMethod = bankTransferMethod;
        this.confirmation = confirmation;
    }
}

public class BankTransfer
{
    public double threshold { get; set; }
    public double low_fee { get; set; }
    public double high_fee { get; set;}

    public BankTransfer()
    {

    }

    public BankTransfer(double threshold, double low_fee, double high_fee)
    {
        this.threshold = threshold;
        this.low_fee = low_fee;
        this.high_fee = high_fee;
    }
}

public class BankTransferConfirmation
{
    public string en { get; set; }
    public string id { get; set; }

    public BankTransferConfirmation() { }

    public BankTransferConfirmation(string en, string id)
    {
        this.en = en;
        this.id = id;
    }
}





