using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class JSonWrapper : MonoBehaviour
{
    /*string link = "https://vesta.uclan.ac.uk/~iivanov/BugHunter/php/highscore.php";

   
    public void Update()
    {
        StartCoroutine(GetPlayerData());
        
    }
    [System.Serializable]
    public class ScoreWrapper
    {
        public List<DBManager.PlayerList> scoreTable=new List<DBManager.PlayerList>();
    }

    public ScoreWrapper m_DataIn;
    IEnumerator GetPlayerData()
    {
        var url = UnityWebRequest.Get(link);
        yield return url.SendWebRequest();

        //Debug.Log(url.downloadHandler.text);
        //Converts json to c# object
        m_DataIn = JsonUtility.FromJson<ScoreWrapper>(url.downloadHandler.text);
        foreach (DBManager.PlayerList index in m_DataIn.scoreTable)
        {
            DBManager.m_ScoreTable.Add(index);
        }
        if (url.isNetworkError) Debug.Log("Failed to get highscore table");
        else Debug.Log("High Score:" + url.downloadHandler.text);
    }*/

  
}
