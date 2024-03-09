using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject setting;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Setting()
    {
        setting.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close()
    {
        setting.SetActive(false);
        Time.timeScale = 0;
    }
}
