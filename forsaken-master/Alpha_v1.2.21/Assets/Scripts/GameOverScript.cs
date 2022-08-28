using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text youWon;
    public Text youLost;
    // Start is called before the first frame update
    void Start()
    {
        toggleLostOff();
        toggleWonOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowCamera.won)
        {
            //Debug.Log("You won");
            toggleWonOn();
            toggleLostOff();
        }
        if (!FollowCamera.won)
        {
            //Debug.Log("You lost");
            toggleLostOn();
            toggleWonOff();
            
        }
    }
    public void toggleWonOn()
    {
        youWon.enabled = true;
    }

    public void toggleWonOff()
    {
        youWon.enabled = false;
    }

    public void toggleLostOn()
    {
        youLost.enabled = true;
    }

    public void toggleLostOff()
    {
        youLost.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("EnemyTest");
    }
}
