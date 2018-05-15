using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

    public GameObject[] objects;
    public Transform room;

    private int count;

    public Room Create(int index, Vector2 position, Vector2 scale)
    {
        GameObject ob;
        Room newRoom =  new Room();
        ob = objects[index];


        newRoom.id = count;
        newRoom.position = new Vector3(position.x, 0, position.y);

        GameObject type = Instantiate(ob, newRoom.position, transform.rotation);
        Streache roomS = type.GetComponent<Streache>();

        if (roomS != null)
        {
            roomS.id = count;
        }

        newRoom.objectT = type;
        newRoom.scale = new Vector3(scale.x, type.transform.localScale.y, scale.y);
        type.transform.localScale = newRoom.scale;

        type.transform.SetParent(room);

        count++;

        return newRoom;
    }

    public void CreateCorridor(Transform FirstRoom, Transform SecondRoom)
    {

    }


    public void DeleteRoom()
    {
        for (int i = 0; i < room.childCount; i++)
        {
            Destroy(room.GetChild(i).gameObject);
        }
    }
}
