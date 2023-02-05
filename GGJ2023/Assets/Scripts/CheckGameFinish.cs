using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckGameFinish : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerScript>().hasOrb)
            {
                Debug.Log("GAME FINISHED, YOU WON!!!");
                SceneManager.LoadScene("GameWin");
            }
        }
    }
}
