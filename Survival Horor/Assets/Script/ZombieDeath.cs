using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int EnemyHealth = 20;
    private Animator zombieAnimator;
    public int StatusCheck;
    public AudioSource DoorJumpMusic;

    void Start()
    {
        // Get the Animator component from the zombie GameObject
        zombieAnimator = GetComponent<Animator>();

        if (zombieAnimator != null)
        {
            zombieAnimator.Play("Z_Walk_InPlace");
        }
    }

    void Update()
    {
        if(zombieAnimator!= null)
        {
            if (EnemyHealth <= 0 && StatusCheck == 0)
            {
                StatusCheck = 2;
                zombieAnimator.SetTrigger("Die");
                DoorJumpMusic.Stop();
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<ZombieAI>().enabled= false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //EnemyHealth = 0;
                    zombieAnimator.Play("Z_Walk_InPlace");
                }
            }
        }        
    }

    void DamageZombie(int DamageAmount)
    {
       EnemyHealth -= DamageAmount;

    }
}

