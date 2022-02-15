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
    public void StartBtnFunction() // Canvasdaki StartBtn bas�nca �al��an fonksiyon
    {
        StartPanel.SetActive(false);         // Gameobject g�r�n�rlerini de�i�tirme
        SeedPanel.SetActive(true);
        SecondReturn.SetActive(false);
        ThirdReturn.SetActive(false);
    }
    public void QuitBtnFunction() // Canvasdaki StartBtn bas�nca �al��an fonksiyon
    {
        Application.Quit();
    }
    public void FirstReturnBtnFunction() // Canvasdaki StartBtn bas�nca �al��an fonksiyon
    {
        StartPanel.SetActive(true);         // Gameobject g�r�n�rlerini de�i�tirme
        SeedPanel.SetActive(false);
    }
    public void SecondReturnBtnFunction() // Canvasdaki StartBtn bas�nca �al��an fonksiyon
    {
        CreateMapBtn.SetActive(true);         // Gameobject g�r�n�rlerini de�i�tirme
        SeedCodeBtn.SetActive(true);
        SeedCodePanel.SetActive(false);
        FirstReturn.SetActive(true);
        SecondReturn.SetActive(false);
        ThirdReturn.SetActive(false);
    }
    public void ThirdReturnBtnFunction() // Canvasdaki StartBtn bas�nca �al��an fonksiyon
    {
        CreateMapBtn.SetActive(true);         // Gameobject g�r�n�rlerini de�i�tirme
        SeedCodeBtn.SetActive(true);
        CreteMapPanel.SetActive(false);
        FirstReturn.SetActive(true);
        SecondReturn.SetActive(false);
        ThirdReturn.SetActive(false);
    }
}
