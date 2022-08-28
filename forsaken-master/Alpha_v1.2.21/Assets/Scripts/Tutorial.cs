using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	
	public Transform followTransform;
	public Player player;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

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
	}
}
