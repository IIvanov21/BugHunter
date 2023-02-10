using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayScore : MonoBehaviour
{
    public TMP_Text m_PlayerNameText;
    public TMP_Text m_ScoreText;
    public int index;
    public void Update()
    {
       if(index<DBManager.m_ScoreTable.Count) m_PlayerNameText.text = DBManager.m_ScoreTable[index].UserName;
        if (index < DBManager.m_ScoreTable.Count) m_ScoreText.text = (DBManager.m_ScoreTable[index].Score).ToString();

    }

}
