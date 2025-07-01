using System.Collections.Generic;
using UnityEngine;

public class EsyaDenetleyici : MonoBehaviour
{
    [Header("Sadece Bu B�rakma Yerlerine �zin Verilir")]
    public List<Transform> ge�erliB�rakmaYerleri = new List<Transform>();

    private Vector3 sonGecerliPozisyon;

    private void Start()
    {
        sonGecerliPozisyon = transform.position; // �lk konumu kaydet
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
            // Ge�erli yere b�rak�ld�
            transform.position = enYakinYer.position;
            sonGecerliPozisyon = enYakinYer.position;

            Debug.Log("Do�ru yere b�rak�ld�");

            // Flashback �a�r�s� buraya!
            FlashbackYoneticisi.Ornek.FlashbackGoster("Bu e�ya eski bir an�y� hat�rlatt�...");
        }
        else
        {
            // Ge�ersiz yere b�rak�ld�
            transform.position = sonGecerliPozisyon;
            Debug.Log("Ge�ersiz yere b�rak�ld�, geri d�n�ld�");
        }
    }
}
