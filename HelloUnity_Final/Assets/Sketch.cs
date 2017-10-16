using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefabCube;
    public GameObject myPrefabSphere;
    public string _WebsiteURL = "http://infomgmt192.azurewebsites.net/tables/Products?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Mountain[] mountains = JsonReader.Deserialize<Mountain[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL

        int i = 0;
        int totalCubes = 30;
        float totalDistance = 2.9f;
        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (Mountain mountain in mountains)
        {
            //Example of how to use the object
            Debug.Log("This mountains name is: " + mountain.MountainName);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            float perc = i / (float)totalCubes;
            float sin = Mathf.Sin(perc * Mathf.PI / 2);

            float x = mountain.X;
            float y = mountain.Y;
            float z = mountain.Z;

            var newSymbol = (GameObject)Instantiate(myPrefabCube, new Vector3(x, y, z), Quaternion.identity);
            if (mountain.Symbol == "Sphere")
            {
                Destroy(newSymbol);
                newSymbol = (GameObject)Instantiate(myPrefabSphere, new Vector3(x, y, z), Quaternion.identity);
            }

            newSymbol.GetComponent<CubeScript>().SetSize(.3f * (mountain.Size));
            newSymbol.GetComponent<CubeScript>().rotateSpeed = 0;
            newSymbol.transform.Find("New Text").GetComponent<TextMesh>().text = mountain.MountainName;//"Hullo Again";
            i++;

            //----------------------
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
