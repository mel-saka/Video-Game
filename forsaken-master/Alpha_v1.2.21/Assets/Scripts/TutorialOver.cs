using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialOver : MonoBehaviour
{
    public float timeRemaining = 4;

    // Update is called once per frame
    void Update()
    {
       if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } else
        {
            SceneManager.LoadScene("EnemyTest");
        }
    }
}
