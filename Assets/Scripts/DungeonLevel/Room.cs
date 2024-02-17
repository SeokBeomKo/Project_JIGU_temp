using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Room : MonoBehaviour
{
    public delegate void ChangeRoomHandle(Vector2 direction);
    public event ChangeRoomHandle onChangeRoom;

    [SerializeField] Door UDoor;
    [SerializeField] Door RDoor;
    [SerializeField] Door DDoor;
    [SerializeField] Door LDoor;

    private void Awake() 
    {
        if (UDoor != null) UDoor.onEnterDoor += MoveUpward;
        if (UDoor != null) UDoor.onEnterDoor += MoveRightward;
        if (UDoor != null) UDoor.onEnterDoor += MoveDownward;
        if (UDoor != null) UDoor.onEnterDoor += MoveLeftward;
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
