using System;

namespace SimpleMenu
{
    public class Karakter
    {
        public string Nama { get; set; }
        public Karakter(string nama) { Nama = nama; }
        public void Tampilkan() => Console.WriteLine($"Karakter: {Nama}");
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("===== SIMPLE GAME MENU =====\n1. Informasi Karakter\n2. Mainkan Permainan\n3. Perpindahan Angka\n4. Tombol Keyboard\n5. Keluar\nPilihanmu: ");
                switch (Console.ReadLine())
                {
                    case "1": InfoKarakter(); break;
                    case "2": MainkanPermainan(); break;
                    case "3": PerpindahanAngka(); break;
                    case "4": TombolKeyboard(); break;
                    case "5": Console.WriteLine("Kamu keluar dari permainan!"); return;
                    default: Console.WriteLine("Pilihan tidak valid!"); Console.ReadKey(); break;
                }
            }
        }

        static void Kembali() { Console.WriteLine("\nTekan tombol untuk kembali..."); Console.ReadKey(); }

        // MENU 1: INFORMASI KARAKTER
        static void InfoKarakter()
        {
            Console.Clear();
            Console.WriteLine("=== INFORMASI KARAKTER ===");
            foreach (var nama in new[] { "Balmond", "Miya", "Alucard" })
                new Karakter(nama).Tampilkan();
            Kembali();
        }

        // MENU 2: MAINkan PERMAINAN
        static void MainkanPermainan()
        {
            Console.Clear();
            int hpHero = 100, hpMusuh = 100;
            Console.WriteLine("=== SIMULASI PERTARUNGAN ===");
            while (hpHero > 0 && hpMusuh > 0)
            {
                Console.Write($"\nHP Hero  : {hpHero}\nHP Musuh : {hpMusuh}\n\n1. Serang\n2. Kembali ke Menu Utama\nPilihan: ");
                string pilih = Console.ReadLine();
                if (pilih == "2") return;
                if (pilih != "1") { Console.WriteLine("Pilihan tidak valid!"); continue; }
                hpMusuh -= 20;
                Console.WriteLine("Hero menyerang musuh!");
                if (hpMusuh > 0) { hpHero -= 10; Console.WriteLine("Musuh membalas serangan!"); }
            }
            Console.WriteLine(hpHero <= 0 ? "\nHero kalah!" : "\nMusuh berhasil dikalahkan!");
            Kembali();
        }

        // MENU 3: PERPINDAHAN ANGKA
        static void PerpindahanAngka()
        {
            Console.Clear();
            int posisi = 0;
            Console.WriteLine("=== PERPINDAHAN ANGKA ===");
            while (true)
            {
                Console.Write($"\nPosisi karakter: {posisi}\n1. Maju\n2. Mundur\n3. Kembali ke Menu Utama\nPilihan: ");
                switch (Console.ReadLine())
                {
                    case "1": posisi++; break;
                    case "2": posisi--; break;
                    case "3": return;
                    default: Console.WriteLine("Pilihan tidak valid!"); break;
                }
            }
        }

        // MENU 4: TOMBOL KEYBOARD
        static void TombolKeyboard()
        {
            Console.Clear();
            int posisiX = 0, posisiY = 0;
            Console.WriteLine("=== SIMULASI TOMBOL KEYBOARD ===\nGunakan W A S D untuk bergerak.\nTekan ESC untuk kembali.");
            while (true)
            {
                Console.WriteLine($"\nPosisi X: {posisiX}\nPosisi Y: {posisiY}");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W: posisiY++; break;
                    case ConsoleKey.S: posisiY--; break;
                    case ConsoleKey.A: posisiX--; break;
                    case ConsoleKey.D: posisiX++; break;
                    case ConsoleKey.Escape: return;
                }
            }
        }
    }
}