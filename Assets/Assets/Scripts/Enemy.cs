using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float MaxHitPoints = 5;
    public LevelBar levelBar;
    private Animator animator;
    public AudioSource enemyDeathSound;
  
    


    void Start()
    {
        health = MaxHitPoints;
        
    }

    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0f)
        {
            enemyDeathSound.Play();
            Death();
            EnemyDeath();
        }
    }

    public void Death()
    {
        
        animator = GameObject.Find(gameObject.name).GetComponent<Animator>();
        animator.SetBool("isDead", true);
        
        
    }

    public void EnemyDeath()
    {
        LevelManager levelManager = LevelManager.instance;
        
        if (levelManager != null) {
            levelManager.AddEXP(20);
            
            Debug.Log(levelManager.pts);
        }
        Destroy(gameObject, 1f);
        Debug.Log(gameObject.name + "Died");

    }
}
