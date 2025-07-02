using UnityEngine;
using TMPro;
using System.Collections;

public class FlashbackYoneticisi : MonoBehaviour
{
    public static FlashbackYoneticisi Ornek;

    [Header("Flashback UI Elemanlarý")]
    public GameObject flashbackPanel;
    public TMP_Text flashbackYazi;

    private void Awake()
    {
        // Singleton örneði
        if (Ornek == null)
        {
            Ornek = this;
        }
        else
        {
            Destroy(gameObject);
        }

        flashbackPanel.SetActive(false); // Panel baþlangýçta gizli
    }

    /// <summary>
    /// Verilen metni flashback panelinde gösterir.
    /// </summary>
    public void FlashbackGoster(string mesaj)
    {
        StartCoroutine(FlashbackAkisi(mesaj));
    }

    /// <summary>
    /// Paneli açar, mesajý yazar, 3 saniye sonra kapatýr.
    /// </summary>
    private IEnumerator FlashbackAkisi(string mesaj)
    {
        flashbackPanel.SetActive(true);
        flashbackYazi.text = mesaj;

        yield return new WaitForSeconds(3f);

        flashbackPanel.SetActive(false);
    }
}
