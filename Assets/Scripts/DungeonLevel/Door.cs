using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public delegate void EnterDoorHandle();
    public event EnterDoorHandle onEnterDoor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.GetMask("Player"))
        {
            onEnterDoor?.Invoke();
        }
    }
}
