using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{
    public static void SaveJsonData(IEnumerable<ISaveable> a_Saveables)
    {
        SaveData sd = new SaveData();
        foreach (var saveable in a_Saveables)
        {
            saveable.PopulateSaveData(sd);
        }

        if (FileManager.WriteToFile("SaveData01.dat", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }
    
    public static void LoadJsonData(IEnumerable<ISaveable> a_Saveables)
    {
        if (FileManager.LoadFromFile("SaveData01.dat", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            foreach (var saveable in a_Saveables)
            {
                saveable.LoadFromSaveData(sd);
            }
            
            Debug.Log("Load complete");
        }
    }
}
