using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //Se le ingresa el slot que le corresponde
    //y guarda el juego en la ruta designada por el software
    public static void SaveGameData(int saveSlot)
    {
        //crea un formateador binario
        BinaryFormatter formatter = new BinaryFormatter();
        //Crea el string del path donde se guardan los datos
        string path = Application.persistentDataPath + "/player"+ saveSlot +".doggy";
        //Creo un Stream de datos y abro/creo un archivo en la ruta seleccionada
        FileStream stream = new FileStream(path, FileMode.Create);
        //Creo un POJO y el constructor me regresa los datos del Singleton
        GameData data = new GameData();
        //Serializo la informacion
        formatter.Serialize(stream, data);
        //Cierro el archivo
        stream.Close();
        Debug.Log("Los Datos han sido guardados satisfactoriamente en " + path);
    }
    //Se le ingresa el slot que le corresponde
    //y carga el juego desde la ruta designada por el software
    public static GameData LoadGameData(int saveSlot)
    {
        //Creo el path sobre el cual probablemente exista el archivo de guardado
        string path = Application.persistentDataPath + "/player" + saveSlot + ".doggy";
        //Verifico que exista
        if (File.Exists(path))
        {
            //Si si existe creo un formateador binario
            BinaryFormatter formatter = new BinaryFormatter();
            //Abro el archivo
            FileStream stream = new FileStream(path, FileMode.Open);
            //Deserealizo los datos y los guardo en un POJO
            GameData data = formatter.Deserialize(stream) as GameData;
            //Cierro el archivo
            stream.Close();
            Debug.Log("Los Datos han sido cargados satisfactoriamente de " + path);
            //Retorno los datos
            return data;
        }
        else
        {
            //Retorno error de que no existe el archivo
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
    
}
