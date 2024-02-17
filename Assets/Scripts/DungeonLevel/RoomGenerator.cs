using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGenerator : MonoBehaviour
{
    [SerializeField] public List<RoomList> roomLists;
    [SerializeField] public Transform roomsParent;

    int gridSizeX, gridSizeY, tempGridX, tempGridY;

    public void CreateRoom(Room[,] rooms, List<Vector2> takenPositions, Vector2 worldSize)
    {
        gridSizeX = Mathf.RoundToInt(worldSize.x); // 그리드의 가로 크기
        gridSizeY = Mathf.RoundToInt(worldSize.y); // 그리드의 세로 크기

        for (int i = 0; i < takenPositions.Count; i++)
        {
            tempGridX = (int)takenPositions[i].x + gridSizeX;
            tempGridY = (int)takenPositions[i].y + gridSizeY;

            if (rooms[tempGridX, tempGridY] == null)  return;

            Instantiate(SelectRoom(rooms[tempGridX, tempGridY]), roomsParent);

            Debug.Log(rooms[tempGridX, tempGridY].direction);
        }
    }

    private GameObject SelectRoom(Room room)
    {
        int random = Random.Range(0, roomLists[(int)room.direction].room.Count);
        GameObject selectedRoom = roomLists[(int)room.direction].room[random];
        roomLists[(int)room.direction].room.RemoveAt(random);
        return selectedRoom;
    }
}
