using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class FollowCamera : MonoBehaviour
{
	bool gameOver = false;
	public Transform followTransform;
	public Player player;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public static bool won;

	void OnMouseEnter()
    {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);   
    }
	void onMouseExit()
    {
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    // Use this for initialization
    void Start()
	{
		OnMouseEnter();
	}

	// Update is called once per frame
	void Update()
	{
		if (GameObject.FindWithTag("Player") != null)
        {
			this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        }
        else
        {
			//Needs to be set to another position, maybe Game Over screen
			this.transform.position = new Vector3(0, 0, 0);
			gameOver = true;
			Debug.Log("Game Over!");
			
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {

			SceneManager.LoadScene("MainMenu");
		}
		//if(won == true)
  //      {
		//	SceneManager.LoadScene("GameOver");
  //      }
	}
    void OnGUI()
    {
        if (!gameOver) 
        {
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;

        }
        else
        {
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		}
		GUI.skin.label.fontSize = 20;

		//GUI.Label(new Rect(15, 280, 300, 200), "Score: " + Player.score);

		//GUI.skin.label.alignment = TextAnchor.LowerRight;
		//GUI.skin.label.fontSize = 20;
  //      if (!gameOver)
  //      {
		//	/*GUI.Label(new Rect(Screen.width / 2, (Screen.height/2)+50, 300, 100), "Soul Switches: " + SoulSwitch.soulSwitches);*/
		//	GUI.skin.label.alignment = TextAnchor.LowerLeft;
		//	GUI.Label(new Rect(Screen.width / 2, 100, 300, 200), "Melee Damage: " + PlayerCombat.attackDamage + "\nRanged Damage: " + arrowCollision.arrowDamage);
		//}

		if (gameOver)
        {
			won = false;
			SceneManager.LoadScene("GameOver");
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.fontSize = 50;
			GUI.Label(new Rect(200, Screen.height/2, 400, 150), "Game Over!...");
			GUI.Label(new Rect(200, Screen.height / 2, 400, 350), "Press Enter to play again");
		}
    }
}