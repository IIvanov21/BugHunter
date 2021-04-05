using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TMP_Text m_UserName;
    private void Awake()
    {
         m_UserName.text = DBManager.m_UserName;
    }
    private void Update()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(Time.timeScale==0)Time.timeScale = 1.0f;  
    }
}
