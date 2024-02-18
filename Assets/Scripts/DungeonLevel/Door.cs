using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [HideInInspector] public delegate void EnterDoorHandle();
    [HideInInspector] public event EnterDoorHandle onEnterDoor;

    [SerializeField] public Vector3 enterPosition;

    public void Initialize(Vector3 direction)
    {
        enterPosition = transform.position + direction;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            onEnterDoor?.Invoke();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.GetMask("Player"))
        {
            onEnterDoor?.Invoke();
        }
    }
}
