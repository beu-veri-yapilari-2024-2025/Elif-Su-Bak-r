using System;

class Program
{
    static void Main()
    {

        Console.Write("Birinci matrisin satır sayısını girin: ");
        int satir1 = int.Parse(Console.ReadLine());

        Console.Write("Birinci matrisin sütun sayısını girin: ");
        int sutun1 = int.Parse(Console.ReadLine());


        Console.Write("İkinci matrisin satır sayısını girin: ");
        int satir2 = int.Parse(Console.ReadLine());

        Console.Write("İkinci matrisin sütun sayısını girin: ");
        int sutun2 = int.Parse(Console.ReadLine());


        if (sutun1 != satir2)
        {
            Console.WriteLine("Matris çarpımı yapılamaz! Birinci matrisin sütun sayısı ile ikinci matrisin satır sayısı eşit olmalıdır.");
            return;
        }


        int[,] matris1 = new int[satir1, sutun1];
        int[,] matris2 = new int[satir2, sutun2];
        int[,] carpim = new int[satir1, sutun2];


        Console.WriteLine("\nBirinci matrisin elemanlarını girin:");
        for (int i = 0; i < satir1; i++)
        {
            for (int j = 0; j < sutun1; j++)
            {
                Console.Write($"matris1[{i},{j}]: ");
                matris1[i, j] = int.Parse(Console.ReadLine());
            }
        }


        Console.WriteLine("\nİkinci matrisin elemanlarını girin:");
        for (int i = 0; i < satir2; i++)
        {
            for (int j = 0; j < sutun2; j++)
            {
                Console.Write($"matris2[{i},{j}]: ");
                matris2[i, j] = int.Parse(Console.ReadLine());
            }
        }


        for (int i = 0; i < satir1; i++)
        {
            for (int j = 0; j < sutun2; j++)
            {
                for (int k = 0; k < sutun1; k++)
                {
                    carpim[i, j] += matris1[i, k] * matris2[k, j];
                }
            }
        }


        Console.WriteLine("\nMatris çarpımı sonucu:");
        for (int i = 0; i < satir1; i++)
        {
            for (int j = 0; j < sutun2; j++)
            {
                Console.Write(carpim[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}