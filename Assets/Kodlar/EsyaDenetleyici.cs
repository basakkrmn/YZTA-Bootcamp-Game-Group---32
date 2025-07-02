using System.Collections.Generic;
using UnityEngine;

public class EsyaDenetleyici : MonoBehaviour
{
    [Header("Sadece Bu Býrakma Yerlerine Ýzin Verilir")]
    public List<Transform> geçerliBýrakmaYerleri = new List<Transform>();

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
        // Týklanma anýnda flashback göster
        if (veri != null)
        {
            FlashbackYoneticisi.Ornek.FlashbackGoster(veri.flashbackMetni);
        }
    }

    private void OnMouseUp()
    {
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
            Debug.Log("Geçersiz yere býrakýldý, geri dönüldü");
        }
    }
}
