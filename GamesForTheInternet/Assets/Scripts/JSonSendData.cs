using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class JSonSendData : MonoBehaviour
{
    string m_Link = "https://vesta.uclan.ac.uk/~iivanov/BugHunter/php/sendscore.php";
    string m_Json;
 
    public void CallSavePlayerData()
    {
        StartCoroutine(SavePlayerData());
    }
    [System.Serializable]
    public class ScoreWrapper
    {
        public List<DBManager.PlayerList> scoreTable = new List<DBManager.PlayerList>();
    }

   

    public ScoreWrapper m_DataIn;
    void Awake()
    {
        DBManager.PlayerList m_Row =new DBManager.PlayerList();
        m_Row.UserName = DBManager.m_UserName;
        m_Row.Score = DBManager.m_Score;
        ScoreWrapper m_DataSent = new ScoreWrapper();
        m_DataSent.scoreTable.Add(m_Row);

        m_Json = JsonUtility.ToJson(m_DataSent);
        StartCoroutine(SavePlayerData());

    }
    IEnumerator SavePlayerData()
    {
        //Send data and convert to json
        var url = new UnityWebRequest(m_Link, "POST");
        byte[] SendjSon = new System.Text.UTF8Encoding().GetBytes(m_Json);
        url.uploadHandler = (UploadHandler)new UploadHandlerRaw(SendjSon);
        url.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        url.SetRequestHeader("Content-Type", "application/json");
        yield return url.SendWebRequest();//Do other stuff while sending results


        if (url.isNetworkError) Debug.Log("Failed to get highscore table");
        else Debug.Log("Sent to database:" + url.downloadHandler.text);
    }
}
