using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{

    

    
    [System.Serializable]
    public class BossStats
    {
        public int maxHealth = 1000;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init()
        {
            curHealth = maxHealth;
        }

    }
    public BossStats stats = new BossStats();
    public void TakeDamage(int damage)
    {
        //Can put hit animations in here.
        Debug.Log("You did " +damage);
        stats.curHealth -= damage;
        Debug.Log("Health = " +stats.curHealth);
    }
}
