using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour {

    public List<Vector3> points = new List<Vector3>();

    public Triangle(List<Vector3> points)
    {
        this.points = points;

    }
}
