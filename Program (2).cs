using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<char, List<(char, int)>> graf =
        new Dictionary<char, List<(char, int)>>();

    static void Main()
    {
        GrafOlustur();

        Console.WriteLine("=== BFS (A'dan Başlayarak) ===");
        BFS('A');

        Console.WriteLine("\n=== DFS (A'dan Başlayarak) ===");
        HashSet<char> ziyaret = new HashSet<char>();
        DFS('A', ziyaret);
        Console.WriteLine();

        Console.WriteLine("\n=== DIJKSTRA (A -> F) ===");
        Dijkstra('A', 'F');
    }

    // ---------------- GRAF OLUŞTURMA ----------------
    static void GrafOlustur()
    {
        void KenarEkle(char a, char b, int w)
        {
            if (!graf.ContainsKey(a))
                graf[a] = new List<(char, int)>();
            if (!graf.ContainsKey(b))
                graf[b] = new List<(char, int)>();

            graf[a].Add((b, w));
            graf[b].Add((a, w)); // yönsüz graf
        }

        KenarEkle('A', 'B', 4);
        KenarEkle('A', 'C', 2);
        KenarEkle('B', 'D', 5);
        KenarEkle('C', 'B', 1);
        KenarEkle('C', 'E', 7);
        KenarEkle('D', 'F', 3);
        KenarEkle('E', 'F', 2);
        KenarEkle('B', 'E', 6);
    }

    // ---------------- BFS ----------------
    static void BFS(char baslangic)
    {
        Queue<char> kuyruk = new Queue<char>();
        HashSet<char> ziyaret = new HashSet<char>();

        kuyruk.Enqueue(baslangic);
        ziyaret.Add(baslangic);

        Console.Write("BFS Traversal: ");

        while (kuyruk.Count > 0)
        {
            char dugum = kuyruk.Dequeue();
            Console.Write(dugum + " ");

            foreach (var komsu in graf[dugum])
            {
                if (!ziyaret.Contains(komsu.Item1))
                {
                    ziyaret.Add(komsu.Item1);
                    kuyruk.Enqueue(komsu.Item1);
                }
            }
        }
        Console.WriteLine();
    }

    // ---------------- DFS ----------------
    static void DFS(char dugum, HashSet<char> ziyaret)
    {
        ziyaret.Add(dugum);
        Console.Write(dugum + " ");

        foreach (var komsu in graf[dugum])
        {
            if (!ziyaret.Contains(komsu.Item1))
                DFS(komsu.Item1, ziyaret);
        }
    }

    // ---------------- DIJKSTRA ----------------
    static void Dijkstra(char baslangic, char hedef)
    {
        Dictionary<char, int> mesafe = new Dictionary<char, int>();
        Dictionary<char, char?> onceki = new Dictionary<char, char?>();
        HashSet<char> ziyaret = new HashSet<char>();

        foreach (var dugum in graf.Keys)
        {
            mesafe[dugum] = int.MaxValue;
            onceki[dugum] = null;
        }

        mesafe[baslangic] = 0;

        while (ziyaret.Count < graf.Count)
        {
            char mevcut = '\0';
            int minMesafe = int.MaxValue;

            foreach (var d in mesafe)
            {
                if (!ziyaret.Contains(d.Key) && d.Value < minMesafe)
                {
                    minMesafe = d.Value;
                    mevcut = d.Key;
                }
            }

            if (mevcut == hedef)
                break;

            ziyaret.Add(mevcut);

            foreach (var komsu in graf[mevcut])
            {
                int yeniMesafe = mesafe[mevcut] + komsu.Item2;
                if (yeniMesafe < mesafe[komsu.Item1])
                {
                    mesafe[komsu.Item1] = yeniMesafe;
                    onceki[komsu.Item1] = mevcut;
                }
            }
        }

        Stack<char> yol = new Stack<char>();
        char? temp = hedef;

        while (temp != null)
        {
            yol.Push(temp.Value);
            temp = onceki[temp.Value];
        }

        Console.Write("En Kısa Yol: ");
        while (yol.Count > 0)
            Console.Write(yol.Pop() + " ");

        Console.WriteLine("\nToplam Mesafe: " + mesafe[hedef] + " dakika");
    }
}
