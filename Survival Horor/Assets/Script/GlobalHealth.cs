using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHealth : MonoBehaviour
{
    public static int currentHealth = 20;
    public int InternalHealth = 0;
    void Update()
    {
        InternalHealth= currentHealth;
    }
}
