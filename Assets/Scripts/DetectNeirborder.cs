using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectNeirborder : MonoBehaviour {

    public List<GameObject> nei = new List<GameObject>();

    private void Update()
    {
        if (nei.Count > 0)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        nei.Add(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
