using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool MovingFromStart;
    private bool IsMoving;
    public float Speed;
    private bool IsRight = true;

    public Transform LeftWall;
    public Transform RightWall;

    // Start is called before the first frame update
    void Start()
    {
        if (MovingFromStart)
            IsMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            if (IsRight == true)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, RightWall.position, Speed * Time.deltaTime);
            }
            else if (IsRight == false)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, LeftWall.position, Speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RightWall")
        {
            IsRight = false;
        }
        if (other.tag == "LeftWall")
        {
            IsRight = true;
        }

        if(other.tag == "Player")
        {
            other.transform.SetParent(this.transform);
            GetComponent<BoxCollider>().size = new Vector3(2, 2, 2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
            GetComponent<BoxCollider>().size = new Vector3(1, 1.7f, 1);
        }
    }
}
