using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FamiliarData : SabrinaData {

	// General Information
	public string animalForm = "";
	public string size = "";

	// Stats
	public int healthPoints = 0;
	public int attackPoints = 0;

	// Special Stats
	public bool darkVision = false;
	public bool canClimb = false;
	public bool canFly = false;
	public bool keenSmell = false;
	public bool waterBreathing = false;

	// Player Stats Boost
	public int healthBoost = 0;
	public int manaBoost = 0;

	// Player Magic Stats Boost
	public int protectionBoost = 0;
	public int transmutationBoost = 0;
	public int evocationBoost = 0;
	public int illusionBoost = 0;
	public int destructionBoost = 0;
	public int necromancyBoost = 0;
}
