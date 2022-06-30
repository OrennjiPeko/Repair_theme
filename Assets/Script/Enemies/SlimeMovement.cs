using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float Speed;
    private bool IsRight =true;

    public Animator AnimationMananger;
   

    void Update()
    {
        
        if (IsRight == true)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            AnimationMananger.SetTrigger("RightMovement");
        }
        else if (IsRight == false)
        {
            transform.Translate(-Vector3.right * Speed * Time.deltaTime);
            AnimationMananger.SetTrigger("LeftMovement");
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
    }
}
