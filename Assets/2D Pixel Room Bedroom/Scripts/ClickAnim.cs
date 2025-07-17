using UnityEngine;

public class ClickAnim : MonoBehaviour
{
    public Animation anim;
    public string openClip;
    public string closeClip;

    private bool isOpen = false;

    void OnMouseDown()
    {
        if (anim == null) return;

        string targetClip = isOpen ? closeClip : openClip;
        anim[targetClip].wrapMode = WrapMode.ClampForever;
        anim.Play(targetClip);
        isOpen = !isOpen;
    }
}
