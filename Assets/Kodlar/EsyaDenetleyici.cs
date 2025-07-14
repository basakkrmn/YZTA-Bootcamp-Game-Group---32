using System.Collections.Generic;
using UnityEngine;

public class EsyaDenetleyici : MonoBehaviour
{
    [Header("Geçerli Býrakma Noktalarý")]
    public List<Transform> geçerliBýrakmaYerleri;

    private Vector3 sonGecerliPozisyon;
    private EsyaVerisi veri;

    private void Start()
    {
        sonGecerliPozisyon = transform.position;
        veri = GetComponent<EsyaVerisi>();

        if (veri == null)
        {
            Debug.LogWarning("EsyaVerisi scripti eksik!");
        }
    }

    private void OnMouseDown()
    {
        if (veri == null || FlashbackYoneticisi.Ornek == null)
            return;

        // Flashback daha önce oynatýlmadýysa, þimdi oynat
        if (!veri.flashbackOynatildi)
        {
            veri.flashbackOynatildi = true;
            FlashbackYoneticisi.Ornek.FlashbackGoster(veri.flashbackMetni);
        }
    }


    private void OnMouseUp()
    {
        if (FlashbackYoneticisi.Ornek != null && FlashbackYoneticisi.Ornek.flashbackAktif)
            return;

        float minimumMesafe = 0.8f;
        Transform enYakinYer = null;

        foreach (Transform nokta in geçerliBýrakmaYerleri)
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
            Debug.Log("Doðru yere býrakýldý");
        }
        else
        {
            transform.position = sonGecerliPozisyon;
            Debug.Log("Geçersiz yere býrakýldý");
        }
    }
}
