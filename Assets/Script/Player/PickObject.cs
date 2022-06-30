using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{

    private GameObject PickedUpItem;
    private bool GrabbedItem;

    private bool ReachedUp;
    private bool IsLeft;
    private bool InFront = true;


    public Transform UpHandPosition;
    public Transform RightHandPosition;
    public Transform LeftHandPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && GrabbedItem)
        {
            PickedUpItem.transform.parent = null;
            GrabbedItem = false;
        }

        if(Input.GetKeyDown(KeyCode.W) && !ReachedUp)
        {
            this.transform.position = UpHandPosition.position;
            if (PickedUpItem)
                PickedUpItem.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.25f, this.transform.position.z);
            ReachedUp = true;
            InFront = false;
            IsLeft = false;
        }
        
        if (Input.GetKeyDown(KeyCode.D) && !InFront)
        {
            this.transform.position = RightHandPosition.position;
            if (PickedUpItem)
                PickedUpItem.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y, this.transform.position.z);
            ReachedUp = false;
            IsLeft = false;
            InFront = true;
        }

        if(Input.GetKeyDown(KeyCode.A) && !IsLeft)
        {
            this.transform.position = LeftHandPosition.position;
            if (PickedUpItem)
                PickedUpItem.transform.position = new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0);
            ReachedUp = false;
            InFront = false;
            IsLeft = true;
        }

        if(transform.childCount <= 0)
        {
            PickedUpItem = null;
            GrabbedItem = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GrabbedItem == false)
        {
            if (other.tag == "MoveableBlock")
            {
                other.transform.parent = this.transform;
                PickedUpItem = other.gameObject;
                PickedUpItem.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y, this.transform.position.z);
                GrabbedItem = true;
            }
        }
    }
}
