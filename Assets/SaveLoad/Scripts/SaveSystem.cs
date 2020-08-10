/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{

    private static bool isInit;
    private static bool useNewSavePath = false;

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private const string SAVE_EXTENSION = "txt";
    public static string newSavePath;

    public static void Init()
    {
        if (!isInit)
        {
            isInit = true;                
            // Test if Save Folder exists
            if (!Directory.Exists(SAVE_FOLDER))
            {
                
                // Create Save Folder
                Directory.CreateDirectory(SAVE_FOLDER);
            }
        }
    }

    public static void SetSavePath(string saveFolder)
    {
        newSavePath = saveFolder;
        // Test if Save Folder exists
        if (!Directory.Exists(newSavePath))
        {
            // Create Save Folder
            Directory.CreateDirectory(newSavePath);
        }
        useNewSavePath = true;
    }

    public static void Save(string fileName, string saveString, bool overwrite)
    {
        Init();
        string saveFileName = fileName;
        if (!overwrite)
        {
            // Make sure the Save Number is unique so it doesnt overwrite a previous save file
            int saveNumber = 1;

            string savePath;
            if (useNewSavePath)
                savePath = newSavePath;
            else
                savePath = SAVE_FOLDER;
            while (File.Exists(savePath + saveFileName + "." + SAVE_EXTENSION))
            {
                saveNumber++;
                saveFileName = fileName + " " + saveNumber;
            }
            // saveNumber is unique
        }
        File.WriteAllText(SAVE_FOLDER + saveFileName + "." + SAVE_EXTENSION, saveString);
    }


    public static string Load(string fileName)
    {
        Init();

        string savePath;
        if (useNewSavePath)
            savePath = newSavePath;
        else
            savePath = SAVE_FOLDER;
        // If theres a save file, load it, if not return null
        if (File.Exists(savePath + fileName + "." + SAVE_EXTENSION))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + fileName + "." + SAVE_EXTENSION);
            return saveString;
        }
        else
        {
            return null;
        }
    }

    public static string LoadMostRecentFile()
    {
        Init();
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        // Get all save files
        FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
        // Cycle through all save files and identify the most recent one
        FileInfo mostRecentFile = null;
        foreach (FileInfo fileInfo in saveFiles)
        {
            if (mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }

        // If theres a save file, load it, if not return null
        if (mostRecentFile != null)
        {
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            return saveString;
        }
        else
        {
            return null;
        }
    }

    public static void SaveObject(string docName, object saveObject)
    {
        //Init();
        if (docName.Length >= 1)

        SaveObject(docName, saveObject, false);
            else
        SaveObject("save", saveObject, false);
    }

    public static void SaveObject(string filename, object saveObject, bool overwrite)
    {
        Init();
        string json = JsonUtility.ToJson(saveObject);
        Save(filename, json, overwrite);
    }

    public static TSaveObject LoadObject<TSaveObject>(string fileName){
        Init();
        string saveString = Load(fileName);
        if(saveString  != null)
        {
            TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(saveString);
            return saveObject;
        }
        else
        {
            return default;
        }
        
    }

    public static TSaveObject LoadMostRecentSaveObject<TSaveObject>()
    {
        Init();
        string saveString = LoadMostRecentFile();
        if(saveString != null)
        {
            TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(saveString);
            return saveObject;
        }
        else
        {
            return default;
        }
    }
}
