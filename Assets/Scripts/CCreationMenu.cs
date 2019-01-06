using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CCreationMenu : MonoBehaviour {

	// VARIABLES

	[Header("Input Fields")]
	public TMP_InputField playerNameField;
	public TMP_InputField familiarNameField;
	public TMP_Dropdown familiarFormDropdown;

	private Player player;
	public static bool loading = false;

	// EXECUTION METHODS

	private void Awake()
	{
		player = FindObjectOfType<Player> ();
	
		familiarFormDropdown.onValueChanged.AddListener(delegate {
			player.SetFamiliarForm(familiarFormDropdown.options[familiarFormDropdown.value].text);
		});
	}

	private void Update()
	{
		if (loading)
		{
			playerNameField.text = player.playerName;
			familiarNameField.text = player.familiar.familiarName;

			foreach (TMP_Dropdown.OptionData option in familiarFormDropdown.options) {
				if (option.text == player.familiar.animalForm.ToString ())
					familiarFormDropdown.value = familiarFormDropdown.options.IndexOf (option);
			}

			loading = false;
		}
	}
}
