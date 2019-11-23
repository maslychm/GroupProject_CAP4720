using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosShader : MonoBehaviour
{
    GameObject core;
    Shader shaderCube;
    Renderer rend;
    int objePosShaderID;
    int corePosShaderID;

    void Start()
    {
        core = GameObject.Find("Environment/Core");

        // Get Shader File
        //shaderCube = Shader.Find("Custom/CubeColor");

        // Get Id of a shader properties
        objePosShaderID = Shader.PropertyToID("_ObjPos");
        corePosShaderID = Shader.PropertyToID("_CorePos");

        // Get Object Renderer
        rend = GetComponent<Renderer>();

        // Set material to shader
        //rend.material.shader = shaderCube;

        //Debug.Log(rend.material.shader);
    }

    void Update()
    {
        // Send core and cube position to shader
        Vector3 dist = core.transform.position - gameObject.transform.position;

        rend.material.SetVector(corePosShaderID, core.transform.position);
        rend.material.SetVector(objePosShaderID, gameObject.transform.position);

        Debug.Log(dist);
    }
}
