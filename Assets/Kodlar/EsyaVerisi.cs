using UnityEngine;

public class EsyaVerisi : MonoBehaviour
{
    [TextArea(2, 5)]
    public string flashbackMetni;

    [HideInInspector]
    public bool flashbackOynatildi = false;
}
