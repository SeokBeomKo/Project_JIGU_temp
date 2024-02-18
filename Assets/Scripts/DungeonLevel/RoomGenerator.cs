using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGenerator : MonoBehaviour
{
    public delegate void TransmitRoomHandle(Room room, Vector2 grid);
    public event TransmitRoomHandle onTransmitRoom;

    [SerializeField] public List<RoomList> roomLists;
    [SerializeField] public Transform roomsParent;
    private List<RoomList> copyLists;

    int gridSizeX, gridSizeY, tempGridX, tempGridY;

    public void CreateRoom(RoomData[,] rooms, List<Vector2> takenPositions, Vector2 worldSize)
    {
        ListCopy();

        gridSizeX = Mathf.RoundToInt(worldSize.x); // 그리드의 가로 크기
        gridSizeY = Mathf.RoundToInt(worldSize.y); // 그리드의 세로 크기

        for (int i = 0; i < takenPositions.Count; i++)
        {
            tempGridX = (int)takenPositions[i].x + gridSizeX;
            tempGridY = (int)takenPositions[i].y + gridSizeY;

            if (rooms[tempGridX, tempGridY] == null)  return;

            Room createdRoom = Instantiate(
                SelectRoom(rooms[tempGridX, tempGridY]), 
                new Vector3((int)takenPositions[i].x * 40, (int)takenPositions[i].y * 40), 
                transform.rotation, 
                roomsParent)
                .GetComponent<Room>();

            onTransmitRoom?.Invoke(createdRoom, new Vector2(tempGridX, tempGridY));
        }
    }

    private GameObject SelectRoom(RoomData room)
    {
        int random = Random.Range(0, copyLists[(int)room.direction - 1].room.Count);
        GameObject selectedRoom = copyLists[(int)room.direction - 1].room[random];
        copyLists[(int)room.direction - 1].room.RemoveAt(random);
        return selectedRoom;
    }

    private void ListCopy()
    {
        copyLists = roomLists.ConvertAll(roomList => roomList.DeepCopy());
    }
}
