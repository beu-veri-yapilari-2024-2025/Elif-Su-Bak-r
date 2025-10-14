class Program
{
    static void Main()
    {
        int[] A = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 29, 31, 33, 35, 37, 39, 41 };
        int sayi = 15;

        int indeks = IkiliArama(A, sayi);

        if (indeks != -1)
            Console.WriteLine($"{sayi} sayısı dizide {indeks}. indekste bulundu.");
        else
            Console.WriteLine($"{sayi} sayısı dizide bulunamadı.");
    }

    static int IkiliArama(int[] A, int sayi)
    {
        int sol = 0;
        int sag = A.Length - 1;

        while (sol <= sag)
        {
            int orta = (sol + sag) / 2;

            if (A[orta] == sayi)
                return orta;
            else if (sayi < A[orta])
                sag = orta - 1;
            else
                sol = orta + 1;
        }

        return -1;
    }
}