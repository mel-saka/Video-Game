using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorials;
    private int tutorialIndex;
    private void Update()
    {
        for(int i = 0; i < tutorials.Length; i++)
        {
            if(i == tutorialIndex)
            {
                tutorials[tutorialIndex].SetActive(true);
            } else
            {
                tutorials[tutorialIndex].SetActive(false);
            }
        }

        if(tutorialIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                tutorialIndex++;
            }
        } else if (tutorialIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                tutorialIndex++;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            SceneManager.LoadScene("TutorialOver");
        }
        if(GameObject.FindGameObjectWithTag("Enemy") == false)
        {
            SceneManager.LoadScene("TutorialOver");
        }
    }
}
