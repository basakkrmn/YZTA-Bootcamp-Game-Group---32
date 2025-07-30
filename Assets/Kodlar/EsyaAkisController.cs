using UnityEngine;

public class EsyaAkisController : MonoBehaviour
{
    public GameObject[] esyalar;                    // Sýrayla açýlacak eþyalar
    public GameObject esyaPanel;                    // Hikaye paneli
    public EsyaAnlatimiController anlatim;          // Ses + yazý + görsel oynatma sistemi
    public GameObject yerlestirmeArayuzu;           // Yerleþtirme UI'si

    private int aktifIndex = 0;
    private bool panelAktif = false;

    private void OnMouseDown()
    {
        if (panelAktif || aktifIndex >= esyalar.Length)
            return;

        esyalar[aktifIndex].SetActive(true);         // Eþyayý göster
        esyaPanel.SetActive(true);                   // Paneli aç
        anlatim.Oynat(aktifIndex);                   // Hikaye baþlat
        panelAktif = true;
    }

    public void DevamEt()
    {
        esyaPanel.SetActive(false);                  // Paneli kapat
        aktifIndex++;                                // Sonraki eþyaya geç
        panelAktif = false;

        if (aktifIndex >= esyalar.Length)
        {
            // Tüm eþyalar anlatýldý, yerleþtirme sahnesine geç
            if (yerlestirmeArayuzu != null)
                yerlestirmeArayuzu.SetActive(true);

            // Beyaz kutuyu devre dýþý býrak
            gameObject.SetActive(false);
        }
    }
}
