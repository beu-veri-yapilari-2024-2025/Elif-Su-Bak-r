using System;

class SortingAlgorithms
{
    static void Main()
    {
        int[] dizi = { 5, 3, 8, 4, 2 };

        Console.WriteLine("Başlangıç Dizisi:");
        Yazdir(dizi);

        Console.WriteLine("\n--- BUBBLE SORT ---");
        BubbleSort((int[])dizi.Clone());

        Console.WriteLine("\n--- SELECTION SORT ---");
        SelectionSort((int[])dizi.Clone());

        Console.WriteLine("\n--- INSERTION SORT ---");
        InsertionSort((int[])dizi.Clone());
    }

    // ================= BUBBLE SORT =================
    static void BubbleSort(int[] dizi)
    {
        Console.WriteLine("Zaman Karmaşıklığı: O(n²)");
        int n = dizi.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (dizi[j] > dizi[j + 1])
                {
                    int temp = dizi[j];
                    dizi[j] = dizi[j + 1];
                    dizi[j + 1] = temp;
                }
                Yazdir(dizi);
            }
            Console.WriteLine($"Tur {i + 1} tamamlandı");
        }
    }

    // ================= SELECTION SORT =================
    static void SelectionSort(int[] dizi)
    {
        Console.WriteLine("Zaman Karmaşıklığı: O(n²)");
        int n = dizi.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (dizi[j] < dizi[minIndex])
                    minIndex = j;
            }

            int temp = dizi[i];
            dizi[i] = dizi[minIndex];
            dizi[minIndex] = temp;

            Yazdir(dizi);
            Console.WriteLine($"Tur {i + 1} tamamlandı");
        }
    }

    // ================= INSERTION SORT =================
    static void InsertionSort(int[] dizi)
    {
        Console.WriteLine("Zaman Karmaşıklığı: O(n²) | En iyi durum: O(n)");

        for (int i = 1; i < dizi.Length; i++)
        {
            int key = dizi[i];
            int j = i - 1;

            while (j >= 0 && dizi[j] > key)
            {
                dizi[j + 1] = dizi[j];
                j--;
                Yazdir(dizi);
            }

            dizi[j + 1] = key;
            Yazdir(dizi);
            Console.WriteLine($"Tur {i} tamamlandı");
        }
    }

    // ================= YAZDIR =================
    static void Yazdir(int[] dizi)
    {
        foreach (int x in dizi)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
