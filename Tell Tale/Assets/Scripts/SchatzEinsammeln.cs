using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchatzEinsammeln : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}