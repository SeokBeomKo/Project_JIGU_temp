using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomList : MonoBehaviour
{
    public List<GameObject> room;

    public RoomList DeepCopy()
    {
        RoomList copy = (RoomList) this.MemberwiseClone();
        copy.room = new List<GameObject>(this.room);
        return copy;
    }
}
