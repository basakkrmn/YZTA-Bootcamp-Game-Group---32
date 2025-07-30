using UnityEngine;
using System.Collections.Generic;

public class EsyaDenetleyici : MonoBehaviour
{
    [Header("Býrakma Noktalarý")]
    public List<Transform> gecerliBirakmaYerleri = new List<Transform>();
    [Range(0.05f, 2f)] public float yakalamaMesafesi = 0.8f;

    [Header("Ses ve Etkileþim")]
    public AudioClip birakmaSesi;
    private AudioSource sesKaynagi;

    private Vector3 fareOfseti;
    private Vector3 sonPozisyon;
    private bool surukleniyor = false;
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
        sonPozisyon = transform.position;
        sesKaynagi = FindObjectOfType<AudioSource>();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 farePoz = FareDunyasi();
            fareOfseti = transform.position - farePoz;
            surukleniyor = true;
        }
    }

    void OnMouseDrag()
    {
        if (surukleniyor)
        {
            Vector3 farePoz = FareDunyasi();
            transform.position = farePoz + fareOfseti;
        }
    }

    void OnMouseUp()
    {
        if (surukleniyor)
        {
            surukleniyor = false;
            bool yerlesti = false;

            foreach (var nokta in gecerliBirakmaYerleri)
            {
                if (Vector3.Distance(transform.position, nokta.position) < yakalamaMesafesi)
                {
                    transform.position = nokta.position;
                    yerlesti = true;

                    if (birakmaSesi != null && sesKaynagi != null)
                        sesKaynagi.PlayOneShot(birakmaSesi);

                    FindObjectOfType<PlacementFlowManager>().EsyaYerlesinceCagir();
                    break;
                }
            }

            if (!yerlesti)
            {
                transform.position = sonPozisyon;
            }
        }
    }

    Vector3 FareDunyasi()
    {
        Vector3 ekranPoz = cam.WorldToScreenPoint(transform.position);
        Vector3 farePoz = Input.mousePosition;
        farePoz.z = ekranPoz.z;
        return cam.ScreenToWorldPoint(farePoz);
    }
}
