using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlatform : MonoBehaviour
{

    bool HasBlock = false;
    public GameObject CorrectPlatform;
    bool Corrected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MoveableBlock" && (!HasBlock) && !Corrected)
        {
            other.transform.position = this.transform.position;
            other.transform.parent = this.transform;
            HasBlock = true;
            if (other.gameObject == CorrectPlatform)
                other.tag = "Finished"; Corrected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "MoveableBlock" && HasBlock && !Corrected)
        {
            HasBlock = false;
        }
    }
}
