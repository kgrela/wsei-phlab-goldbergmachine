using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public Animator hammerAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("Book enters Trigger tag");
            hammerAnimator.Play("Hammer_01_Push", 0, 0f);
        }
    }
}
