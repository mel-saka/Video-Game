using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmMove : MonoBehaviour

{

    public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) //Left facing helm
        {
            GetComponent<SpriteRenderer>().sprite = spriteArray[1];
        }
        if (Input.GetKeyDown(KeyCode.A)) //Right facing helm
        {
            GetComponent<SpriteRenderer>().sprite = spriteArray[0];
        }
    }
}
