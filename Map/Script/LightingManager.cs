using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Referanslar
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    public bool midnight; // Gece boolen kontrol�

    public static float day = 1; // Ka��nc� g�nde oldu�umuzun sayac�
    bool controller = false;

    [SerializeField, Range(0, 24)] public static float TimeOfDay = 12; // 0-24 aras� g�n�n saatleri
    public GameObject dayUI; // G�n sayac� paneli gameobjecti


    //public Text dayText;
    public TextMeshProUGUI dayText; // G�n d�ng�s� texti

    public float sunrise; //G�n do�umu i�in belirlenen de�er
    public float sunriseExit; // G�n bat�m� 
    public float midnightStart; // Gece ba�lang��
    public float midnightEnd; // Gece biti�


    public int dayminute; // G�n�n ka� dakika olaca��n� belirleme
    float timefactor = 2.5f; // 1 g�n i�in dakika belirlemede kullan�lan kat say�
    public Animator DayAnim; // G�n sayac� animasyonu

    public static LightingManager LM;

    private void Awake()
    {
        LM = this;
    }


    private void Update()
    {
        if (Application.isPlaying)
        {
            if (((int)TimeOfDay) == sunrise) // G�n�n saati == sunrise ise 
            {
                DayAnim.SetBool("textcycle", true); // DayAnim animasyonu i�erisindeki bool de�erini true yap
            }
            else if (((int)TimeOfDay) == sunriseExit) // G�n�n saati == sunriseExit ise
            {
                DayAnim.SetBool("textcycle", false); //DayAnim animasyonu i�erisindeki bool de�erini false yap
            }
            if (((int)TimeOfDay) == midnightStart) // G�n�n saati gece ba�lang�� saatine e�it ise
            {
                midnight = true; // Gece boolen�n� true yap


            }
            else if (((int)TimeOfDay) == midnightEnd) //G�n�n saati gece biti� saatine e�it ise
            {
                midnight = false; // Gece boolen�n� false yap

            }
        }
       


        if (Preset == null)
            return;

        if (Application.isPlaying) // Sadece oyun ba�lat�ld���nda �al��mas�n� istiyoruz.
        {

            TimeOfDay += Time.deltaTime / timefactor / dayminute; // G�n d�ng�s� normal tamamlanmas� 24 saniye * 25 = 600 saniye
            if (TimeOfDay >= 24) // G�n 24 e ula�t���nda veya ge�ti�inde saya� artar.
            {
                day++;
            }
            TimeOfDay %= 24; // Her zaman 0-24 aras�nda olmas�n� sa�lamak i�in.

            UpdateLighting(TimeOfDay / 24f); //Fonksiyondan gelen de�ere g�re fonksiyonu �al��t�r�yoruz.


        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
        dayText.text = "Day  " + day.ToString(); // Day Texti i�erisine ka��nc� g�nde oldu�umuzu yaz�yoruz.
    }


    private void UpdateLighting(float timePercent) // G�n�n saatine g�re ayd�nlatmay� de�i�termek i�in foknsiyon olu�turulur.

    {
        if (Application.isPlaying)
        {
            if (DirectionalLight != null)
            {
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent); // I��k kayna��m�z� zaman de�i�kenine g�re de�i�tiriyoruz.

                DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0)); // I����n a��s�n� zamana ba�l� olarak de�i�tiriyoruz.
            }
        }
    }

    //Directional Light ayarlanmad�ysa ayarlama i�lemlerini yapmaya �al��
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Ayd�nlatma sekmesinden g�ne�i bulma i�lemi
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun; // G�ne�i bulduktan sonra DirectionalLight i�erisine atama yap.
        }

        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>(); // Sahnede Light gameobjectlerini diziye ata
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional) // T�r� Directional ise 
                {
                    DirectionalLight = light; // Light'a e�itle
                    return;
                }
            }
        }
    }
}