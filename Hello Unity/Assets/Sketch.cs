using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : MonoBehaviour {

    public GameObject myPrefab;
    public Material myMaterial;

	void Start () {
        int totalCubes = 30;
        float totalDistance = 2.9f;

        // Sin 
        for (int i = 0; i < totalCubes; i++)
        {
            float perc = i / (float)totalCubes;

            float sin = Mathf.Sin(perc * Mathf.PI/2);

            float x = 1.8f + sin * totalDistance;
            float y = 5.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<CubeScript>().SetTime(i);
            newCube.GetComponent<CubeScript>().SetSize(0.45f * (1.0f - perc));
            newCube.GetComponent<CubeScript>().rotateSpeed = 0.2f + perc*4.0f;
            newCube.GetComponent<CubeScript>().SetMaterial(myMaterial);
        }

    }
	
	void Update () {
		
	}
}
