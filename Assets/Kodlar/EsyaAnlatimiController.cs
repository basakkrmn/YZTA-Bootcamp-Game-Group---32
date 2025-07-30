using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EsyaAnlatimiController : MonoBehaviour
{
    [System.Serializable]
    public class EsyaHikayesi
    {
        public AudioClip clip;
        [TextArea]
        public string subtitle;
        public Sprite gorsel; // Her eşya için görsel
    }

    public AudioSource audioSource;
    public TextMeshProUGUI altyaziText;
    public GameObject devamButonu;
    public Image gorselAlani; // Paneldeki Image objesi
    public EsyaHikayesi[] hikayeler;

    public void Oynat(int index)
    {
        if (index >= 0 && index < hikayeler.Length)
        {
            StartCoroutine(HikayeOynat(hikayeler[index]));
        }
    }

    IEnumerator HikayeOynat(EsyaHikayesi entry)
    {
        devamButonu.SetActive(false);

        if (entry.gorsel != null)
        {
            gorselAlani.sprite = entry.gorsel;
            gorselAlani.gameObject.SetActive(true);
        }
        else
        {
            gorselAlani.gameObject.SetActive(false);
        }

        if (entry.clip != null)
        {
            audioSource.clip = entry.clip;
            audioSource.Play();
        }

        yield return StartCoroutine(TypewriterEffect(entry.subtitle));

        devamButonu.SetActive(true);
    }

    IEnumerator TypewriterEffect(string metin)
    {
        altyaziText.text = "";
        foreach (char harf in metin)
        {
            altyaziText.text += harf;
            yield return new WaitForSeconds(0.035f);
        }
    }
}
