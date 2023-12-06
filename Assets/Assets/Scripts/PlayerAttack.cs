using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    public float meleeSpeed;

    public float damage;

    float timeUntilMelee;

    public AudioSource swordSwing;

    private void Awake()
    {
        anim = GameObject.Find("Sword").GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //animator.SetTrigger("Attack");
            anim.SetTrigger("Attack");
            swordSwing.Play();
            timeUntilMelee = meleeSpeed;
        } else {
            timeUntilMelee -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("Enemy hit");
        }
    }
}

