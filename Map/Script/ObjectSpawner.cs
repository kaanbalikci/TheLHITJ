using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    int WoodAreaMaxSizex = 300; 
    int WoodAreaMaxSizez = 80;
    int MushRoomAreaMaxSizex = 500;
    int MushRoomAreaMaxSizez = 600;
    int BarrelAreaMaxSizex = 500;
    int BarrelAreaMaxSizez = 900;
    public GameObject[] Objects;
    GameObject newElement;
    Vector3 rotation;
    float woodScale = 0.5f;
    
    int woodDensity = 10;
    int MushRoomDensity = 17;
    // Index 0 => Wood(log)
    // Index 1 => Mushroom
    // Index 2 => ToxicMushroom
    // Index 3 => Barrel 1 
    // Index 4 => Barrel 2 
    // Index 5 => Barrel 3
    // Index 6 => Barrel 4
    void Start()
    {

    }
    private void Awake()
    {
        wood();
        Mushroom();
    }
    void Update()
    {
    }
    void wood()
    {
        for (int x = 200; x < WoodAreaMaxSizex; x += woodDensity)
        {
            for (int z = 10; z < WoodAreaMaxSizez; z += woodDensity)
            {
                Vector3 position = new Vector3(x, 20f, z);
                Vector3 scale = Vector3.one * woodScale;
                Vector3 offset = new Vector3(Random.Range(2f, 7f), 0f, Random.Range(2f, 7f));
                Vector3 rotation = new Vector3(90f, Random.Range(0, 360f), Random.Range(0f, 360f));
                newElement = Instantiate(Objects[0]); // 0 index inde bulunan Wood oluþtur.
                newElement.transform.SetParent(transform); // Alt nesne olarak sahneye ekle
                newElement.transform.position = position+offset; // Nesnenin posisyonunu ekle.

                newElement.transform.eulerAngles = rotation; // Random gelen rotation deðerlerini ekle.
                newElement.transform.localScale = scale;  // Büyüklüðünü ekle
            }
        }
    }
    void Mushroom()
    {
        for (int x = 12; x < MushRoomAreaMaxSizex-10; x += MushRoomDensity)
        {
            for (int z = 12; z < MushRoomAreaMaxSizez-10; z += MushRoomDensity)
            {
                int Mushroom = Random.Range(1, 3);
                Vector3 position = new Vector3(x, 25f, z);
                //Vector3 scale = Vector3.one;
                Vector3 scale = new Vector3(0.5f, 0.5f, 0.5f);
                Vector3 offset = new Vector3(Random.Range(2f, 7f), 0f, Random.Range(2f, 7f));
                Vector3 rotation = new Vector3(0f, Random.Range(0, 360f), 0f);
                newElement = Instantiate(Objects[Mushroom]); // 1-2 index inde bulunan Mushroom ve ToxicMushroom oluþtur.
                newElement.transform.SetParent(transform); // Alt nesne olarak sahneye ekle
                newElement.transform.position = position + offset; // Nesnenin posisyonunu ekle.

                newElement.transform.eulerAngles = rotation; // Random gelen rotation deðerlerini ekle.
                newElement.transform.localScale = scale;  // Büyüklüðünü ekle
            }
        }
    }
}
