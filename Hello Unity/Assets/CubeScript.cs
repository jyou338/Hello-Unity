using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public Vector3 spinSpeed = Vector3.zero;
    public float rotateSpeed = 1.0f;
    public Vector3 spinAxis = new Vector3(0, 1, 0);
    private int time;
    private Material material;

	// Use this for initialization
	void Start () {
        spinSpeed = new Vector3(Random.value, Random.value, Random.value);
        spinAxis = Vector3.up;
        spinAxis.x = (Random.value - Random.value) * 0.1f;
    }

    public void SetSize(float size)
    {
        this.transform.localScale = new Vector3(size, size, size);
    }

    public void SetTime(int time)
    {
        StartCoroutine(Example(time));
    }

    public void SetMaterial(Material material)
    {
        this.material = material;
    }

    private void enableMat()
    {
        GetComponent<Renderer>().material = this.material;
    }

    // Update is called once per frame
    void Update () {

        this.transform.Rotate(spinSpeed);
        this.transform.RotateAround(Vector3.zero, spinAxis, rotateSpeed);
	}

    IEnumerator Example(int time)
    {
        yield return new WaitForSeconds(time);
        enableMat();
    }
}
