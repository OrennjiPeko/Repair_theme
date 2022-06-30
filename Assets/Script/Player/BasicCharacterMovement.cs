using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacterMovement : MonoBehaviour
{
    CharacterController Player;
    Vector2 Movement;

    [HideInInspector]public float speed = 5f;
    [HideInInspector]public float JumpSpeed = 20f;
    [HideInInspector]public float gravity = 1f;

    public Animator Animations;



    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Player.isGrounded)
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), 0);
            Movement *= speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Input.GetKey(KeyCode.D))
                    Animations.SetTrigger("JumpRight");

                if (Input.GetKey(KeyCode.A))
                    Animations.SetTrigger("JumpLeft");

                Movement.y = JumpSpeed;
            }
        }

        Movement.y -= gravity + Time.deltaTime;

        Player.Move(Movement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D) && Player.isGrounded)
            Animations.SetTrigger("RightWalk");

        if (Input.GetKeyDown(KeyCode.A) && Player.isGrounded)
            Animations.SetTrigger("LeftWalk");

        if (Input.GetKeyUp(KeyCode.D) && Player.isGrounded)
            Animations.SetTrigger("Idle");

        if (Input.GetKeyUp(KeyCode.A) && Player.isGrounded)
            Animations.SetTrigger("Idle_Left");

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Lever" && Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<LeverResetSpikes>().PullLever();
        }
    }
}
