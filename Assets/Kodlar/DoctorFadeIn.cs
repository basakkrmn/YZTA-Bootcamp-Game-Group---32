using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoctorFadeIn : MonoBehaviour
{
    public float fadeDuration = 10f;
    public string nextSceneName = "Room"; // Sahne adý birebir

    private SpriteRenderer sr;
    private float t = 0;
    private bool startFade = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Color c = sr.color;
        c.a = 0f;
        sr.color = c;
    }

    void Update()
    {
        if (startFade && t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
        }
    }

    public void TriggerFade()
    {
        startFade = true;
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(fadeDuration + 0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}
