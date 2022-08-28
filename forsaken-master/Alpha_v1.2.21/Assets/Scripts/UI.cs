using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text textbox;
    public Text meleeTextbox;
    public Text rangeTextbox;
    public Text scoreTextbox;

    // Start is called before the first frame update
    void Start()
    {
        textbox.GetComponent<Text>();
        meleeTextbox.GetComponent<Text>();
        rangeTextbox.GetComponent<Text>();
        scoreTextbox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Health: " + Player.currentHealth;
        meleeTextbox.text = "" + PlayerCombat.attackDamage;
        rangeTextbox.text = "" + arrowCollision.arrowDamage;
        scoreTextbox.text = "Score: " + Player.score;

    }
}
