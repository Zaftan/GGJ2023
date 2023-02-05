using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] TMP_Text end;
    bool win = false;
    int kills = 0;

    void TriggerGameEnd()
    {
        SetText();
    }

    void SetText()
    {
        if(win)
        {
            end.text = "You saved the forest! \n" + "Your killed " + kills + " eldritch beings";
        }
        else
        {
			end.text = "The forest died.. \n" + "Your effort killed " + kills + " eldritch beings";
		}
    }

	void YouWin()
	{
		win = true;
	}

    void SetKills()
    {
        kills++;
    }
}
