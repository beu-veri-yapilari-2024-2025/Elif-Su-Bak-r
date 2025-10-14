using System;
class Program
{
    static void Main()
    {
        int[] sayilar = {2345, 6743, 3467 ,123,456,789,9078};

        int toplam = 0;


        foreach (int sayi in sayilar)
        {
            toplam += sayi;
        }

        Console.WriteLine(toplam);
    }
}