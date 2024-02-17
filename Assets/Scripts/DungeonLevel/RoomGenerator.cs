using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGenerator : MonoBehaviour
{
    [SerializeField] public List<RoomArray> roomListArray;

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

            Debug.Log(rooms[tempGridX, tempGridY]);
        }
    }
}
