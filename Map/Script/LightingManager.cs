using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Referanslar
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    public bool midnight; // Gece boolen kontrolü

    public static float day = 1; // Kaçýncý günde olduðumuzun sayacý
    bool controller = false;

    [SerializeField, Range(0, 24)] public static float TimeOfDay = 12; // 0-24 arasý günün saatleri
    public GameObject dayUI; // Gün sayacý paneli gameobjecti


    //public Text dayText;
    public TextMeshProUGUI dayText; // Gün döngüsü texti

    public float sunrise; //Gün doðumu için belirlenen deðer
    public float sunriseExit; // Gün batýmý 
    public float midnightStart; // Gece baþlangýç
    public float midnightEnd; // Gece bitiþ


    public int dayminute; // Günün kaç dakika olacaðýný belirleme
    float timefactor = 2.5f; // 1 gün için dakika belirlemede kullanýlan kat sayý
    public Animator DayAnim; // Gün sayacý animasyonu

    public static LightingManager LM;

    private void Awake()
    {
        LM = this;
    }


    private void Update()
    {
        if (Application.isPlaying)
        {
            if (((int)TimeOfDay) == sunrise) // Günün saati == sunrise ise 
            {
                DayAnim.SetBool("textcycle", true); // DayAnim animasyonu içerisindeki bool deðerini true yap
            }
            else if (((int)TimeOfDay) == sunriseExit) // Günün saati == sunriseExit ise
            {
                DayAnim.SetBool("textcycle", false); //DayAnim animasyonu içerisindeki bool deðerini false yap
            }
            if (((int)TimeOfDay) == midnightStart) // Günün saati gece baþlangýç saatine eþit ise
            {
                midnight = true; // Gece boolenýný true yap


            }
            else if (((int)TimeOfDay) == midnightEnd) //Günün saati gece bitiþ saatine eþit ise
            {
                midnight = false; // Gece boolenýný false yap

            }
        }
       


        if (Preset == null)
            return;

        if (Application.isPlaying) // Sadece oyun baþlatýldýðýnda çalýþmasýný istiyoruz.
        {

            TimeOfDay += Time.deltaTime / timefactor / dayminute; // Gün döngüsü normal tamamlanmasý 24 saniye * 25 = 600 saniye
            if (TimeOfDay >= 24) // Gün 24 e ulaþtýðýnda veya geçtiðinde sayaç artar.
            {
                day++;
            }
            TimeOfDay %= 24; // Her zaman 0-24 arasýnda olmasýný saðlamak için.

            UpdateLighting(TimeOfDay / 24f); //Fonksiyondan gelen deðere göre fonksiyonu çalýþtýrýyoruz.


        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
        dayText.text = "Day  " + day.ToString(); // Day Texti içerisine kaçýncý günde olduðumuzu yazýyoruz.
    }


    private void UpdateLighting(float timePercent) // Günün saatine göre aydýnlatmayý deðiþtermek için foknsiyon oluþturulur.

    {
        if (Application.isPlaying)
        {
            if (DirectionalLight != null)
            {
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent); // Iþýk kaynaðýmýzý zaman deðiþkenine göre deðiþtiriyoruz.

                DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0)); // Iþýðýn açýsýný zamana baðlý olarak deðiþtiriyoruz.
            }
        }
    }

    //Directional Light ayarlanmadýysa ayarlama iþlemlerini yapmaya çalýþ
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Aydýnlatma sekmesinden güneþi bulma iþlemi
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun; // Güneþi bulduktan sonra DirectionalLight içerisine atama yap.
        }

        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>(); // Sahnede Light gameobjectlerini diziye ata
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional) // Türü Directional ise 
                {
                    DirectionalLight = light; // Light'a eþitle
                    return;
                }
            }
        }
    }
}