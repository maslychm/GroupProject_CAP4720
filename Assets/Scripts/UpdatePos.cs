using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePos : MonoBehaviour
{
    GameObject moveableCube;
    Vector4 uLoc;
    Vector4 iLoc;
    Shader shaderCube;
    int sID;
    Renderer rend;

    void Start()
    {
        //GameObject.Find("MoveableCube (1)").transform.position;       
        //Debug.Log(GameObject.Find("MoveableCube (1)"));
        //moveableCube = GameObject.Find("MoveableCube (1)");
        shaderCube = Shader.Find("Custom/CubeColor");
        //sID = shaderCube.PropertyToID("Position");
        rend = GetComponent<Renderer>();
        rend.material.shader = shaderCube;

        Debug.Log(rend.material.shader);
    }

    void Update()
    {
        rend.material.SetVector("_ObjPos", gameObject.transform.position);
        Debug.Log(gameObject.transform.position);
    }
}
