using UnityEngine;
using TMPro;
using System.Collections;

public class FlashbackYoneticisi : MonoBehaviour
{
    public static FlashbackYoneticisi Ornek;

    [Header("Flashback UI Elemanlarý")]
    public GameObject flashbackPanel;
    public TMP_Text flashbackYazi;

    public bool flashbackAktif { get; private set; }

    private void Awake()
    {
        if (Ornek == null)
        {
            Ornek = this;
        }
        else
        {
            Destroy(gameObject);
        }

        flashbackPanel.SetActive(false);
        flashbackAktif = false;
    }

    public void FlashbackGoster(string mesaj)
    {
        StartCoroutine(FlashbackAkisi(mesaj));
    }

    private IEnumerator FlashbackAkisi(string mesaj)
    {
        flashbackAktif = true;
        flashbackPanel.SetActive(true);
        flashbackYazi.text = mesaj;

        yield return new WaitForSeconds(3f);

        flashbackPanel.SetActive(false);
        flashbackAktif = false;
    }
}
