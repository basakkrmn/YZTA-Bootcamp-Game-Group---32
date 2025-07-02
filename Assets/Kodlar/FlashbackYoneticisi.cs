using UnityEngine;
using TMPro;
using System.Collections;

public class FlashbackYoneticisi : MonoBehaviour
{
    public static FlashbackYoneticisi Ornek;

    [Header("Flashback UI Elemanlar�")]
    public GameObject flashbackPanel;
    public TMP_Text flashbackYazi;

    private void Awake()
    {
        // Singleton �rne�i
        if (Ornek == null)
        {
            Ornek = this;
        }
        else
        {
            Destroy(gameObject);
        }

        flashbackPanel.SetActive(false); // Panel ba�lang��ta gizli
    }

    /// <summary>
    /// Verilen metni flashback panelinde g�sterir.
    /// </summary>
    public void FlashbackGoster(string mesaj)
    {
        StartCoroutine(FlashbackAkisi(mesaj));
    }

    /// <summary>
    /// Paneli a�ar, mesaj� yazar, 3 saniye sonra kapat�r.
    /// </summary>
    private IEnumerator FlashbackAkisi(string mesaj)
    {
        flashbackPanel.SetActive(true);
        flashbackYazi.text = mesaj;

        yield return new WaitForSeconds(3f);

        flashbackPanel.SetActive(false);
    }
}
