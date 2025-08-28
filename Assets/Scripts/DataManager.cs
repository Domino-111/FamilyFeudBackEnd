using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Update this list everytime your user answers the relevant quesiton
    public List<Question> myQuestions;

    void Start()
    {
        LoadGame();
    }

    void Update()
    {

    }

    /// <summary>
    /// Create a new SavedData file and give it all the questions in 'myQuestions'
    /// Encrypt that into a JSON file with the JSONManager
    /// </summary>
    [ContextMenu("Save Game")]
    public void SavedGame()
    {
        print("Attempting to save game");

        SavedData savedData = new SavedData();
        savedData.savedQuestions = myQuestions;
        JSONManager.SaveToJSON(savedData);
    }

    /// <summary>
    /// Use the JSONManager to retrieve the questions stored away
    /// Push those questions on the 'myQuestions' list
    /// If the Load() fails, Save() the game instead
    /// </summary>
    [ContextMenu("Load Game")]
    public void LoadGame()
    {
        print("Attempting to load game");

        SavedData loadedData = JSONManager.LoadFromJSON();
        if (loadedData != null)
        {
            myQuestions = loadedData.savedQuestions;
        }

        else
        {
            SavedGame();
        }
    }
}

[Serializable]
// Datapack which contains a question (string) and a list of responses (List<string>)
public class Question
{
    public string question;
    public List<string> responses;
}
