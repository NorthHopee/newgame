using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static LatterData;

public class LatterManager : MonoBehaviour
{
    [Header("References")]
    public GameObject[] letters;   // Harf GameObject dizisi
    public Button playButton;
    public AudioSource audioSource;

    [Header("Settings")]
    public AudioClip[] letterSounds; // Her harfin sesi
    public float nextLetterDelay = 1f;

    private int currentIndex = 0;
    private bool isPlaying = false;

    private void Start()
    {
        // Baþta tüm harfleri kapat, sadece ilki açýk olsun
        for (int i = 0; i < letters.Length; i++)
            letters[i].SetActive(i == 0);

        playButton.onClick.AddListener(() =>
        {
            if (!isPlaying)
                StartCoroutine(PlayLetterSound());
        });
    }

    private IEnumerator PlayLetterSound()
    {
        isPlaying = true;

        // Þu anki harfin sesi
        AudioClip clip = letterSounds[currentIndex];
        audioSource.PlayOneShot(clip);

        // Sesin bitmesini bekle
        yield return new WaitForSeconds(clip.length);

        // Ek bekleme
        yield return new WaitForSeconds(nextLetterDelay);

        // Þimdiki harfi kapat
        letters[currentIndex].SetActive(false);

        // Sýradaki harfe geç
        currentIndex++;
        if (currentIndex >= letters.Length)
            currentIndex = 0;  // döngü

        // Yeni harfi aç
        letters[currentIndex].SetActive(true);

        isPlaying = false;
    }
}
