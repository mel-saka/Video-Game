using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontdestroyaudio : MonoBehaviour
{
 
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
