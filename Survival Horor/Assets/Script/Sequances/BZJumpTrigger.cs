using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZJumpTrigger : MonoBehaviour
{
    public AudioSource DoorBang;
    public AudioSource DoorJumpMusic;

    public GameObject Zombie;
    public GameObject TheDoor;

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpDoorAnim");
        DoorBang.Play();
        Zombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());


    }
    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        DoorJumpMusic.Play();
    }
}
