using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlashCubes : MonoBehaviour
{
    [SerializeField] public bool setPos;
    GameObject cube1;
    GameObject cube2;

    void Start()
    {
        PlaceCubes();
    }

    void Update()
    {
        // On press of 'r' key, turn on mesh renderer for 1 frame
        if (Input.GetKeyDown("r"))
        {
            cube1.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("Cube is at: " + cube1.transform.position);
            cube2.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("Cube is at: " + cube2.transform.position);
        }
        else
        {
            cube1.GetComponent<MeshRenderer>().enabled = false;
            cube2.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Initialize cubes; position
    private void PlaceCubes() 
    {
        cube1 = Instantiate(Resources.Load("Prefabs/CubeT") as GameObject);
        cube2 = Instantiate(Resources.Load("Prefabs/CubeT") as GameObject);

        cube1.GetComponent<MeshRenderer>().enabled = false;
        cube2.GetComponent<MeshRenderer>().enabled = false;

        if (setPos)
        {
            cube1.transform.position = new Vector3(6.6f, 6.7f, 5.7f);
            cube2.transform.position = new Vector3(7.5f, 8.5f, 8.5f);
        }
    }
}
