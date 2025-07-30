using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class EsyaBilgisi
{
    public string isim;
    public GameObject esyaObjesi;
    public string altyazi;
    public AudioClip ses;
}

public class PlacementFlowManager : MonoBehaviour
{
    [Header("Intro")]
    [TextArea] public string[] girisMetinleri;
    public AudioClip[] girisSesleri;
    public float harfGecikmesi = 0.03f;

    [Header("Baðlantýlar")]
    public TMP_Text altyaziText;
    public AudioSource sesKaynagi;
    public GameObject kutuObjesi;
    public List<EsyaBilgisi> esyaListesi;
    public Transform[] yerlestirmeNoktalari;

    int esyaIndex = 0;
    bool kutuAktif = false;
    GameObject aktifEsya;

    void Start()
    {
        kutuAktif = false;
        kutuObjesi.SetActive(true);
        foreach (var esya in esyaListesi)
            esya.esyaObjesi.SetActive(false);

        StartCoroutine(IntroAkisi());
    }

    IEnumerator IntroAkisi()
    {
        for (int i = 0; i < girisMetinleri.Length; i++)
        {
            yield return StartCoroutine(YaziYazdir(girisMetinleri[i]));

            if (i < girisSesleri.Length && girisSesleri[i] != null)
            {
                sesKaynagi.clip = girisSesleri[i];
                sesKaynagi.Play();
                yield return new WaitWhile(() => sesKaynagi.isPlaying);
            }

            yield return new WaitForSeconds(0.5f);
        }

        altyaziText.text = "";
        kutuAktif = true;
    }

    IEnumerator YaziYazdir(string metin)
    {
        altyaziText.text = "";
        foreach (char harf in metin)
        {
            altyaziText.text += harf;
            yield return new WaitForSeconds(harfGecikmesi);
        }
    }

    public void KutuyaTiklandi()
    {
        if (!kutuAktif || esyaIndex >= esyaListesi.Count || aktifEsya != null) return;

        kutuAktif = false;

        var esya = esyaListesi[esyaIndex];
        aktifEsya = esya.esyaObjesi;
        aktifEsya.SetActive(true);
        StartCoroutine(EsyaAkisi(esya));
    }

    IEnumerator EsyaAkisi(EsyaBilgisi esya)
    {
        yield return StartCoroutine(YaziYazdir(esya.altyazi));

        if (esya.ses != null)
        {
            sesKaynagi.clip = esya.ses;
            sesKaynagi.Play();
            yield return new WaitWhile(() => sesKaynagi.isPlaying);
        }

        altyaziText.text = "Eþyayý yerleþtir...";
        yield return new WaitUntil(() => aktifEsya == null);
        esyaIndex++;
        kutuAktif = true;
        altyaziText.text = "Devam etmek için kutuya týkla...";
    }

    public void EsyaYerlesinceCagir()
    {
        if (aktifEsya != null)
        {
            aktifEsya = null;
        }
    }
}
