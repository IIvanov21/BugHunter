using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
    public TMP_Text m_PlayerNameDisplay;
    public TMP_Text m_ScoreDisplay;
    public int m_LevelIndex;
    private int m_NextLevel;
    private int m_CharacterIndex;
    private int m_NumOfSkins = 1; // Character skins start at 0
    // Start is called before the first frame update
    void Awake()
    {
      
        m_PlayerNameDisplay.text = DBManager.m_UserName;
        m_ScoreDisplay.text = "Score:" + DBManager.m_Score;
        
        m_NextLevel = m_LevelIndex + 1;
    }
    public void Start()
    {
        m_CharacterIndex = 0;
        Time.timeScale = 1;
    }

    public void CallSaveData()
    {
        //StartCoroutine(SavePlayerData());
    }

    /*IEnumerator SavePlayerData()
    {
        WWWForm formPlayer = new WWWForm();
        formPlayer.AddField("name", DBManager.m_UserName);
        formPlayer.AddField("score", DBManager.m_Score);
        formPlayer.AddField("characterChoice", DBManager.m_PlayerChoice);
        WWW www = new WWW("https://vesta.uclan.ac.uk/~iivanov/BugHunter/php/savedata.php", formPlayer);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Save failed. Error#" + www.text);
        }
        
    }*/
    //Select the skin through incrementing and decrementing an index between the range of skins 
    public void DecreaseCharacterIndex()
    {
       if(m_CharacterIndex>0) m_CharacterIndex--;   
    }

    public void IncreaseCharacterIndex()
    {
        if(m_CharacterIndex<m_NumOfSkins)m_CharacterIndex++;
    }
    public void LogOut()
    {
        CallSaveData();
        DBManager.LogOut();
    }

    public void IncreaseScore(int scoreIn)
    {
        DBManager.m_Score+=scoreIn;
        m_ScoreDisplay.text = "Score: " + DBManager.m_Score;
    }

    public void SetCharacter()
    {
        DBManager.m_PlayerChoice = m_CharacterIndex;
        CallSaveData();
    }


    public void ChangeLevel()
    {
        CallSaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
