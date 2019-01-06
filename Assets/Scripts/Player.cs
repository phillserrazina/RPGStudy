using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Player instance;

	#region VARIABLES

	[Header("General Info")]
	public string playerName;
	public PlayerFamiliar familiar = new PlayerFamiliar();
	private FamiliarData familiarData = new FamiliarData();
	public Spell.Schools naturalTalent;

	[Header("Stats")]
	public int healthPoints;
	public int manaPoints;
	public int moralityPoints;

	[Header("Magic Points")]
	public int protectionPoints;
	public int transmutationPoints;
	public int evocationPoints;
	public int illusionPoints;
	public int destructionPoints;
	public int necromancyPoints;

	[Header("Base Stats")]
	public int baseHealthPoints;
	public int baseManaPoints;
	public int baseMoralityPoints;

	[Header("Basic Magic Points")]
	public int baseProtectionPoints;
	public int baseTransmutationPoints;
	public int baseEvocationPoints;
	public int baseIllusionPoints;
	public int baseDestructionPoints;
	public int baseNecromancyPoints;

	#endregion

	#region EXECUTION FUNCTIONS

	private void Awake()
	{
		#region Singleton

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (this.gameObject);

		#endregion
	}

	private void Start() {
		
	}

	#endregion

	#region BUTTON METHODS

	public void SetName (string name) {
		playerName = name;
	}

	public void SetFamiliarName(string name) {
		familiar.SetName (name);
	}

	public void SetFamiliarForm(string form) {
		familiar.SetAnimalForm (form);
		familiarData = CustomJson.GetFamiliarData ("Familiars_Data.json", form);

		DataToFamiliarStats ();
		ApplyFamiliarStatBoosts ();
	}

	public void SetTalent (string type) 
	{
		switch (type) 
		{
		case "Transmutation":
			this.naturalTalent = Spell.Schools.Transmutation;
			ResetMagicStats ();
			this.transmutationPoints = this.baseTransmutationPoints + 2;
			break;
		case "Destruction":
			this.naturalTalent = Spell.Schools.Destruction;
			ResetMagicStats ();
			this.destructionPoints = this.baseDestructionPoints + 2;
			break;
		case "Evocation":
			this.naturalTalent = Spell.Schools.Evocation;
			ResetMagicStats ();
			this.evocationPoints = this.baseEvocationPoints + 2;
			break;
		case "Illusion":
			this.naturalTalent = Spell.Schools.Illusion;
			ResetMagicStats ();
			this.illusionPoints = this.baseIllusionPoints + 2;
			break;
		case "Necromancy":
			this.naturalTalent = Spell.Schools.Necromancy;
			ResetMagicStats ();
			this.necromancyPoints = this.baseNecromancyPoints + 2;
			break;
		case "Protection":
			this.naturalTalent = Spell.Schools.Protection;
			ResetMagicStats ();
			this.protectionPoints = this.baseProtectionPoints + 2;
			break;
		default:
			Debug.LogError ("Invalid School of Magic");
			break;
		}
	}

	#endregion

	#region UTILITY METHODS

	private void ApplyFamiliarStatBoosts()
	{
		if (familiar == null)
			return;

		this.healthPoints = this.baseHealthPoints + familiarData.healthBoost;
		this.manaPoints = this.baseManaPoints + familiarData.manaBoost;

		this.protectionPoints = this.baseProtectionPoints + familiarData.protectionBoost;
		this.transmutationPoints = this.baseTransmutationPoints + familiarData.transmutationBoost;
		this.evocationPoints = this.baseEvocationPoints + familiarData.evocationBoost;
		this.illusionPoints = this.baseIllusionPoints + familiarData.illusionBoost;
		this.destructionPoints = this.baseDestructionPoints + familiarData.destructionBoost;
		this.necromancyPoints = this.baseNecromancyPoints + familiarData.necromancyBoost;
	}

	private void DataToFamiliarStats()
	{
		foreach (PlayerFamiliar.Animals familiarType in System.Enum.GetValues(typeof(PlayerFamiliar.Animals))) {
			if (familiarType.ToString().Equals(familiarData.animalForm))
				familiar.animalForm = familiarType;
		}

		foreach (PlayerFamiliar.Sizes familiarSize in System.Enum.GetValues(typeof(PlayerFamiliar.Sizes))) {
			if (familiarSize.ToString ().Equals (familiarData.animalForm))
				familiar.size = familiarSize;
		}

		familiar.healthPoints = familiarData.healthPoints;
		familiar.attackPoints = familiarData.attackPoints;

		familiar.darkVision = familiarData.darkVision;
		familiar.canClimb = familiarData.canClimb;
		familiar.canFly = familiarData.canFly;
		familiar.keenSmell = familiarData.keenSmell;
		familiar.waterBreathing = familiarData.waterBreathing;

		familiar.healthBoost = familiarData.healthBoost;
		familiar.manaBoost = familiarData.manaBoost;
	}

	private void ResetStats()
	{
		this.healthPoints = this.baseHealthPoints;
		this.manaPoints = this.baseManaPoints;
		this.moralityPoints = this.baseMoralityPoints;
	}

	private void ResetMagicStats()
	{
		this.protectionPoints = this.baseProtectionPoints;
		this.transmutationPoints = this.baseTransmutationPoints;
		this.evocationPoints = this.baseEvocationPoints;
		this.illusionPoints = this.baseIllusionPoints;
		this.destructionPoints = this.baseDestructionPoints;
		this.necromancyPoints = this.baseNecromancyPoints;
	}

	#endregion
}
