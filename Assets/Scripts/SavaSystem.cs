using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    /*public static void SavePlayer(Player player)
    {
        //Creat file to format
        BinaryFormatter mainFormatter = new BinaryFormatter();
        string m_Path = Application.persistentDataPath + "/player.pot";
        FileStream mainStream = new FileStream(m_Path, FileMode.Create);

        //Bind information class
        PlayerData m_Data = new PlayerData(player);

        //Insert into a file
        mainFormatter.Serialize(mainStream, m_Data);
        mainStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string m_Path = Application.persistentDataPath + "/player.pot";
        if (File.Exists(m_Path))
        {
            BinaryFormatter mainFormatter = new BinaryFormatter();
            FileStream mainStream = new FileStream(m_Path, FileMode.Open);

            PlayerData m_Data = mainFormatter.Deserialize(mainStream) as PlayerData;
            mainStream.Close();
            return m_Data;
        }
        else
        { 
            Debug.LogError("Save File not found in" + m_Path);
            return null;
        }
    }*/
}
