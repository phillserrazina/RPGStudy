using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// VARIABLES

	public static GameManager instance;

	private string saveFileName = "Game_Data.json";
	private GameData gameData = new GameData();

	private Player player;

	// EXECUTION METHODS

	private void Awake()
	{
		#region Singleton

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (this.gameObject);

		#endregion
	
		player = FindObjectOfType<Player> ();
	}

	// METHODS

	/// <summary>
	/// Saves the game into a .json file.
	/// </summary>
	public void SaveGame()
	{
		PlayerStatsToData ();
		CustomJson.SaveData (saveFileName, gameData.playerData);
	}

	/// <summary>
	/// Loads the game from a .json file.
	/// </summary>
	public void LoadGame() {
		gameData.playerData = CustomJson.ReadData (saveFileName);
		DataToPlayerStats ();

		CCreationMenu.loading = true;
	}

	#region Utility Methods

	/// <summary>
	/// Utility Method: Copies the backend stored player data into the in-game player stats.
	/// </summary>
	private void DataToPlayerStats()
	{
		player.playerName = gameData.playerData.playerName;
		player.familiar.familiarName = gameData.playerData.familiarName;

		foreach (PlayerFamiliar.Animals familiarType in System.Enum.GetValues(typeof(PlayerFamiliar.Animals))) {
			if (familiarType.ToString() == gameData.playerData.familiarAnimalForm) {
				player.familiar.animalForm = familiarType;
				break;
			}
		}

		foreach (Spell.Schools magicSchool in System.Enum.GetValues(typeof(Spell.Schools))) {
			if (magicSchool.ToString() == gameData.playerData.naturalTalent) {
				player.naturalTalent = magicSchool;
				break;
			}
		}

		player.healthPoints = gameData.playerData.healthPoints;
		player.manaPoints = gameData.playerData.manaPoints;
		player.moralityPoints = gameData.playerData.moralityPoints;

		player.protectionPoints = gameData.playerData.protectionPoints;
		player.transmutationPoints = gameData.playerData.transmutationPoints;
		player.evocationPoints = gameData.playerData.evocationPoints;
		player.illusionPoints = gameData.playerData.illusionPoints;
		player.destructionPoints = gameData.playerData.destructionPoints;
		player.necromancyPoints = gameData.playerData.necromancyPoints;
	}

	/// <summary>
	/// Utility Method: Copies the in-game player's stats into the backend stored player data.
	/// </summary>
	private void PlayerStatsToData()
	{
		gameData.playerData.playerName = player.playerName;
		gameData.playerData.familiarName = player.familiar.familiarName;
		gameData.playerData.familiarAnimalForm = player.familiar.animalForm.ToString ();
		gameData.playerData.naturalTalent = player.naturalTalent.ToString ();

		gameData.playerData.healthPoints = player.healthPoints;
		gameData.playerData.manaPoints = player.manaPoints;
		gameData.playerData.moralityPoints = player.moralityPoints;

		gameData.playerData.protectionPoints = player.protectionPoints;
		gameData.playerData.transmutationPoints = player.transmutationPoints;
		gameData.playerData.evocationPoints = player.evocationPoints;
		gameData.playerData.illusionPoints = player.illusionPoints;
		gameData.playerData.destructionPoints = player.destructionPoints;
		gameData.playerData.necromancyPoints = player.necromancyPoints;
	}

	#endregion
}
