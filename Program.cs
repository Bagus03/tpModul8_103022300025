using System;

class Program
{
    static void Main(string[] args)
    {
        string path = "covid_config.json";
        CovidConfig config = CovidConfig.BacaKonfigurasi(path);

        // Tampilkan satuan saat ini
        Console.WriteLine($"Satuan suhu saat ini adalah: {config.satuan_suhu}");

        // Tawarkan opsi untuk mengubah satuan
        Console.Write("Apakah Anda ingin mengubah satuan suhu? (y/n): ");
        string inputUbah = Console.ReadLine().ToLower();

        if (inputUbah == "y")
        {
            config.UbahSatuan(path);
            Console.WriteLine($"Satuan suhu berhasil diubah menjadi: {config.satuan_suhu}");
        }

        Console.Write($"\nBerapa suhu badan anda saat ini? Dalam satuan {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        // Konversi ke celcius jika input dalam fahrenheit
        if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            suhu = (suhu - 32) * 5 / 9;
        }

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir demam? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        if (suhu >= 37.5 && hariDemam <= Convert.ToInt32(config.batas_hari_demam))
        {
            Console.WriteLine(config.pesan_ditolak);
        }
        else
        {
            Console.WriteLine(config.pesan_diterima);
        }
    }
}
