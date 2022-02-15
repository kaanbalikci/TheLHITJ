using UnityEngine;
using TMPro;
using System;

public class MapGenerate : MonoBehaviour
{

    public int forestSizex = 25; // Orman i�in x b�y�kl���
    public int forestSizez = 25; // Orman i�in z b�y�kl���
    public TextMeshProUGUI SeedTxt; // Seed Text
    int treedensity; // Di�er kod blo�undan �ekilen de�erleri tutmak i�in de�i�ken
    float treescale; // Di�er kod blo�undan �ekilen de�erleri tutmak i�in de�i�ken
    bool TimeControl = true;

    public Element[] elements; // A�a�lar i�in Elements dizisi

    float timeLeft = 5; // Paneli ortadan kald�rmak i�in tutulan zaman de�i�keni

    public GameObject Panel; // Y�klenme ekran� panel Gameobject
    public GameObject MinimapUI; // Minimap gameobject
    Vector3 offset;
    Vector3 rotation; // A�a�lar� y�nleri i�in Vector3 de�i�keni
    void Update()
    {
        if (TimeControl)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Panel.SetActive(false);        // Gameobjectlerin active durumlar�
                MinimapUI.SetActive(true);
                TimeControl = false;
            }
        }
    }
    private void Start()
    {
        SeedTxt.text = "Seed Code :" + getmapvalue.enc; // Di�er koddan ula��lan seed de�erini texte yazd�rma  

    }
    public static float getX(int seed, int max)
    {
        int random = 0;
        do
        {
            random = GenerateRandomNumber(seed, 50);
            if (random == 0)
            {
                random += 1;
            }
        } while (random == 0);


        //Console.WriteLine(" - " + random.ToString());
        seed += random;
        float returnValue = (float)random / 10;
        return returnValue;
    }

    public static float getZ(int seed, int max)
    {
        int random = 0;
        do
        {
            random = GenerateRandomNumber(seed, 50);
            if (random == 0)
            {
                random += 1;
            }
        } while (random == 0);


        //Console.WriteLine(" - " + random.ToString());
        seed += random;
        float returnValue = (float)random / 10;
        return returnValue;
    }
    private static int GenerateRandomNumber(int seed, int max)
    {
        return new System.Random(seed).Next(max);
    }

    private void Awake()
    {
        int SeedX = 1000000;
        GameObject newElement; // Newelement ad�nda gameobject olu�turuyoruz.
        treedensity = getmapvalue.newtreevalue;             //getmapvalue kodundan 2 farkl� de�eri �ekip bu alanda kullanmak i�in de�i�kenlere at�yoruz.                                                     
        treescale = (float)getmapvalue.newscalevalue;
        for (int x = 10; x < forestSizex-10; x += treedensity) //Belirlenen orman�n X b�y�kl���ne g�re for d�ng�s� olu�turulur.
        {
            for (int z = 10; z < forestSizez-10; z += treedensity) //Belirlenen orman�n Z b�y�kl���ne g�re for d�ng�s� olu�turulur.
            {
                int treeIndex = 0;
                float s1 = getX(SeedX, 50);
                SeedX += Convert.ToInt32(s1 * 10);

                float s2 = getZ(SeedX, 50);
                SeedX += Convert.ToInt32(s2 * 10);
                offset = new Vector3(s1, 0f, s2);
                // Ekledi�imiz a�a�lar�n uzunlu�unu dola�mak i�in for d�ng�s� olu�turuyoruz.
                for (int i = 0; i < elements.Length;)
                {

                    Vector3 position = new Vector3(x, 25f, z); // A�a�lar�n pozisyonlar� i�in vector3 de�i�ken olu�turuyoruz.
                    Vector3 scale = Vector3.one * treescale; // A�a�lar�n y�kseklikleri i�in vector3 i�erisindeki de�erli treescale ile �arp�p de�i�ken olu�turuyoruz.
                    // Get the current element.
                    Element element = elements[i];

                    //offset = new Vector3(Random.Range(0f, 5f), 0f, Random.Range(0f, 5f));

                    if (z >= 0 && z < 300)
                    {
                        treeIndex = SeedX % 3;
                        rotation = new Vector3(UnityEngine.Random.Range(0, 5f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 5f)); // Rotation i�erisine random de�erler ata.
                        newElement = Instantiate(element.prefabs[treeIndex]); // 0 index inde bulunan a�ac� olu�tur.
                        newElement.transform.SetParent(transform); // Alt nesne olarak sahneye ekle
                        newElement.transform.position = position + offset; // Nesnenin posisyonunu ekle.

                        newElement.transform.eulerAngles = rotation; // Random gelen rotation de�erlerini ekle.
                        newElement.transform.localScale = scale;  // B�y�kl���n� ekle
                    }
                    else if (z >= 300 && z < 600)
                    {
                        treeIndex = (SeedX % 3)+3;
                        rotation = new Vector3(UnityEngine.Random.Range(0, 5f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 5f)); // Rotation i�erisine random de�erler ata.
                        newElement = Instantiate(element.prefabs[treeIndex]); // 0 index inde bulunan a�ac� olu�tur.
                        newElement.transform.SetParent(transform); // Alt nesne olarak sahneye ekle
                        newElement.transform.position = position + offset; // Nesnenin posisyonunu ekle.

                        newElement.transform.eulerAngles = rotation; // Random gelen rotation de�erlerini ekle.
                        newElement.transform.localScale = scale ;  // B�y�kl���n� ekle
                        if (treeIndex == 3)
                        {
                            newElement.transform.localScale = scale * 2;
                        }
                        else if (treeIndex == 4 || treeIndex == 5)
                        {
                            newElement.transform.localScale = scale;
                        }
                    }
                    else if (z >= 600 && z <= 900)
                    {
                        treeIndex = (SeedX % 3)+6;
                        rotation = new Vector3(UnityEngine.Random.Range(0, 5f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 5f)); // Rotation i�erisine random de�erler ata.
                        newElement = Instantiate(element.prefabs[treeIndex]); // 0 index inde bulunan a�ac� olu�tur.
                        newElement.transform.SetParent(transform); // Alt nesne olarak sahneye ekle
                        newElement.transform.position = position + offset; // Nesnenin posisyonunu ekle.

                        newElement.transform.eulerAngles = rotation; // Random gelen rotation de�erlerini ekle.
                        if (treeIndex == 6)
                        {
                            newElement.transform.localScale = scale * 2;
                        }
                        else if (treeIndex==7 || treeIndex==8)
                        {
                            newElement.transform.localScale = scale;
                        }
                        // B�y�kl���n� ekle
                    }
                    break;
                }
            }
        }
    }
}

[System.Serializable]
public class Element
{

    public string name; // Element class i�erisinde a�a�lar�n genel ismi
    public GameObject[] prefabs; // �stenilen a�a�lar� Gameobjectlerinin tutulmas�


}