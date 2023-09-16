using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
//using UnityStandardAssets.Characters.FirtsPerson;

public class AOpening : MonoBehaviour
{
    public GameObject Player;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public GameObject PlayerCamera;
    void Start()
    {
        TextBox.GetComponent<Text>().text = "";
        FadeScreenIn.SetActive(true);
        Player.GetComponent<FirstPersonController>().enabled = false;
        PlayerCamera.GetComponent<CameraSetting>().enabled= false;
        StartCoroutine(ScenePlayer());
    }
    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "Where am i ?";
        yield return new WaitForSeconds(1.5f);
        TextBox.GetComponent<Text>().text = "I need to get out from here";
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<Text>().text = "";
        Player.GetComponent<FirstPersonController>().enabled = true;
        PlayerCamera.GetComponent<CameraSetting>().enabled = true;
    }


}
