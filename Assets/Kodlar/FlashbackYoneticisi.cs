using UnityEngine;
using TMPro;
using System.Collections;

public class FlashbackYoneticisi : MonoBehaviour
{
    public static FlashbackYoneticisi Ornek;

    public GameObject flashbackPanel;
    public TMP_Text flashbackYazi;

    private void Awake()
    {
        Ornek = this;
        flashbackPanel.SetActive(false); // Baþlangýçta panel kapalý
    }

    public void FlashbackGoster(string mesaj)
    {
        StartCoroutine(FlashbackAkisi(mesaj));
    }

    private IEnumerator FlashbackAkisi(string mesaj)
    {
        flashbackPanel.SetActive(true);
        flashbackYazi.text = mesaj;

        yield return new WaitForSeconds(3f);

        flashbackPanel.SetActive(false);
    }
}
