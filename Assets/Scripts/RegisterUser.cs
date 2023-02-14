using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour
{
    public InputField m_NameField;
    public InputField m_PasswordField;
    public GameObject m_RegisterMenu;
    public GameObject m_MainMenu;
    public Button m_SubmitButton;

    /*public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm formCheck = new WWWForm();
        formCheck.AddField("name",m_NameField.text);
        formCheck.AddField("password", m_PasswordField.text);

        //Accesses url using php script
        WWW www = new WWW("https://vesta.uclan.ac.uk/~iivanov/BugHunter/php/register.php", formCheck);
        yield return www;//Wait for information

        //Return context of webpage
        if (www.text == "0")
        {
            Debug.Log("User created succesfully.");
            //Return user to main menu
            m_RegisterMenu.SetActive(false);
            m_MainMenu.SetActive(true);
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }

    }
    public void VerifyInput()
    {
        //Verification for username and password input validation
        m_SubmitButton.interactable = (m_NameField.text.Length >= 8 && m_PasswordField.text.Length >= 8);

    }*/
}
