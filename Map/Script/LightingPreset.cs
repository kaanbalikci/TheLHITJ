using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)] // Komut dosyas� olu�turur.
public class LightingPreset : ScriptableObject
{
    public Gradient DirectionalColor;  // Scriptables i�erisine renk ayarlar�n� tutan de�i�ken a�t�k.
}