using UnityEngine;

public class EsyaTiklama : MonoBehaviour
{
    public int hikayeIndex; // Hangi hikaye oldu�unu belirtir
    private EsyaAnlatimiController anlatici;

    void Start()
    {
        anlatici = FindObjectOfType<EsyaAnlatimiController>();
    }

    void OnMouseDown()
    {
        if (anlatici != null)
        {
            anlatici.Oynat(hikayeIndex);
        }
    }
}
