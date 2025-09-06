using System.IO;
using UnityEngine;


public static class SaveManager
{
    private static string saveDirectory => Application.persistentDataPath + "/Saves/";

    public static bool SaveExists(int slot)
    {
        string path = GetSavePath(slot);
        return File.Exists(path);
    }

    public static string GetSavePath(int slot)
    {
        return Path.Combine(saveDirectory, $"save{slot}.json");
    }

    public static int FindNextAvailableSlot()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (!SaveExists(i))
                return i;
        }
        return -1; // No available slot
    }

    public static void CreateNewSave(int slot, string playerName)
    {
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        SaveData newData = new SaveData
        {
            playerName = playerName,
            health = 100,
            diet = 50,
            satiety = 30,
            lastScene = "OUTDOOR" // Replace with your actual starting scene
        };

        string json = JsonUtility.ToJson(newData);
        File.WriteAllText(GetSavePath(slot), json);
    }

    public static SaveData LoadGame(int slot)
    {
        string path = GetSavePath(slot);
        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public static void SaveGame(int slot, SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(GetSavePath(slot), json);
    }
}
