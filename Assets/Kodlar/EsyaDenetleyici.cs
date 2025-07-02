using System.Collections.Generic;
using UnityEngine;

public class EsyaDenetleyici : MonoBehaviour
{
    [Header("Sadece Bu B�rakma Yerlerine �zin Verilir")]
    public List<Transform> ge�erliB�rakmaYerleri = new List<Transform>();

    private Vector3 sonGecerliPozisyon;
    private EsyaVerisi veri;

    private void Start()
    {
        sonGecerliPozisyon = transform.position;
        veri = GetComponent<EsyaVerisi>();

        if (veri == null)
        {
            Debug.LogWarning("EsyaVerisi scripti bu objede eksik!");
        }
    }

    private void OnMouseDown()
    {
        // T�klanma an�nda flashback g�ster
        if (veri != null)
        {
            FlashbackYoneticisi.Ornek.FlashbackGoster(veri.flashbackMetni);
        }
    }

    private void OnMouseUp()
    {
        float minimumMesafe = 0.8f;
        Transform enYakinYer = null;

        foreach (Transform nokta in ge�erliB�rakmaYerleri)
        {
            float mesafe = Vector3.Distance(transform.position, nokta.position);
            if (mesafe < minimumMesafe)
            {
                minimumMesafe = mesafe;
                enYakinYer = nokta;
            }
        }

        if (enYakinYer != null)
        {
            transform.position = enYakinYer.position;
            sonGecerliPozisyon = enYakinYer.position;
            Debug.Log("Do�ru yere b�rak�ld�");
        }
        else
        {
            transform.position = sonGecerliPozisyon;
            Debug.Log("Ge�ersiz yere b�rak�ld�, geri d�n�ld�");
        }
    }
}
