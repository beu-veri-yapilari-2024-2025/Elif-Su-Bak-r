using System;
using System.Collections.Generic;

class Dugum
{
    public int Deger;
    public Dugum Sol;
    public Dugum Sag;

    public Dugum(int deger)
    {
        Deger = deger;
        Sol = null;
        Sag = null;
    }
}

class IkiliAramaAgaci
{
    public Dugum Kok;

    public IkiliAramaAgaci()
    {
        Kok = null;
    }

    // ==================== EKLEME ====================
    public void Ekle(int deger)
    {
        Kok = EkleRec(Kok, deger);
    }

    private Dugum EkleRec(Dugum kok, int deger)
    {
        if (kok == null)
            return new Dugum(deger);

        if (deger < kok.Deger)
            kok.Sol = EkleRec(kok.Sol, deger);
        else if (deger > kok.Deger)
            kok.Sag = EkleRec(kok.Sag, deger);

        return kok;
    }

    // ==================== ARAMA ====================
    public bool Ara(int deger)
    {
        return AraRec(Kok, deger);
    }

    private bool AraRec(Dugum kok, int deger)
    {
        if (kok == null)
            return false;

        if (deger == kok.Deger)
            return true;

        if (deger < kok.Deger)
            return AraRec(kok.Sol, deger);
        else
            return AraRec(kok.Sag, deger);
    }

    // ==================== SİLME ====================
    public void Sil(int deger)
    {
        Kok = SilRec(Kok, deger);
    }

    private Dugum SilRec(Dugum kok, int deger)
    {
        if (kok == null)
            return kok;

        if (deger < kok.Deger)
            kok.Sol = SilRec(kok.Sol, deger);
        else if (deger > kok.Deger)
            kok.Sag = SilRec(kok.Sag, deger);
        else
        {
            if (kok.Sol == null && kok.Sag == null)
                return null;

            if (kok.Sol == null)
                return kok.Sag;

            if (kok.Sag == null)
                return kok.Sol;

            Dugum min = EnKucukDugum(kok.Sag);
            kok.Deger = min.Deger;
            kok.Sag = SilRec(kok.Sag, min.Deger);
        }
        return kok;
    }

    // ==================== MİN - MAKS ====================
    public Dugum EnKucukDugum(Dugum kok)
    {
        while (kok.Sol != null)
            kok = kok.Sol;
        return kok;
    }

    public Dugum EnBuyukDugum(Dugum kok)
    {
        while (kok.Sag != null)
            kok = kok.Sag;
        return kok;
    }

    // ==================== DOLAŞIM (TRAVERSAL) ====================
    public void OnEkDolas(Dugum kok) // Preorder
    {
        if (kok == null) return;
        Console.Write(kok.Deger + " ");
        OnEkDolas(kok.Sol);
        OnEkDolas(kok.Sag);
    }

    public void OrtaEkDolas(Dugum kok) // Inorder
    {
        if (kok == null) return;
        OrtaEkDolas(kok.Sol);
        Console.Write(kok.Deger + " ");
        OrtaEkDolas(kok.Sag);
    }

    public void SonEkDolas(Dugum kok) // Postorder
    {
        if (kok == null) return;
        SonEkDolas(kok.Sol);
        SonEkDolas(kok.Sag);
        Console.Write(kok.Deger + " ");
    }

    // ==================== LEVEL ORDER (GENİŞLİK ÖNCELİKLİ) ====================
    public void SeviyeSirasi()
    {
        if (Kok == null) return;

        Queue<Dugum> kuyruk = new Queue<Dugum>();
        kuyruk.Enqueue(Kok);

        while (kuyruk.Count > 0)
        {
            Dugum gecici = kuyruk.Dequeue();
            Console.Write(gecici.Deger + " ");

            if (gecici.Sol != null) kuyruk.Enqueue(gecici.Sol);
            if (gecici.Sag != null) kuyruk.Enqueue(gecici.Sag);
        }
    }
}

// ==================== MENÜ ====================
class Program
{
    static void Main()
    {
        IkiliAramaAgaci agac = new IkiliAramaAgaci();

        while (true)
        {
            Console.WriteLine("\n===== İKİLİ ARAMA AĞACI MENÜ =====");
            Console.WriteLine("1 - Değer Ekle");
            Console.WriteLine("2 - Değer Ara");
            Console.WriteLine("3 - Değer Sil");
            Console.WriteLine("4 - Ön Ek (Preorder)");
            Console.WriteLine("5 - Orta Ek (Inorder)");
            Console.WriteLine("6 - Son Ek (Postorder)");
            Console.WriteLine("7 - Seviye Sırası (Level Order)");
            Console.WriteLine("8 - En Küçük Değer");
            Console.WriteLine("9 - En Büyük Değer");
            Console.WriteLine("0 - Çıkış");
            Console.Write("Seçim yap: ");

            int secim = int.Parse(Console.ReadLine());
            if (secim == 0) break;

            int deger;
            switch (secim)
            {
                case 1:
                    Console.Write("Eklenecek değer: ");
                    deger = int.Parse(Console.ReadLine());
                    agac.Ekle(deger);
                    break;

                case 2:
                    Console.Write("Aranacak değer: ");
                    deger = int.Parse(Console.ReadLine());
                    Console.WriteLine(agac.Ara(deger) ? "Bulundu!" : "Yok.");
                    break;

                case 3:
                    Console.Write("Silinecek değer: ");
                    deger = int.Parse(Console.ReadLine());
                    agac.Sil(deger);
                    break;

                case 4:
                    Console.Write("Ön Ek Dolaşım: ");
                    agac.OnEkDolas(agac.Kok);
                    Console.WriteLine();
                    break;

                case 5:
                    Console.Write("Orta Ek Dolaşım: ");
                    agac.OrtaEkDolas(agac.Kok);
                    Console.WriteLine();
                    break;

                case 6:
                    Console.Write("Son Ek Dolaşım: ");
                    agac.SonEkDolas(agac.Kok);
                    Console.WriteLine();
                    break;

                case 7:
                    Console.Write("Seviye Sırası: ");
                    agac.SeviyeSirasi();
                    Console.WriteLine();
                    break;

                case 8:
                    Console.WriteLine("En Küçük = " + agac.EnKucukDugum(agac.Kok).Deger);
                    break;

                case 9:
                    Console.WriteLine("En Büyük = " + agac.EnBuyukDugum(agac.Kok).Deger);
                    break;
            }
        }
    }
}