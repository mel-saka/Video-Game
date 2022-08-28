using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private PlayerCombat damageScript;
    public float health;
    public GameObject hitBox;

    // Start is called before the first frame update
    void Start()
    {
        damageScript = hitBox.GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
