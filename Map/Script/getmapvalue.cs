using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class getmapvalue : MonoBehaviour
{
    public Slider TreeDensity; // A�a� yo�unlu�u slider
    public Slider TreeScale;  // A�a� boyutu slider

    public TMP_InputField SeedInput; // Seed veri alma textbox
    static char[] Seed = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' }; // Seed dizisi elemanlar�
    //K = .(nokta)
    //L = -(tire)

    public static int newtreevalue = 12; // A�a� yo�unlu�u verisi(Default 12)
    public static double newscalevalue = 0.92; //  A�a� y�ksekli�i verisi (Default 0.92)
    public static string enc; // Seed harflerini tutan de�i�ken

    public GameObject CreateMapbtn, CreateMapPanel, MapSeedCodebtn, MapSeedCodePanel;
    public GameObject FirstReturn, SecondReturn, ThirdReturn;

    // CreateMapbtn => Create Map Buton Gameobject
    // CreateMapPanel => Create Map Panel Gameobject
    // MapSeedCodebtn => Seed Code Buton Gameobject
    // MapSeedCodePanel => Seed Code Panel Gameobject


    public void btn_change_scene(string scene_name) // Yeni Harita olu�turulmadan hemen �nceki buton // Ge�i� yap�lacak sahneyi string ile alma
    {
        newtreevalue = (int)TreeDensity.value; // Sliderdaki de�eri de�i�kene atama
        newscalevalue = TreeScale.value; // Sliderdaki de�eri de�i�kene atama
        newscalevalue = Math.Round(newscalevalue, 2); // Virg�lden sonra 2 basamak alarak de�i�kene atama
        SceneManager.LoadScene(scene_name); // Girilen sahne ismine g�re yeni sahneyi y�kleme

        enc = encript(newtreevalue, newscalevalue); // encript fonksiyonu Seed'i olu�turur. Bu seed enc de�i�keni i�erisine at�l�r.

    }
    public void SeedEnc(string scene) // Seed ile sahneyi y�kleme fonksiyonu buton arac�l��� ile �al��t�rma
    {
        if (SeedInput.text.IndexOf("L") == 2 && SeedInput.text.Length == 7) // Text i�erisinde 2. index numaras� "L" ve text uzunlu�u 7 ise
        {
            string[] values = SeedInput.text.Split('L'); // Values dizisi i�erisine text i�erindeki L den ay�rarak atama yap.

            newtreevalue = getTreeValue(values[0]); // Dizi 2 ye b�l�n�r. Birince de�er A�a� yo�unlu�u verisini
            newscalevalue = getScaleValue(values[1]); // �kinci de�er ise A�a� y�ksekli�i verisini tutar.

            if (newtreevalue != -1 && newscalevalue != -1) // De�erler -1 olmad���nda gir
            {
                if ((newtreevalue >= 10 && newtreevalue <= 17) && (newscalevalue >= 0.75 && newscalevalue <= 1.25)) // De�erler belirlenen aral�klarda ise
                {
                    print("sahne y�klendi");
                    //BHLAKHF
                    SceneManager.LoadScene(scene); // Sahneyi y�kle
                    enc = encript(newtreevalue, newscalevalue); // encript fonksiyonu Seed'i olu�turur. Bu seed enc de�i�keni i�erisine at�l�r.
                }
                else
                {
                    print("S�n�r de�erler a��ld�");
                }
            }
            else
            {
                print("ge�ersiz2");
            }

        }
        else
        {
            print("Tire yok ise Seed hatal�");
        }
    }

    public static string encript(int a, double b)
    {
        string value1 = a.ToString() + "-" + b.ToString(); // De�erler string olarak birle�tirilir ve tire ile birle�tirilir.
        string output = "";
        //value1 => 10-0,80
        //char[] Seed = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' }
        for (int i = 0; i < value1.Length; i++)
        {

            if (value1[i] == ',') // value1[i] de�eri virg�l ise
            {
                output += 'K'; //output i�ine K ekle
            }
            else if (value1[i] == '-') // value1[i] de�eri tire ise
            {
                output += 'L'; //output i�ine L ekle
            }
            else
            {
                string tmpChar = value1[i].ToString(); //Value1[i] bize char de�eri d�nd�rd���nden int olarak do�rudan kullanamad���m�zdan d�n���m i�lemi yap�l�yor.
                int tmp = Convert.ToInt32(tmpChar);    // ASCII de�er d�nd���nden d�n���m i�lemlerine devam edip tmp i�erisinde int olarak sakl�yoruz.
                output += Seed[tmp]; // Output i�erisine Seed dizisinden harf eklemesi yap�yoruz.
            }
        }

        return output; // Olu�turulan seed geri d�nd�r�l�r.

    }
    public static int getTreeValue(string s)
    {
        string output = ""; // TreeValue i�in olu�turulacak de�er(10-17)
        int Control = 0; // Seed den gelen de�erinin ge�erli�i�inin kontrol�n� sa�layan de�i�ken 
        int i = 0;

        for (i = 0; i < s.Length; i++) // Seed'in L'den �nceki k�sm� s i�erisinde tutuluyor. Buradaki karakterler for d�ng�s� arac�l��� ile kontrol� sa�lan�yor.
        {
            /*
             * s'in her karakteri i�in d�n�lmesi gerekiyor bu y�zden for d�ng�s� kullan�yoruz.
             * Karakterler Seed dizisi i�erisinde aranacak. Karakter bulunduktan sonra d�ng�den ��k�labilir.
             * Bu sebeple founded de�i�keni kullan�ld�.
             * Karakter bulunursa founded true yap�larak While d�ng�s�nden ��k�l�r.
             */
            bool founded = false;
            int k = 0;
            while (!founded && k < Seed.Length)
            { // s getTreeValue dizisi
                if (s[i] == 'K') // E�er k gelirse ouputa virg�l ekler ve founded de�erini true yapar
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
          * Bulunan karakter say�s� Seed'in ilk k�sm�n�n karakter say�s� ile e�itleniyor ise
          * ��z�mleme tamamlanm�� demektir.
          * Bu de�er integera �evrilerek geri d�nd�r�l�r.
          * */
            return Convert.ToInt32(output);
        }
        else
        {// Bulunamaz ise -1 d�ner.
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
    public void CreateMap() // Canvasdaki CreateMapbtn bas�nca �al��an fonksiyon
    {
        CreateMapPanel.SetActive(true);
        CreateMapbtn.SetActive(false);            // Gameobject g�r�n�rlerini de�i�tirme
        MapSeedCodebtn.SetActive(false);
        FirstReturn.SetActive(false);
        SecondReturn.SetActive(false);
        ThirdReturn.SetActive(true);
    }
    public void CreateMapWithSeed() // Canvasdaki SeedCodebtn bas�nca �al��an fonksiyon
    {
        CreateMapbtn.SetActive(false);
        MapSeedCodebtn.SetActive(false);          // Gameobject g�r�n�rlerini de�i�tirme
        MapSeedCodePanel.SetActive(true);
        FirstReturn.SetActive(false);
        SecondReturn.SetActive(true);
        ThirdReturn.SetActive(false);

        // FirstReturn, SecondReturn, ThirdReturn;
    }
}
