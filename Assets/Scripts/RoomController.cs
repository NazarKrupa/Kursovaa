using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {

    List<Room> rooms = new List<Room>();
    public bool normalPosition;
    public Genereator generator;

    private void Start()
    {
    }


    public void SetRoom(List<Room> rooms)
    {
        this.rooms = rooms;
    }


    public void DoneMovePlatform(int id)
    {
        rooms[id].position = rooms[id].objectT.transform.position;
        rooms[id].lastPosition = true;

        if(!normalPosition)
        CheckDone();
    }


    public void CheckDone()
    {
        int roomDone = 0;
        int noNei = 0;
        int stopmove = 0;
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].lastPosition == true)
            {
                roomDone++;
            }

            if (rooms[i].objectT.GetComponent<Streache>().nei.Count == 0)
            {
                noNei++;
            }

            if (rooms[i].objectT.GetComponent<Streache>().stop == true)
            {
                stopmove++;
            }
        }




        if (roomDone == rooms.Count && noNei == rooms.Count && stopmove == rooms.Count)
        {
            normalPosition = true;
            Debug.Log("LastPosition" + roomDone + " " + rooms.Count);
            List<Vector3> position = new List<Vector3>();
            for (int i = 0; i < rooms.Count; i++)
            {
                position.Add(rooms[i].position);
            }

            generator.DrawCorridor();


            List<Vector2> data = new List<Vector2>();

            for (int i = 0; i < rooms.Count; i++)
            {
                Vector3 positionRoom = rooms[i].position;
                data.Add(new Vector2(positionRoom.x, positionRoom.z));
            }


            data = Triangulation.GetVertices(data);


            List<Triangle> triangles = new List<Triangle>();
            List<Vector3> point = new List<Vector3>();
            int countIt = 0;

            for (int i = 0; i < data.Count; i++)
            {
                countIt++;
                point.Add(new Vector3(data[i].x, 0, data[i].y));
                //Debug.Log(point[i]);

                if (countIt == 3)
                {
                    //Debug.Log("Count point" + triangle.points);
                    Triangle triangle = new Triangle(point);

                    triangles.Add(triangle);
                    triangle = null;
                    countIt = 0;
                }
            }

            //DrawTriangle(triangles);
        }
    }

    void DrawTriangle(List<Triangle> triangle)
    {
        Debug.DrawLine(triangle[0].points[0], triangle[0].points[1], Color.green, 2, false);
        Debug.DrawLine(triangle[0].points[1], triangle[0].points[2], Color.green, 2, false);
        Debug.DrawLine(triangle[0].points[0], triangle[0].points[2], Color.green, 2, false);

        Debug.DrawLine(triangle[1].points[0], triangle[1].points[1], Color.red, 2, false);
        Debug.DrawLine(triangle[1].points[1], triangle[1].points[2], Color.red, 2, false);
        Debug.DrawLine(triangle[1].points[0], triangle[1].points[2], Color.red, 2, false);
    }
}
