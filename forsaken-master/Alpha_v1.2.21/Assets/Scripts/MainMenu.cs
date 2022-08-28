using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("EnemyTest");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // Display main menu message
    void OnGUI()
    {
        GUI.color = Color.white;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 40;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        //GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Press any key to start");
    }
}
