using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : MonoBehaviour {

    public GameObject myPrefab1;
    public GameObject myPrefab2;
    public Material myMaterial;

	void Start () {
        int totalPrefabs = 30;
        float totalDistance = 2.9f;

        for (int i = 0; i < totalPrefabs; i++)
        {
            float perc = i / (float)totalPrefabs;

            float sin = Mathf.Sin(perc * Mathf.PI / 2);

            float x = 1.8f + sin * totalDistance;
            float y = 5.0f;
            float z = 0.0f;

            if (i % 2 == 0) { 
                var newCube = (GameObject)Instantiate(myPrefab1, new Vector3(x, y, z), Quaternion.identity);
                //newCube.GetComponent<CubeScript>().SetTime(i);
                newCube.GetComponent<CubeScript>().SetSize(0.45f * (1.0f - perc));
                newCube.GetComponent<CubeScript>().rotateSpeed = 0.2f + perc*4.0f;
               //newCube.GetComponent<CubeScript>().SetMaterial(myMaterial);
            } else
            {
                var newCube = (GameObject)Instantiate(myPrefab2, new Vector3(x, y, z), Quaternion.identity);
                //newCube.GetComponent<CubeScript>().SetTime(i);
                newCube.GetComponent<CubeScript>().SetSize(0.45f * (1.0f - perc));
                newCube.GetComponent<CubeScript>().rotateSpeed = 0.2f + perc * 4.0f;
                //newCube.GetComponent<CubeScript>().SetMaterial(myMaterial);
            }
        }

    }
	
	void Update () {
		
	}
}
