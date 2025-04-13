using System;
using System.IO;
using Newtonsoft.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public string batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public CovidConfig()
    {
        satuan_suhu = "celcius";
        batas_hari_demam = "14";
        pesan_ditolak = "Anda dilarang masuk ke dalam gedung ini";
        pesan_diterima = "Anda diperbolehkan masuk ke dalam gedung ini";
    }

    public static CovidConfig BacaKonfigurasi(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<CovidConfig>(json);
        }
        catch
        {
            Console.WriteLine("Gagal membaca file konfigurasi. Menggunakan default.");
            return new CovidConfig();
        }
    }

    public void SimpanKonfigurasi(string path)
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public void UbahSatuan(string path)
    {
        if (satuan_suhu.ToLower() == "celcius")
        {
            satuan_suhu = "fahrenheit";
        }
        else
        {
            satuan_suhu = "celcius";
        }

        SimpanKonfigurasi(path);
    }
}
