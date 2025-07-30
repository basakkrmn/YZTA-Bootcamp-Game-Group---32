using UnityEngine;

public class BoxClick : MonoBehaviour
{
    private PlacementFlowManager manager;

    void Start()
    {
        manager = FindObjectOfType<PlacementFlowManager>();
    }

    void OnMouseDown()
    {
        if (manager != null)
            manager.KutuyaTiklandi();
    }
}
