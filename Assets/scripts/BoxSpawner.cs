using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject[] boxPrefabs;

   /* void Start()
    {
        SpawnBox();
    }*/

    public void SpawnBox()
    {
        if (boxPrefabs.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, boxPrefabs.Length);
        GameObject boxObj = Instantiate(boxPrefabs[randomIndex]);

        Vector3 temp = transform.position;
        temp.z = 0f;

        boxObj.transform.position = temp;
    }

    void Update()
    {
        // Add any necessary update logic here
    }
}
