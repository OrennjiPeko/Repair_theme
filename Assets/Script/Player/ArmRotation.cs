using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    bool ArmUp;
    bool ArmRight;
    bool ArmLeft;
    public SpriteRenderer CharacterSprite;
    public Sprite RightArm;
    public Sprite LeftArm;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            CharacterSprite.sprite = RightArm;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
           

        if (Input.GetKeyDown(KeyCode.A))
        {
            CharacterSprite.sprite = LeftArm;
            this.transform.rotation = Quaternion.Euler(0, 0, -180);
        }
            
    }
}
