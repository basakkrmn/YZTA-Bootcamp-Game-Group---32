using UnityEngine;

public class EsyaAkisController : MonoBehaviour
{
    public GameObject[] esyalar;                    // S�rayla a��lacak e�yalar
    public GameObject esyaPanel;                    // Hikaye paneli
    public EsyaAnlatimiController anlatim;          // Ses + yaz� + g�rsel oynatma sistemi
    public GameObject yerlestirmeArayuzu;           // Yerle�tirme UI'si

    private int aktifIndex = 0;
    private bool panelAktif = false;

    private void OnMouseDown()
    {
        if (panelAktif || aktifIndex >= esyalar.Length)
            return;

        esyalar[aktifIndex].SetActive(true);         // E�yay� g�ster
        esyaPanel.SetActive(true);                   // Paneli a�
        anlatim.Oynat(aktifIndex);                   // Hikaye ba�lat
        panelAktif = true;
    }

    public void DevamEt()
    {
        esyaPanel.SetActive(false);                  // Paneli kapat
        aktifIndex++;                                // Sonraki e�yaya ge�
        panelAktif = false;

        if (aktifIndex >= esyalar.Length)
        {
            // T�m e�yalar anlat�ld�, yerle�tirme sahnesine ge�
            if (yerlestirmeArayuzu != null)
                yerlestirmeArayuzu.SetActive(true);

            // Beyaz kutuyu devre d��� b�rak
            gameObject.SetActive(false);
        }
    }
}
