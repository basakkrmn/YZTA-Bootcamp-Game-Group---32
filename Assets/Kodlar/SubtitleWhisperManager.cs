using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleWhisperManager : MonoBehaviour
{
    [System.Serializable]
    public class WhisperEntry
    {
        public AudioClip clip;
        [TextArea]
        public string subtitle;
    }

    public AudioSource audioSource;
    public TextMeshProUGUI subtitleText;
    public WhisperEntry[] whisperSequence;
    public float delayBetweenClips = 1f;

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        foreach (var entry in whisperSequence)
        {
            audioSource.clip = entry.clip;
            audioSource.Play();
            subtitleText.text = entry.subtitle;
            yield return new WaitForSeconds(entry.clip.length + delayBetweenClips);
        }

        subtitleText.text = ""; // Sonunda temizle
    }
}
