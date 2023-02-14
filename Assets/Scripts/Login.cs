using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Login : MonoBehaviour
{
    public InputField m_NameField;
    public InputField m_PasswordField;
    public GameObject m_RegisterMenu;
    public GameObject m_MainMenu;
    public Button m_SubmitButton;
    public Button m_PlayButton;
    public TMP_Text m_PlayerNameDisplay;

    /*public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm formCheck = new WWWForm();
        formCheck.AddField("name", m_NameField.text);
        formCheck.AddField("password", m_PasswordField.text);

        //Accesses url using php script
        WWW www = new WWW("https://vesta.uclan.ac.uk/~iivanov/BugHunter/php/login.php", formCheck);
        yield return www;//Wait for information

        if (www.text[0] == '0')
        {
            DBManager.m_UserName = m_NameField.text;
            DBManager.m_Score = int.Parse(www.text.Split('\t')[1]);
            DBManager.m_PlayerChoice = int.Parse(www.text.Split('\t')[2]);
            //Succesfull Login return to main menu
            m_RegisterMenu.SetActive(false);
            m_MainMenu.SetActive(true);
        }
        else
        {
            Debug.Log("User Login failed. Error #" + www.text);
         
        }
        if (DBManager.LoggedIn)
        {
            m_PlayerNameDisplay.text = "Player: " + DBManager.m_UserName;
            m_PlayButton.interactable=true;
        }
    }

    public void VerifyInput()
    {
        //Verification for username and password input validation
        m_SubmitButton.interactable = (m_NameField.text.Length >= 8 && m_PasswordField.text.Length >= 8);

    }*/

}
