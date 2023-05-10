using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileHandeler : MonoBehaviour
{
   public void SaveData<T>(List<T> toSave)
    {
        string con = HelperJs.ToJson<T>(toSave.ToArray(),true);
    }
    private void WriteFile(string path, string content)
    {
        FileStream fileAccess = new FileStream(path,FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileAccess))
        {
            writer.Write(content);
        }
    }

    private string GetPath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

public static class HelperJs
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        return wrapper.items;
    }

    public static string ToJS<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool point)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.items = array;
        return JsonUtility.ToJson(wrapper,point);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}
