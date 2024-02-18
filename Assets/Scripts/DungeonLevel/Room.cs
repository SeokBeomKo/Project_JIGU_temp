using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Room : MonoBehaviour
{
    public delegate void ChangeRoomHandle(Vector2 direction);
    public event ChangeRoomHandle onChangeRoom;

    [SerializeField] public Door UDoor;
    [SerializeField] public Door RDoor;
    [SerializeField] public Door DDoor;
    [SerializeField] public Door LDoor;

    private void Awake() 
    {
        if (UDoor != null) UDoor.onEnterDoor += MoveUpward;
        if (RDoor != null) RDoor.onEnterDoor += MoveRightward;
        if (DDoor != null) DDoor.onEnterDoor += MoveDownward;
        if (LDoor != null) LDoor.onEnterDoor += MoveLeftward;

        if (UDoor != null) UDoor.Initialize(Vector2.down);
        if (RDoor != null) RDoor.Initialize(Vector2.left);
        if (DDoor != null) DDoor.Initialize(Vector2.up);
        if (LDoor != null) LDoor.Initialize(Vector2.right);
    }

    public void MoveUpward()
    {
        onChangeRoom?.Invoke(Vector2.up);
    }

    public void MoveRightward()
    {
        onChangeRoom?.Invoke(Vector2.right);
    }

    public void MoveDownward()
    {
        onChangeRoom?.Invoke(Vector2.down);
    }

    public void MoveLeftward()
    {
        onChangeRoom?.Invoke(Vector2.left);
    }
}
