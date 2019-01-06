using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomJson {

	/// <summary>
	/// Saves the given Player Data to the given .json file.
	/// </summary>
	/// <param name="fileName">The name of the file where the data will be stored.</param>
	/// <param name="data">The Player Data meant to be stored.</param>
	public static void SaveData (string fileName, PlayerData data)
	{
		// Get the path of the file where the data will be stored
		string path = Application.persistentDataPath + "/" + fileName;
		Debug.Log ("Saving Data To " + path);

		// Instantiate a new .json wrapper that will encapsulate the player data
		JsonWrapper wrapper = new JsonWrapper ();
		// Copy the given data into the wrapper's player data
		wrapper.gameData.playerData = data;

		// Encode the given data into a .json string
		string contents = JsonUtility.ToJson (wrapper, true);
		// Write the .json string to the given file
		System.IO.File.WriteAllText (path, contents);
	}

	/// <summary>
	/// Retrieves Player Data from a given .json file.
	/// </summary>
	/// <returns>The player's data stored in the given file.</returns>
	/// <param name="fileName">The name of the file where the data will be retrieved.</param>
	public static PlayerData ReadData (string fileName)
	{
		// Get the path of the file where the data will be retrieved
		string path = Application.persistentDataPath + "/" + fileName;

		// If no file is found at the aforementioned path,
		if (!System.IO.File.Exists (path)) {
			// Stop this process and print an error.
			Debug.LogError ("Unable to read the file: file does not exist");
			return null;
		}

		Debug.Log ("Retrieving Data From " + path);
		// Read the contents from the file at the given path
		string contents = System.IO.File.ReadAllText (path);

		// Decode the retrieved .json data into a new wrapper
		JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper> (contents);
		// Return the player's data from the newly instantiated wrapper.
		return wrapper.gameData.playerData;
	}

	/// <summary>
	/// Retrieves a familiar's information and traits from a given .json file
	/// </summary>
	/// <returns>The familiar data.</returns>
	/// <param name="fileName">The name of the .json file that holds the familiars' information.</param>
	/// <param name="familiarForm">The familiar's form whose information is sought.</param>
	public static FamiliarData GetFamiliarData (string fileName, string familiarForm)
	{
		// Get the path of the file where the data will be retrieved
		string path = Application.persistentDataPath + "/" + fileName;

		// If no file is found at the aforementioned path,
		if (!System.IO.File.Exists (path)) {
			// Stop this process and print an error.
			Debug.LogError ("Unable to read the file: file does not exist");
			return null;
		}

		Debug.Log ("Retrieving Data From " + path);
		// Read the contents from the file at the given path
		string contents = System.IO.File.ReadAllText (path);
		// Store the list of familiars retrieved from the .json file
		FamiliarList familiarList = JsonUtility.FromJson<FamiliarList> (contents);

		// Go through all the familiars found in the data file
		foreach(FamiliarData fd in familiarList.familiarData) {
			// If the given familiar form is found,
			if (fd.animalForm.ToString() == familiarForm)
				// Return its' data.
				return fd;
		}

		// If the given familiar form is not found,
		// Print an error and return null from this process
		Debug.LogError ("Familiar Form Not Found!");
		return null;
	}
}
