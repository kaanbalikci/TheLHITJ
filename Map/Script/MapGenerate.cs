using UnityEngine;
using TMPro;
using System;

public class MapGenerate : MonoBehaviour
{

    public int forestSizex = 25; // Orman için x büyüklüðü
    public int forestSizez = 25; // Orman için z büyüklüðü
    public TextMeshProUGUI SeedTxt; // Seed Text
    int treedensity; // Diðer kod bloðundan çekilen deðerleri tutmak için deðiþken
    float treescale; // Diðer kod bloðundan çekilen deðerleri tutmak için deðiþken
    bool TimeControl = true;

    public Element[] elements; // Aðaçlar için Elements dizisi

    float timeLeft = 5; // Paneli ortadan kaldýrmak için tutulan zaman deðiþkeni

    public GameObject Panel; // Yüklenme ekraný panel Gameobject
    public GameObject MinimapUI; // Minimap gameobject
    Vector3 offset;
    Vector3 rotation; // Aðaçlarý yönleri için Vector3 deðiþkeni
    void Update()
    {
        if (TimeControl)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Panel.SetActive(false);        // Gameobjectlerin active durumlarý
                MinimapUI.SetActive(true);
                TimeControl = false;
            }
        }
    }
    private void Start()
    {
        SeedTxt.text = "Seed Code :" + getmapvalue.enc; // Diðer koddan ulaþýlan seed deðerini texte yazdýrma  

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
        GameObject newElement; // Newelement adýnda gameobject oluþturuyoruz.
        treedensity = getmapvalue.newtreevalue;             //getmapvalue kodundan 2 farklý deðeri çekip bu alanda kullanmak için deðiþkenlere atýyoruz.                                                     
        treescale = (float)getmapvalue.newscalevalue;
        for (int x = 10; x < forestSizex-10; x += treedensity) //Belirlenen ormanýn X büyüklüðüne göre for döngüsü oluþturulur.
        {
            for (int z = 10; z < forestSizez-10; z += treedensity) //Belirlenen ormanýn Z büyüklüðüne göre for döngüsü oluþturulur.
            {
                int treeIndex = 0;
                float s1 = getX(SeedX, 50);
                SeedX += Convert.ToInt32(s1 * 10);

                float s2 = getZ(SeedX, 50);
                SeedX += Convert.ToInt32(s2 * 10);
                offset = new Vector3(s1, 0f, s2);
                // Eklediðimiz aðaçlarýn uzunluðunu dolaþmak için for döngüsü oluþturuyoruz.
                for (int i = 0; i < elements.Length;)
                {

                    Vector3 position = new Vector3(x, 25f, z); // Aðaçlarýn pozisyonlarý için vector3 deðiþken oluþturuyoruz.
                    Vector3 scale = Vector3.one * treescale; // Aðaçlarýn yükseklikleri için vector3 içerisindeki deðerli treescale ile çarpýp deðiþken oluþturuyoruz.
                    // Get the current element.
                    Element element = elements[i];

                    //offset = new Vector3(Random.Range(0f, 5f), 0f, Random.Range(0f, 5f));

                    if (z >= 0 && z < 300)
                    {
                        treeIndex = SeedX % 3;
                        rotation = new Vector3(UnityEngine.Random.Range(0, 5f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 5f)); // Rotation içerisine random deðerler ata.
                        newElement = Instantiate(element.prefabs[treeIndex]); // 0 index inde bulunan aðacý oluþtur.
                        newElement.transform.SetParent(transform); // Alt nesne olarak sahneye ekle
                        newElement.transform.position = position + offset; // Nesnenin posisyonunu ekle.

                        newElement.transform.eulerAngles = rotation; // Random gelen rotation deðerlerini ekle.
                        newElement.transform.localScale = scale;  // Büyüklüðünü ekle
                    }
                    else if (z >= 300 && z < 600)
                    {
                        treeIndex = (SeedX % 3)+3;
                        rotation = new Vector3(UnityEngine.Random.Range(0, 5f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 5f)); // Rotation içerisine random deðerler ata.
                        newElement = Instantiate(element.prefabs[treeIndex]); // 0 index inde bulunan aðacý oluþtur.
                        newElement.transform.SetParent(transform); // Alt nesne olarak sahneye ekle
                        newElement.transform.position = position + offset; // Nesnenin posisyonunu ekle.

                        newElement.transform.eulerAngles = rotation; // Random gelen rotation deðerlerini ekle.
                        newElement.transform.localScale = scale ;  // Büyüklüðünü ekle
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
                        rotation = new Vector3(UnityEngine.Random.Range(0, 5f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 5f)); // Rotation içerisine random deðerler ata.
                        newElement = Instantiate(element.prefabs[treeIndex]); // 0 index inde bulunan aðacý oluþtur.
                        newElement.transform.SetParent(transform); // Alt nesne olarak sahneye ekle
                        newElement.transform.position = position + offset; // Nesnenin posisyonunu ekle.

                        newElement.transform.eulerAngles = rotation; // Random gelen rotation deðerlerini ekle.
                        if (treeIndex == 6)
                        {
                            newElement.transform.localScale = scale * 2;
                        }
                        else if (treeIndex==7 || treeIndex==8)
                        {
                            newElement.transform.localScale = scale;
                        }
                        // Büyüklüðünü ekle
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

    public string name; // Element class içerisinde aðaçlarýn genel ismi
    public GameObject[] prefabs; // Ýstenilen aðaçlarý Gameobjectlerinin tutulmasý


}