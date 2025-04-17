using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300050
{
    public class Transfer
    {
        public int threshold {  get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

        public Transfer(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    public class Confirmation
    {
        public string en {  get; set; }
        public string id { get; set; }

        public Confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }

        public BankTransferConfig() { }
        public BankTransferConfig(string lang, Transfer transfer, List<string> method,Confirmation confirmation) 
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = method;
            this.confirmation = confirmation;
        }
    }

    class UIConfig
    {
        public BankTransferConfig config;
        public const String filepath = @"bank_transfer_config.json";
        public BankTransferConfig ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            return config;
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config);
            File.WriteAllText(filepath, jsonString);
        }
        private void SetDefault()
        {
            Transfer transfer = new Transfer(25000000, 6500, 15000);
            Confirmation confirmation = new Confirmation("yes", "ya");
            List<string> method = [ "RTO (real time)", "SKN", "RTGS", "BI FAST" ];
            config = new BankTransferConfig("en", transfer, method, confirmation);
        }

        public UIConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
    }
}
