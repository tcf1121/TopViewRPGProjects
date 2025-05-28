using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToDungeon : MonoBehaviour
{
    public Vector2Int DungeonPos = new();
    public DungeonPlayer DungeonPlayer;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            if (other.gameObject.GetComponent<Door>().RoomPos != DungeonPos)
            {
                DungeonPos = other.gameObject.GetComponent<Door>().RoomPos;
                DungeonPlayer.ChangeRoom(DungeonPos);
            }
        }
    }
}
