using System;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
    public DoctorFadeIn doctorFade;

    void Start()
    {
        Invoke("RevealDoctor", 51f); // 51 saniye sonra tetikle
    }

    void RevealDoctor()
    {
        if (doctorFade != null)
        {
            doctorFade.TriggerFade();
        }
    }

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }
}
