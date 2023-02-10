using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool m_GameIsPaused = false;
    public GameObject m_PauseMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_GameIsPaused) Resume();
            else Pause();
        }
    }
    public void Resume()
    {
        m_PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        m_GameIsPaused = false;
    }

    void Pause()
    {
        m_PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        m_GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 0.0f;
        m_GameIsPaused = false;
        DBManager.LogOut();

    }
}
