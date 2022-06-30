using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBones : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnBones;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            Player.transform.position = respawnBones.transform.position;
        }
       
    }
}
