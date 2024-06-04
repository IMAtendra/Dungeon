using System.IO;
using UnityEngine;

public class SaveSystem
{
    #region PlayerPrefs
    public static void SaveByPlayerPrefs(string key, object data)
    {
        var json = JsonUtility.ToJson(obj: data);

        PlayerPrefs.SetString(key: key, value: json);
        PlayerPrefs.Save();

#if UNITY_EDITOR
        Debug.Log(message: $"Successfully saved data to PlayerPrefs.");
#endif
    }

    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key: key, defaultValue: null);
    }
    #endregion

    #region JSON
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(obj: data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.WriteAllText(path: path, contents: json);

            #if UNITY_EDITOR
            Debug.Log(message: $"Successfully saved data to {path}.");
            #endif

        }
        catch (FileNotFoundException fileNotFound)
        {
            // Handle exception
            #if UNITY_EDITOR
            Debug.Log($"File not Found {path}. \n{fileNotFound}");
            #endif
            
        }
        catch (DirectoryNotFoundException dirNotFound)
        {
            // Example: Invoke a save error event
            // then this event can be used in a UI Controller class
            #if UNITY_EDITOR
            Debug.Log($"Directory not Found {path}. \n{dirNotFound}");
            #endif
        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.Log($"Failed to save data to {path}. \n{exception}");
            #endif
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            
            return data;

        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.Log($"Failed to load data from {path}. \n{exception}");
            #endif

            return default;
        }
    }
    #endregion

    #region Deleting
    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);

        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.Log($"Failed to delete data to {path}. \n{exception}");
            #endif
        }

    }
    #endregion
}
