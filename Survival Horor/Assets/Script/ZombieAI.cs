using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public Animator zombieAnimator;
    public float enemySpeeed = 0.01f;
    public bool attackTrigger = false;
    public bool isAttacking = false;

    void Update()
    {
        transform.LookAt(Player.transform);
        if(attackTrigger == false)
        {
            enemySpeeed= 0.01f;
            //Enemy.GetComponent<Animator>().Play("Z_Walk_InPlace");
            zombieAnimator.SetTrigger("Walk");
            transform.position = Vector3.MoveTowards(transform.position,Player.transform.position,enemySpeeed);
        }
        if(attackTrigger == true && isAttacking == false) 
        {
            Debug.Log("Atack");
            enemySpeeed = 0;
            //Enemy.GetComponent<Animator>().Play("Z_Attack");
            zombieAnimator.SetTrigger("Attack");
            StartCoroutine(InflictDamage());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        attackTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        attackTrigger = false;
    }
    IEnumerator InflictDamage()
    {
        isAttacking= true;
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;
        yield return new WaitForSeconds(0.2f);
        isAttacking= false;
    }
}
    