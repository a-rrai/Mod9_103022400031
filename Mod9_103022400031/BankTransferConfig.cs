using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text.Json;

public class BankTransferConfig
{
    public Config config;
    private const string filePath = "bank_transfer_config.json";
    int biayaTransfer = 2500;
    int nominalTransfer;
    int totalBiaya;

    public BankTransferConfig() 
    {
        ReadConfig();
    }

    private void ReadConfig()
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(jsonString);
        }
        else
        {
            config = new Config(
                "en",
                "25000000",
                "6500",
                "15000",
                ["RTO (real-time)", "SKN", "RTGS", "BI FAST"],
                "yes",
                "ya"
            );
            WriteConfig();
        }
    }

    private void WriteConfig()
    {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, jsonString);
    }

    public void UbahLanguage()
    {
        if (config.lang == "en")
        {
            Console.WriteLine("Select Transfer Method: " + config.methods);
            Console.WriteLine("Please insert the amount of money to transfer: ");
            Console.WriteLine("Transfer fee: " + biayaTransfer);
            Console.WriteLine("Total amount: " + (nominalTransfer + biayaTransfer));
        }
        else
        {
            Console.WriteLine("Pilih metode transfer: " + config.methods);
            Console.WriteLine("Masukkan jumlah uang yang akan di transfer: ");
            Console.WriteLine("Biaya transfer: " + biayaTransfer);
            Console.WriteLine("Total biaya: " + (nominalTransfer + biayaTransfer));
        }
        WriteConfig();
    }

    public void TotalBiaya()
    {
        if (config.transfer <= 25000000)
        {
            Console.WriteLine("low_fee");
        }
        else
        {
            Console.WriteLine("high_fee");
        } 
        WriteConfig();
    }

    public void Konfirmasi()
    {
        if (config.lang == "en")
        {
            Console.WriteLine("Please type " + config.confirmation + " to confirm the transaction: ");
        }
        else
        {
            Console.WriteLine("Ketik " + config.confirmation + " untuk mengkonfirmasi transaksi: ");
        }
        WriteConfig();
    }
}
