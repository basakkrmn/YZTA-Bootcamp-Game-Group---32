using System.Collections.Generic;
using UnityEngine;

public class EsyaDenetleyici : MonoBehaviour
{
    [Header("Sadece Bu Býrakma Yerlerine Ýzin Verilir")]
    public List<Transform> geçerliBýrakmaYerleri = new List<Transform>();

    private Vector3 sonGecerliPozisyon;

    private void Start()
    {
        sonGecerliPozisyon = transform.position; // Ýlk konumu kaydet
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
            // Geçerli yere býrakýldý
            transform.position = enYakinYer.position;
            sonGecerliPozisyon = enYakinYer.position;

            Debug.Log("Doðru yere býrakýldý");

            // Flashback çaðrýsý buraya!
            FlashbackYoneticisi.Ornek.FlashbackGoster("Bu eþya eski bir anýyý hatýrlattý...");
        }
        else
        {
            // Geçersiz yere býrakýldý
            transform.position = sonGecerliPozisyon;
            Debug.Log("Geçersiz yere býrakýldý, geri dönüldü");
        }
    }
}
