using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Static class allows access from any other script without being instantiated
public static class SaveSystem
{
    // Save player health
    public static void SavePlayer(PlayerHealth playerHealth)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        // Set the save file path
        string path = Application.persistentDataPath + "/playerHealth.txt";
        // Create a new file at the given path
        FileStream stream = new FileStream(path, FileMode.Create);
        // Instantiate playerdata to grab data
        PlayerData data = new PlayerData(playerHealth);
        // Write data to file using binary formatter
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerHealth.txt";
        // Check the save file exists
        if (File.Exists(path))
        {
            // Instantiate binary formatter to convert data from file
            BinaryFormatter formatter = new BinaryFormatter();
            // Open file at path
            FileStream stream = new FileStream(path, FileMode.Open);
            // Convert file from binary to original format (and cast the data into a PlayerData instance)
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        } else
        {
            Debug.Log("Save file not found at: " + path);
            return null;
        }
    }
}
