using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DungeonCenter : MonoBehaviour
{
    [SerializeField] public LevelGenerator levelGenerator;
    [SerializeField] public RoomGenerator roomGenerator;

    [SerializeField] public RoomData[,] rooms;
    [SerializeField] public List<Vector2> takenPositions = new List<Vector2>();

    [Header("월드 크기 (반지름)")]
    [SerializeField] public Vector2 worldSize;
    [Header("방 개수")]
    [SerializeField] public int numberOfRooms;

    private Vector2 curRoomIndex;

    public GameObject tempPlayer;

    public Room[,] roomsGrid;
    

    private void Awake() 
    {
        roomsGrid = new Room[(int)worldSize.x * 2, (int)worldSize.y * 2];

        levelGenerator.OnGeneratedLevel += CreateRooms;

        levelGenerator.numberOfRooms = numberOfRooms;
        levelGenerator.worldSize = worldSize;

        roomGenerator.onTransmitRoom += AddRoom;
    }

    private void SettingPlayer(Vector2 position)
    {
        tempPlayer.transform.position = position;
    }

    private void CreateRooms(RoomData[,] roomValue, List<Vector2> posValue)
    {
        rooms = roomValue;
        takenPositions = posValue;

        roomGenerator.CreateRoom(rooms, takenPositions, worldSize);
    }

    private void AddRoom(Room room, Vector2 grid)
    {
        room.onChangeRoom += MoveRoom;

        Debug.Log(grid);
        roomsGrid[(int)grid.x,(int)grid.y] = room;

        curRoomIndex = grid;
    }

    private void MoveRoom(Vector2 direction)
    {
        // curRoomIndex += direction;

        Debug.Log(curRoomIndex + direction);

        if (direction == Vector2.up)        
        {
            SettingPlayer(roomsGrid[(int)curRoomIndex.x + (int)direction.x, (int)curRoomIndex.y + (int)direction.y].DDoor.enterPosition);
            curRoomIndex += direction;
        }
        if (direction == Vector2.right)     
        {
            SettingPlayer(roomsGrid[(int)curRoomIndex.x + (int)direction.x, (int)curRoomIndex.y + (int)direction.y].LDoor.enterPosition);
            curRoomIndex += direction;
        }
        if (direction == Vector2.down)      
        {
            SettingPlayer(roomsGrid[(int)curRoomIndex.x + (int)direction.x, (int)curRoomIndex.y + (int)direction.y].UDoor.enterPosition);
            curRoomIndex += direction;
        }
        if (direction == Vector2.left)      
        {
            SettingPlayer(roomsGrid[(int)curRoomIndex.x + (int)direction.x, (int)curRoomIndex.y + (int)direction.y].RDoor.enterPosition);
            curRoomIndex += direction;
        }


        Debug.Log(direction);
    }
}
