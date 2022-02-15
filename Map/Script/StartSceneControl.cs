using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneControl : MonoBehaviour
{
    public GameObject StartPanel, SeedPanel, FirstReturn, SecondReturn, ThirdReturn;
    public GameObject CreateMapBtn, SeedCodeBtn, SeedCodePanel, CreteMapPanel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartBtnFunction() // Canvasdaki StartBtn basýnca çalýþan fonksiyon
    {
        StartPanel.SetActive(false);         // Gameobject görünürlerini deðiþtirme
        SeedPanel.SetActive(true);
        SecondReturn.SetActive(false);
        ThirdReturn.SetActive(false);
    }
    public void QuitBtnFunction() // Canvasdaki StartBtn basýnca çalýþan fonksiyon
    {
        Application.Quit();
    }
    public void FirstReturnBtnFunction() // Canvasdaki StartBtn basýnca çalýþan fonksiyon
    {
        StartPanel.SetActive(true);         // Gameobject görünürlerini deðiþtirme
        SeedPanel.SetActive(false);
    }
    public void SecondReturnBtnFunction() // Canvasdaki StartBtn basýnca çalýþan fonksiyon
    {
        CreateMapBtn.SetActive(true);         // Gameobject görünürlerini deðiþtirme
        SeedCodeBtn.SetActive(true);
        SeedCodePanel.SetActive(false);
        FirstReturn.SetActive(true);
        SecondReturn.SetActive(false);
        ThirdReturn.SetActive(false);
    }
    public void ThirdReturnBtnFunction() // Canvasdaki StartBtn basýnca çalýþan fonksiyon
    {
        CreateMapBtn.SetActive(true);         // Gameobject görünürlerini deðiþtirme
        SeedCodeBtn.SetActive(true);
        CreteMapPanel.SetActive(false);
        FirstReturn.SetActive(true);
        SecondReturn.SetActive(false);
        ThirdReturn.SetActive(false);
    }
}
