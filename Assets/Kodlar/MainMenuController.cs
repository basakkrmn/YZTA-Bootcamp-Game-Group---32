using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject teamPanel;
    public GameObject mainMenuUI;

    public void ShowTeam()
    {
        teamPanel.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void BackToMenu()
    {
        teamPanel.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Intro"); // Sahne adýný birebir doðru yaz
    }
}
