using System;
using System.Collections.Generic;

class AdamAsmaca
{
    static void Main(string[] args)
    {
        string[] kelimeler = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin",
         
         "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan" 
       , "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İstanbul", 
         "Kırşehir", "Kocaeli", "Konya", "Kütahya" }; // Tahmin edilecek kelimeler
        Random random = new Random();
        string secilenKelime = kelimeler[random.Next(kelimeler.Length)]; // Rastgele kelime seçimi
        char[] tahminEdilenKelime = new string('_', secilenKelime.Length).ToCharArray(); // Boş tahmin dizisi
        List<char> yanlışTahminler = new List<char>(); // Yanlış tahmin edilen harfler listesi

        int kalanHak = 6; // Kullanıcının toplam hakkı

        while (kalanHak > 0 && new string(tahminEdilenKelime) != secilenKelime)
        {
            Console.Clear();
            Console.WriteLine("Adam Asmaca Oyununa Hoş Geldiniz!");
            Console.WriteLine("Tahmin Edilen Kelime: {0}", new string(tahminEdilenKelime));
            Console.WriteLine("Yanlış Tahminler: {0}", string.Join(", ", yanlışTahminler));
            Console.WriteLine("Kalan Hak: {0}", kalanHak);

            // Tahmin için geçerli bir karakter girilip girilmediğini kontrol ediyoruz
            char tahmin = ' '; // Varsayılan bir değer atanıyor
            bool gecerliTahmin = false;

            // Kullanıcının geçerli bir tahmin yapana kadar döngüde kalmasını sağlıyoruz
            do
            {
                Console.Write("Bir harf tahmin edin: ");
                string giris = Console.ReadLine().ToLower();

                // Boş veya çok uzun bir giriş yapılmadığından emin olun
                if (!string.IsNullOrEmpty(giris) && giris.Length == 1 && Char.IsLetter(giris[0]))
                {
                    tahmin = giris[0];  // Kullanıcının tahmini bir char olarak alınıyor
                    gecerliTahmin = true; // Geçerli bir tahmin yapıldığında döngüden çıkacak
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir harf girin.");
                }
            } while (!gecerliTahmin);

            // Eğer tahmin edilen harf seçilen kelimenin içinde varsa
            if (secilenKelime.IndexOf(tahmin) != -1)
            {
                for (int i = 0; i < secilenKelime.Length; i++)
                {
                    if (secilenKelime[i] == tahmin)
                    {
                        tahminEdilenKelime[i] = tahmin;  // Doğru tahmin edilen harfler yerleştiriliyor
                    }
                }
            }
            else
            {
                if (!yanlışTahminler.Contains(tahmin))
                {
                    yanlışTahminler.Add(tahmin);  // Yanlış tahmin edilen harf listeye ekleniyor
                    kalanHak--;
                }
                else
                {
                    Console.WriteLine("Bu harfi zaten tahmin ettiniz. Başka bir harf deneyin.");
                    Console.ReadKey();
                }
            }
        }

        // Oyun sonucu
        if (new string(tahminEdilenKelime) == secilenKelime)
        {
            Console.WriteLine("Tebrikler, kelimeyi doğru tahmin ettiniz: {0}", secilenKelime);
        }
        else
        {
            Console.WriteLine("Maalesef hakkınız bitti. Doğru kelime: {0}", secilenKelime);
        }

        // Konsolun açık kalması için ekliyoruz
        Console.WriteLine("Oyunu kapatmak için bir tuşa basın...");
        Console.ReadKey(); // Kullanıcı bir tuşa basana kadar konsol açık kalır
    }
}
