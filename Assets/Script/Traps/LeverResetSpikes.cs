using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverResetSpikes : MonoBehaviour
{

    public GameObject RoofSpikes;
    public Transform ReturnPosition;
    private float speed = 1;
    bool IsActivated;
    public GameObject SpriteLeverRight;
    public GameObject SpriteLeverLeft;

    // Update is called once per frame
    void Update()
    {
        if (IsActivated)
        {
            float step = speed * Time.deltaTime;
            RoofSpikes.transform.position = Vector3.MoveTowards(RoofSpikes.transform.position, ReturnPosition.position, step);
        }
    }

    public void PullLever()
    {
        IsActivated = true;
        SpriteLeverRight.SetActive(false);
        SpriteLeverLeft.SetActive(true);
    }
}
