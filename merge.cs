using System;
using System.Collections.Generic;

/*
 MERGE SORT AÇIKLAMASI:
 --------------------
 Merge Sort, "Böl ve Fethet" mantığıyla çalışan bir sıralama algoritmasıdır.
 1) Liste ortadan ikiye bölünür
 2) Alt listeler tek eleman kalana kadar bölünür
 3) Alt listeler karşılaştırılarak birleştirilir
 Zaman Karmaşıklığı: O(n log n)
 Bellek Kullanımı: O(n)
 Stable bir algoritmadır.
*/

class Kitap
{
    public string KitapAdi { get; set; }
    public int BasimYili { get; set; }

    public Kitap(string kitapAdi, int basimYili)
    {
        KitapAdi = kitapAdi;
        BasimYili = basimYili;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // EN AZ 6 KİTAP İÇEREN LİSTE
        List<Kitap> kitaplar = new List<Kitap>()
        {
            new Kitap("Suç ve Ceza", 1866),
            new Kitap("Sefiller", 1862),
            new Kitap("1984", 1949),
            new Kitap("Beyaz Diş", 1906),
            new Kitap("Kürk Mantolu Madonna", 1943),
            new Kitap("Simyacı", 1988)
        };

        Console.WriteLine("📚 SIRALAMADAN ÖNCE:");
        KitaplariYazdir(kitaplar);

        // MERGE SORT İLE SIRALAMA
        kitaplar = MergeSort(kitaplar);

        Console.WriteLine("\n📚 SIRALAMADAN SONRA (Basım Yılı Artan):");
        KitaplariYazdir(kitaplar);

        Console.ReadLine();
    }

    // MERGE SORT METODU
    static List<Kitap> MergeSort(List<Kitap> kitaplar)
    {
        if (kitaplar.Count <= 1)
            return kitaplar;

        int orta = kitaplar.Count / 2;

        List<Kitap> sol = kitaplar.GetRange(0, orta);
        List<Kitap> sag = kitaplar.GetRange(orta, kitaplar.Count - orta);

        sol = MergeSort(sol);
        sag = MergeSort(sag);

        return Merge(sol, sag);
    }

    // BİRLEŞTİRME (MERGE) METODU
    static List<Kitap> Merge(List<Kitap> sol, List<Kitap> sag)
    {
        List<Kitap> sonuc = new List<Kitap>();
        int i = 0, j = 0;

        while (i < sol.Count && j < sag.Count)
        {
            if (sol[i].BasimYili <= sag[j].BasimYili)
            {
                sonuc.Add(sol[i]);
                i++;
            }
            else
            {
                sonuc.Add(sag[j]);
                j++;
            }
        }

        while (i < sol.Count)
        {
            sonuc.Add(sol[i]);
            i++;
        }

        while (j < sag.Count)
        {
            sonuc.Add(sag[j]);
            j++;
        }

        return sonuc;
    }

    // KİTAPLARI EKRANA YAZDIRMA
    static void KitaplariYazdir(List<Kitap> kitaplar)
    {
        foreach (var kitap in kitaplar)
        {
            Console.WriteLine($"Kitap Adı: {kitap.KitapAdi} | Basım Yılı: {kitap.BasimYili}");
        }
    }
}
