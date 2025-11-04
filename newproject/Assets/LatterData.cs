using UnityEngine;

[CreateAssetMenu(fileName = "LetterData", menuName = "Arabic Letter")]
public class LatterData : ScriptableObject
{
    public Sprite letterSprite;   // Harfin görseli
    public AudioClip soundClip;   // Okunuþ sesi
}
