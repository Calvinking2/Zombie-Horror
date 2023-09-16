using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BFirtsTrigger : MonoBehaviour
{
    public GameObject Player;
    public GameObject TextBox;
    public GameObject Marker;

    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "Looks like a weapon on that table";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = "";
        Player.GetComponent<FirstPersonController>().enabled = true;
        Marker.SetActive(true);
        Destroy(this.gameObject);
    }
}
