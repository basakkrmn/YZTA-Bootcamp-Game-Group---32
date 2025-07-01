using UnityEngine;

public class SürükleBirak : MonoBehaviour
{
    private Vector3 fareFarkı;
    private bool sürükleniyor = false;

    void OnMouseDown()
    {
        // Fare ile objenin merkezi arasındaki fark
        fareFarkı = transform.position - FarePozisyonu();
        sürükleniyor = true;
    }

    void OnMouseDrag()
    {
        if (sürükleniyor)
        {
            Vector3 yeniPozisyon = FarePozisyonu() + fareFarkı;
            yeniPozisyon.z = 0; // 2D düzlemde kalalım
            transform.position = yeniPozisyon;
        }
    }

    void OnMouseUp()
    {
        sürükleniyor = false;
        // Şimdilik bırakma kontrolü yok
    }

    Vector3 FarePozisyonu()
    {
        Vector3 pozisyon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z = 0;
        return pozisyon;
    }
}
