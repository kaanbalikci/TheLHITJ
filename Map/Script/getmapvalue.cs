using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class getmapvalue : MonoBehaviour
{
    public Slider TreeDensity; // Aðaç yoðunluðu slider
    public Slider TreeScale;  // Aðaç boyutu slider

    public TMP_InputField SeedInput; // Seed veri alma textbox
    static char[] Seed = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' }; // Seed dizisi elemanlarý
    //K = .(nokta)
    //L = -(tire)

    public static int newtreevalue = 12; // Aðaç yoðunluðu verisi(Default 12)
    public static double newscalevalue = 0.92; //  Aðaç yüksekliði verisi (Default 0.92)
    public static string enc; // Seed harflerini tutan deðiþken

    public GameObject CreateMapbtn, CreateMapPanel, MapSeedCodebtn, MapSeedCodePanel;
    public GameObject FirstReturn, SecondReturn, ThirdReturn;

    // CreateMapbtn => Create Map Buton Gameobject
    // CreateMapPanel => Create Map Panel Gameobject
    // MapSeedCodebtn => Seed Code Buton Gameobject
    // MapSeedCodePanel => Seed Code Panel Gameobject


    public void btn_change_scene(string scene_name) // Yeni Harita oluþturulmadan hemen önceki buton // Geçiþ yapýlacak sahneyi string ile alma
    {
        newtreevalue = (int)TreeDensity.value; // Sliderdaki deðeri deðiþkene atama
        newscalevalue = TreeScale.value; // Sliderdaki deðeri deðiþkene atama
        newscalevalue = Math.Round(newscalevalue, 2); // Virgülden sonra 2 basamak alarak deðiþkene atama
        SceneManager.LoadScene(scene_name); // Girilen sahne ismine göre yeni sahneyi yükleme

        enc = encript(newtreevalue, newscalevalue); // encript fonksiyonu Seed'i oluþturur. Bu seed enc deðiþkeni içerisine atýlýr.

    }
    public void SeedEnc(string scene) // Seed ile sahneyi yükleme fonksiyonu buton aracýlýðý ile çalýþtýrma
    {
        if (SeedInput.text.IndexOf("L") == 2 && SeedInput.text.Length == 7) // Text içerisinde 2. index numarasý "L" ve text uzunluðu 7 ise
        {
            string[] values = SeedInput.text.Split('L'); // Values dizisi içerisine text içerindeki L den ayýrarak atama yap.

            newtreevalue = getTreeValue(values[0]); // Dizi 2 ye bölünür. Birince deðer Aðaç yoðunluðu verisini
            newscalevalue = getScaleValue(values[1]); // Ýkinci deðer ise Aðaç yüksekliði verisini tutar.

            if (newtreevalue != -1 && newscalevalue != -1) // Deðerler -1 olmadýðýnda gir
            {
                if ((newtreevalue >= 10 && newtreevalue <= 17) && (newscalevalue >= 0.75 && newscalevalue <= 1.25)) // Deðerler belirlenen aralýklarda ise
                {
                    print("sahne yüklendi");
                    //BHLAKHF
                    SceneManager.LoadScene(scene); // Sahneyi yükle
                    enc = encript(newtreevalue, newscalevalue); // encript fonksiyonu Seed'i oluþturur. Bu seed enc deðiþkeni içerisine atýlýr.
                }
                else
                {
                    print("Sýnýr deðerler aþýldý");
                }
            }
            else
            {
                print("geçersiz2");
            }

        }
        else
        {
            print("Tire yok ise Seed hatalý");
        }
    }

    public static string encript(int a, double b)
    {
        string value1 = a.ToString() + "-" + b.ToString(); // Deðerler string olarak birleþtirilir ve tire ile birleþtirilir.
        string output = "";
        //value1 => 10-0,80
        //char[] Seed = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' }
        for (int i = 0; i < value1.Length; i++)
        {

            if (value1[i] == ',') // value1[i] deðeri virgül ise
            {
                output += 'K'; //output içine K ekle
            }
            else if (value1[i] == '-') // value1[i] deðeri tire ise
            {
                output += 'L'; //output içine L ekle
            }
            else
            {
                string tmpChar = value1[i].ToString(); //Value1[i] bize char deðeri döndürdüðünden int olarak doðrudan kullanamadýðýmýzdan dönüþüm iþlemi yapýlýyor.
                int tmp = Convert.ToInt32(tmpChar);    // ASCII deðer döndüðünden dönüþüm iþlemlerine devam edip tmp içerisinde int olarak saklýyoruz.
                output += Seed[tmp]; // Output içerisine Seed dizisinden harf eklemesi yapýyoruz.
            }
        }

        return output; // Oluþturulan seed geri döndürülür.

    }
    public static int getTreeValue(string s)
    {
        string output = ""; // TreeValue için oluþturulacak deðer(10-17)
        int Control = 0; // Seed den gelen deðerinin geçerliðiðinin kontrolünü saðlayan deðiþken 
        int i = 0;

        for (i = 0; i < s.Length; i++) // Seed'in L'den önceki kýsmý s içerisinde tutuluyor. Buradaki karakterler for döngüsü aracýlýðý ile kontrolü saðlanýyor.
        {
            /*
             * s'in her karakteri için dönülmesi gerekiyor bu yüzden for döngüsü kullanýyoruz.
             * Karakterler Seed dizisi içerisinde aranacak. Karakter bulunduktan sonra döngüden çýkýlabilir.
             * Bu sebeple founded deðiþkeni kullanýldý.
             * Karakter bulunursa founded true yapýlarak While döngüsünden çýkýlýr.
             */
            bool founded = false;
            int k = 0;
            while (!founded && k < Seed.Length)
            { // s getTreeValue dizisi
                if (s[i] == 'K') // Eðer k gelirse ouputa virgül ekler ve founded deðerini true yapar
                {
                    output += ',';
                    founded = true;
                    Control++;
                }
                else if (s[i] == Seed[k])
                {
                    output += k;
                    founded = true;
                    Control++;
                }
                k++;
            }

        }
        if (Control == i)
        {/* 
          * Bulunan karakter sayýsý Seed'in ilk kýsmýnýn karakter sayýsý ile eþitleniyor ise
          * çözümleme tamamlanmýþ demektir.
          * Bu deðer integera çevrilerek geri döndürülür.
          * */
            return Convert.ToInt32(output);
        }
        else
        {// Bulunamaz ise -1 döner.
            return -1;
        }
    }
    public static double getScaleValue(string s)
    {
        string output = "";
        int Control = 0;
        int i;
        for (i = 0; i < s.Length; i++)
        {
            bool founded = false;
            int k = 0;
            while (!founded && k < Seed.Length)
            {
                if (s[i] == 'K')
                {
                    output += ',';
                    founded = true;
                    Control++;
                }
                else if (s[i] == Seed[k])
                {
                    output += k;
                    founded = true;
                    Control++;
                }
                k++;
            }
        }
        if (Control == i)
        {
            return Convert.ToDouble(output);
        }
        else
        {
            return -1;
        }

    }
    public void CreateMap() // Canvasdaki CreateMapbtn basýnca çalýþan fonksiyon
    {
        CreateMapPanel.SetActive(true);
        CreateMapbtn.SetActive(false);            // Gameobject görünürlerini deðiþtirme
        MapSeedCodebtn.SetActive(false);
        FirstReturn.SetActive(false);
        SecondReturn.SetActive(false);
        ThirdReturn.SetActive(true);
    }
    public void CreateMapWithSeed() // Canvasdaki SeedCodebtn basýnca çalýþan fonksiyon
    {
        CreateMapbtn.SetActive(false);
        MapSeedCodebtn.SetActive(false);          // Gameobject görünürlerini deðiþtirme
        MapSeedCodePanel.SetActive(true);
        FirstReturn.SetActive(false);
        SecondReturn.SetActive(true);
        ThirdReturn.SetActive(false);

        // FirstReturn, SecondReturn, ThirdReturn;
    }
}
