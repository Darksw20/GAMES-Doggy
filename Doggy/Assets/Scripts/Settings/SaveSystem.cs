using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGameData(int saveSlot)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player"+ saveSlot +".doggy";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData();
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Los Datos han sido guardados satisfactoriamente en " + path);
    }

    public static GameData LoadGameData(int saveSlot)
    {
        string path = Application.persistentDataPath + "/player" + saveSlot + ".doggy";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            Debug.Log("Los Datos han sido cargados satisfactoriamente de " + path);
            return data;
        }
        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
    
}
