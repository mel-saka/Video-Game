using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoulSwitch : MonoBehaviour
{
    public bool isInRange;

    /*public static int soulSwitches = 1;*/


    void Update()
    {

        if (isInRange) //If in range to soulswitch
        {
            //Something to indicate to the player that you are in range of soulswitch

            /*if (soulSwitches > 0) //If we have soul switches left
            {*/
                if (Input.GetKeyDown(KeyCode.E)) //If soul switch key is pressed
                {
                SoundManagerScript.PlaySound("soulswitch");
                if (gameObject.CompareTag("MedusaSS"))
                    {
                        Debug.Log("Soul switching with medusa");
                        //FollowCamera.singleton.onMouseEnterBow();
                        Player.toggleBowOn();
                        Player.toggleSwordOff();

                        Destroy(gameObject);    //Delete prefab of powerup

                        //Add effects for soul switching
                        Player.currentHealth += 10;
                        arrowCollision.arrowDamage += 2;
                    }
                    else if (gameObject.CompareTag("MinotaurSS"))
                    {
                        Debug.Log("Soul switching with minotaur");
                       
                        Player.toggleBowOff();
                        Player.toggleSwordOn();


                        Destroy(gameObject);    //Delete prefab of powerup
                        //Add effects for soul switching
                        Player.currentHealth += 10;
                        PlayerCombat.attackDamage += 2;
                    }
                    //Have to cut down on enemies
                    //else if (gameObject.CompareTag("SpartanSS"))
                    //{
                    //    Debug.Log("Soul switching with spartan");



                    //    Destroy(gameObject);    //Delete prefab of powerup
                    //    //Add effects for soul switching
                    //    Player.currentHealth = 100;
                    //}
                    /*soulSwitches -= 1;*/

                }
            /*}*/

        }
        Destroy(GameObject.FindWithTag("MedusaSS"), 5);
        Destroy(GameObject.FindWithTag("MinotaurSS"), 5);


}



    /*void onGUI()
    {
        GUI.color = Color.red;
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUI.skin.label.fontSize = 40;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(20, 20, 500, 100), "Switches: " + SoulSwitch.soulSwitches);
    }*/



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;


            // Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            // Debug.Log("Player is not in range");
        }
    }
}
