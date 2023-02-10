using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DBManager
{
  
    [System.Serializable]
    public class PlayerList
    {
        public string UserName;
        public int Score;

    }
    public static string m_UserName;
    public static int m_Score;
    public static int m_PlayerChoice;
    public  static List<PlayerList> m_ScoreTable = new List<PlayerList>();


    public static bool LoggedIn { get { return m_UserName != null; } }
    public static void LogOut()
    {
        m_UserName = null;
    }
}
