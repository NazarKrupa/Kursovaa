using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

    public GameObject[] objects;
    public Transform room;

    private int count;

    public Room Create(int index, Vector2 position, int scaleX, int scaleZ)
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
        newRoom.findHeibor = type.transform.GetChild(0).gameObject;
        newRoom.scale = new Vector3(scaleX, type.transform.localScale.y, scaleZ);
        type.transform.localScale = newRoom.scale;

        type.transform.SetParent(room);

        count++;

        return newRoom;
    }

    public void CreateCorridor(Transform FirstRoom, Transform SecondRoom)
    {
        if (FirstRoom.position.x == SecondRoom.position.x || FirstRoom.position.z == SecondRoom.position.z || Mathf.Abs((FirstRoom.position.x - SecondRoom.position.x))<11 || Mathf.Abs((FirstRoom.position.z - SecondRoom.position.z)) < 11)
        {
            //Находятся на одной линии
            Debug.Log("Находятся на одной линии");
            if (FirstRoom.position.x == SecondRoom.position.x)
            {
                float z = (FirstRoom.position.z + SecondRoom.position.z)/2;

                float s = Mathf.Abs(FirstRoom.position.z - SecondRoom.position.z);


                Vector3 result = new Vector3(FirstRoom.position.x, 0, z);
                GameObject ob = Instantiate(objects[2], result, Quaternion.Euler(0,90,0));
                ob.transform.SetParent(FirstRoom);
                if (s > 30)
                    ob.transform.localScale = new Vector3(2, ob.transform.localScale.y, ob.transform.localScale.z);
            }
            else

            if (FirstRoom.position.z == SecondRoom.position.z)
            {
                float x = (FirstRoom.position.x + SecondRoom.position.x)/2;
                float s = Mathf.Abs(FirstRoom.position.x - SecondRoom.position.x);
                Vector3 result = new Vector3(x, 0, FirstRoom.position.z);
                GameObject ob = Instantiate(objects[2], result, transform.rotation);
                ob.transform.SetParent(FirstRoom);
                if (s > 30)
                    ob.transform.localScale = new Vector3(2, ob.transform.localScale.y, ob.transform.localScale.z);
            }
            else

            if (Mathf.Abs(FirstRoom.position.x - SecondRoom.position.x) < 11)
            {
                float z = (FirstRoom.position.z + SecondRoom.position.z)/2;
                float s = Mathf.Abs(FirstRoom.position.z - SecondRoom.position.z);
                Vector3 result = new Vector3(FirstRoom.position.x, 0, z);
                GameObject ob = Instantiate(objects[2], result, Quaternion.Euler(0, 90, 0));
                ob.transform.SetParent(FirstRoom);
                if (s > 30)
                    ob.transform.localScale = new Vector3(2, ob.transform.localScale.y, ob.transform.localScale.z);
            }
            else

            if (Mathf.Abs(FirstRoom.position.z - SecondRoom.position.z) < 11)
            {
                float x = (FirstRoom.position.x + SecondRoom.position.x) / 2;
                float s = Mathf.Abs(FirstRoom.position.x - SecondRoom.position.x);
                Vector3 result = new Vector3(x,0, FirstRoom.position.z);
                GameObject ob = Instantiate(objects[2], result, transform.rotation);
                ob.transform.SetParent(FirstRoom);
                if (s > 30)
                    ob.transform.localScale = new Vector3(2, ob.transform.localScale.y, ob.transform.localScale.z);
            }

        }
        else
        {
            Debug.Log("need for custom create");
        }
    }


    public void DeleteRoom()
    {
        for (int i = 0; i < room.childCount; i++)
        {
            Destroy(room.GetChild(i).gameObject);
        }
    }
}
