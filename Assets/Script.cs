using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has touched the door.");
        }
    }
}
