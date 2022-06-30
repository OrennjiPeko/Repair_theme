using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    float DropDownSpeed = 1;
    public Transform EndLocation;
    public Transform StartLocation;

    public bool ActivateImmediatly;
    private bool FinishedDecent;

    private bool GoBackToStart;
    private bool HeadToEndPoint;

    public GameObject ItemToMove;
    public Transform ItemEndLocation;

    // Update is called once per frame
    void Update()
    {
        if(GoBackToStart)
            this.transform.position = Vector3.MoveTowards(this.transform.position, StartLocation.position, DropDownSpeed * Time.deltaTime);

        if(HeadToEndPoint)
            this.transform.position = Vector3.MoveTowards(this.transform.position, EndLocation.position, DropDownSpeed * Time.deltaTime);

        if (this.transform.position == EndLocation.position)
            FinishedDecent = true; 

        if (this.transform.position == StartLocation.position)
            GoBackToStart = false;

        if(FinishedDecent)
            ItemToMove.transform.position = Vector3.MoveTowards(ItemToMove.transform.position, ItemEndLocation.position, 5f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HeadToEndPoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !FinishedDecent && !ActivateImmediatly)
            StartCoroutine(BeforeBackToStart());
    }

    IEnumerator BeforeBackToStart()
    {
        yield return new WaitForSeconds(0.5f);
        if (!FinishedDecent)
        {
            HeadToEndPoint = false;
            GoBackToStart = true;
        }
    }
}
