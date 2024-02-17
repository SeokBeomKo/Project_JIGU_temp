using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData
{
  public Vector2 gridPosition;
  public RoomType type;

  public Directions direction;

  public RoomData(Vector2 _gridPos, RoomType _type)
  {
		gridPosition = _gridPos;
		type = _type;
	}
}
