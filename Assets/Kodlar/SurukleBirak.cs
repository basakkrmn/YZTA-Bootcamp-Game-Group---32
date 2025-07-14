using UnityEngine;

public class SurukleBirak : MonoBehaviour
{
    private Vector3 fareFarkı;
    private bool sürükleniyor = false;

    void OnMouseDown()
    {
        if (FlashbackYoneticisi.Ornek != null && FlashbackYoneticisi.Ornek.flashbackAktif)
            return;

        // Flashback oynatılmamışsa sürükleme başlatılmaz
        EsyaVerisi veri = GetComponent<EsyaVerisi>();
        if (veri != null && !veri.flashbackOynatildi)
            return;

        fareFarkı = transform.position - FarePozisyonu();
        sürükleniyor = true;
    }


    void OnMouseDrag()
    {
        if (!sürükleniyor || FlashbackYoneticisi.Ornek.flashbackAktif)
            return;

        Vector3 yeniPozisyon = FarePozisyonu() + fareFarkı;
        yeniPozisyon.z = 0;
        transform.position = yeniPozisyon;
    }

    void OnMouseUp()
    {
        if (!sürükleniyor)
            return;

        sürükleniyor = false;
    }

    private Vector3 FarePozisyonu()
    {
        Vector3 pozisyon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z = 0;
        return pozisyon;
    }
}
