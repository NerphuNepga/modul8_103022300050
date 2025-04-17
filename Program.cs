// See https://aka.ms/new-console-template for more information
using modul8_103022300050;

UIConfig uIconfig = new UIConfig();
BankTransferConfig bankTransferConfig = uIconfig.ReadConfigFile();
Console.WriteLine(bankTransferConfig.transfer.threshold);

if (bankTransferConfig.lang == "en")
{
    Console.Write("Please insert the amount of money to transfer: ");
}else if (bankTransferConfig.lang == "id")
{
    Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
}
int jmlTf = int.Parse(Console.ReadLine());
int totalTf = 0;

if (jmlTf <= bankTransferConfig.transfer.threshold)
{
    totalTf = jmlTf + bankTransferConfig.transfer.low_fee;
}
else if (jmlTf > bankTransferConfig.transfer.threshold)
{
    totalTf = jmlTf + bankTransferConfig.transfer.high_fee;
}

if (bankTransferConfig.lang == "en")
{
    Console.WriteLine("Transfer fee = " + (totalTf-jmlTf));
    Console.WriteLine("Total Amount = " + totalTf);
    Console.WriteLine();
    Console.WriteLine("Select transfer method: ");
}
else if (bankTransferConfig.lang == "id")
{
    Console.WriteLine("Biaya transfer = " + (totalTf - jmlTf));
    Console.WriteLine("Total Biaya = " + totalTf);
    Console.WriteLine();
    Console.WriteLine("Pilih metode transfer: ");
}

for (int i = 0; i < 4; i++)
{
    Console.WriteLine((i+1) + " " + bankTransferConfig.methods[i]);
}

string method = Console.ReadLine();

if (bankTransferConfig.lang == "en")
{
    Console.Write("Please type '" + bankTransferConfig.confirmation.en + "' to confirm the transaction: ");
}
else if (bankTransferConfig.lang == "id")
{
    Console.Write("Ketik '" + bankTransferConfig.confirmation.id + "' untuk mengkonfirmasi transaksi: ");
}

string confirm =  Console.ReadLine();

if (bankTransferConfig.lang == "en")
{
    if (confirm == bankTransferConfig.confirmation.en)
    {
        Console.WriteLine("The transfer is completed");
    } else
    {
        Console.WriteLine("Transfer is cancelled");
    }
}
else if (bankTransferConfig.lang == "id")
{
    if (confirm == bankTransferConfig.confirmation.id)
    {
        Console.WriteLine("Proses transfer berhasil");
    }
    else
    {
        Console.WriteLine("Transfer dibatalkan");
    }
}
