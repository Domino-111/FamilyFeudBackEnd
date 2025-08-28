using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// STATIC - Called upon anywhere without reference
public static class JSONManager
{
    public static void SayHello()
    {
        Debug.Log("Say hello to my little friend!");
    }

    /// <summary>
    /// JSON Encryption algorithm which takes an object (SavedData) and pushes it into a Text/JSON file
    /// CTRL + V in your File Browser application to see where it's been saved
    /// </summary>
    /// <param name="data"></param>
    public static void SaveToJSON(SavedData data)
    {
        string directory = Application.persistentDataPath + "/SavedData/";

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = JsonUtility.ToJson(data, true); // This is the JSON encryption!

        File.WriteAllText(directory + "responseDatabase.json", json);

        GUIUtility.systemCopyBuffer = directory; // This is the CTRL + C
    }

    /// <summary>
    /// JSON Decryption that turns a Text/JSON file into an object (SavedData) which'll be returned
    /// Returns NULL if it couldn't find a file
    /// </summary>
    /// <returns></returns>
    public static SavedData LoadFromJSON()
    {
        string directory = Application.persistentDataPath + "/SavedData/" + "responseDatabase.json";

        if (File.Exists(directory))
        {
            // This is the "fun" stuff
            string json = File.ReadAllText(directory);

            return JsonUtility.FromJson<SavedData>(json); // This is the JSON decryption
        }

        else
        {
            Debug.Log("Load failed. No file found.");
            return null;
        }
    }
}

[Serializable] // Readable in the Unity Inspector

// SavedData - a collection of information you'd like to be saved when prompted
// For this project, we just need to save a list of question objects... but it could be more
public class SavedData
{
    public List<Question> savedQuestions;
}
