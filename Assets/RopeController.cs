using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public bool setActive;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "rope")
        {
            other.GetComponent<MeshRenderer>().enabled = setActive;
            //other.gameObject.SetActive(setActive);
            //
            
        }
    }
}
