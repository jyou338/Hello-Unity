using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Make sure you get rid of the namespace that is automatically generated here.
public class Mountain
{
    //List all the columns of your table here in the same format as below.
    public string id { get; set; }
    public string createdAt { get; set; }
    public string updatedAt { get; set; }
    public string version { get; set; }
    public int MountainId { get; set; }
    public string MountainName { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float Size { get; set; }
    public string Symbol { get; set; }
    public bool deleted { get; set; }
}
