using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)] // Komut dosyasý oluþturur.
public class LightingPreset : ScriptableObject
{
    public Gradient DirectionalColor;  // Scriptables içerisine renk ayarlarýný tutan deðiþken açtýk.
}