using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Witchcraft/Spell", fileName = "New Spell")]
public class Spell : ScriptableObject {

	public enum Schools
	{
		Protection,
		Transmutation,
		Evocation,
		Illusion,
		Destruction,
		Necromancy
	}

	public enum Targets
	{
		Self,
		Party,
		Enemies,
		Environment
	}

	public Schools schoolOfMagic;
	public Targets target;
}
