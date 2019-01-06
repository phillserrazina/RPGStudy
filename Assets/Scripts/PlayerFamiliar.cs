using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFamiliar {
	
	// VARIABLES

	public enum Animals {
		Cat,
		Snake,
		Hawk,
		Frog
	}

	public enum Sizes {
		Small,
		Medium,
		Big
	}

	// General Information
	public string familiarName;
	public Animals animalForm;
	public Sizes size;

	// Stats
	public int healthPoints;
	public int attackPoints;

	// Special Stats
	public bool darkVision;
	public bool canClimb;
	public bool canFly;
	public bool keenSmell;
	public bool waterBreathing;

	// Player's Stats Boost
	public int healthBoost;
	public int manaBoost;

	// Player's Magic Stats Boost
	public int protectionBoost = 0;
	public int transmutationBoost = 0;
	public int evocationBoost = 0;
	public int illusionBoost = 0;
	public int destructionBoost = 0;
	public int necromancyBoost = 0;

	// METHODS

	/// <summary>
	/// Changes the value of the familiar's name.
	/// </summary>
	/// <param name="s">The name to be given to the familiar.</param>
	public void SetName(string s) {
		this.familiarName = s;
	}

	/// <summary>
	/// Changes the value of the familiar's animal form.
	/// </summary>
	/// <param name="s">The animal form to be given to the familiar.</param>
	public void SetAnimalForm(string s)
	{
		// Go through the "Animal" enum values
		foreach (Animals familiarType in System.Enum.GetValues(typeof(Animals))) {
			// If the name of the current value equals the given string
			if (familiarType.ToString() == s) {
				// Set the animal form to the current value and return
				this.animalForm = familiarType;
				return;
			}
		}

		// If no animal form corresponds, return an error
		Debug.LogError ("Invalid Familiar Animal Form!");
	}

	/// <summary>
	/// Changes the value of the familiar's size.
	/// </summary>
	/// <param name="s">The size to be given to the familiar.</param>
	public void SetSize(string s)
	{
		// Go through the "Sizes" enum values
		foreach (Sizes size in System.Enum.GetValues(typeof(Sizes))) {
			// If the name of the current value equals the given string
			if (size.ToString() == s) {
				// Set the size to the current value and return
				this.size = size;
				return;
			}
		}

		// If no size corresponds, return an error
		Debug.LogError ("Invalid size value!");
	}
}
