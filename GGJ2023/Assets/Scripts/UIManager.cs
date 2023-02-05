using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] TMP_Text ammo;
	[SerializeField] TMP_Text kills;

	[SerializeField] GameObject endGame;

	int killCount = 0;
	int Mana = 0;

	public static UIManager instance
	{
		get;
		private set;
	}

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}
	}

	public void SetAmmoGUI(int cur, int max)
    {
		ammo.text = "Ammo: " + cur + "/" + max;
    }

	public void SetKillGUI()
	{
		killCount++;
		//endGame.SetKills();
		kills.text = killCount.ToString();
	}

	public void AddMana()
    {
		Mana++;
    }

	public int GetMana()
    {
		return Mana;
    }

	public void RemoveMana(int cost)
    {
		Mana -= cost;
    }
}
