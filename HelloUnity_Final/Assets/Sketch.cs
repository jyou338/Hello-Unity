using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    // Setting public variables that can be changed on the front end in Unity
    public GameObject myPrefabCube;
    public GameObject myPrefabSphere;
    public string _WebsiteURL = "http://infomgmt192.azurewebsites.net/tables/Products?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL); // get request that gets data from api and returns as a string

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        // Stops code if the json is null or empty
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        // Deserializes string of data into and array of objects
        Mountain[] mountains = JsonReader.Deserialize<Mountain[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL


        int i = 0; // Counter used for iterating as we are not using a for loop
        int totalCubes = 30; 
        float totalDistance = 2.9f;
        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (Mountain mountain in mountains) // foreach loop iterates through each item in the array and each item is assigned as mountain
        {
            //Example of how to use the object
            // Logs the mountain name to the console
            Debug.Log("This mountains name is: " + mountain.MountainName);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            float perc = i / (float)totalCubes;
            float sin = Mathf.Sin(perc * Mathf.PI / 2);

            // Assigning x, y, and z values to variables from the mountain object
            float x = mountain.X;
            float y = mountain.Y;
            float z = mountain.Z;

            // Creates a cube prefab
            var newSymbol = (GameObject)Instantiate(myPrefabCube, new Vector3(x, y, z), Quaternion.identity);
            if (mountain.Symbol == "Sphere") // Enters this block of code if the mountain symbol is sphere
            {
                // Destroy the cube object and creates a sphere object
                Destroy(newSymbol);
                newSymbol = (GameObject)Instantiate(myPrefabSphere, new Vector3(x, y, z), Quaternion.identity);
            }

            // Sets the size and rotation speed via a method in the CubeScript
            newSymbol.GetComponent<CubeScript>().SetSize(.3f * (mountain.Size));
            newSymbol.GetComponent<CubeScript>().rotateSpeed = 0;

            // Finds the value "New Text" under the cube or sphere that is a text mesh and sets the text to the mountain name
            newSymbol.transform.Find("New Text").GetComponent<TextMesh>().text = mountain.MountainName;
            i++;

            //----------------------
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
