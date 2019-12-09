using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosShader : MonoBehaviour
{
    GameObject core;
    Renderer rend;
    int objePosShaderID;
    int corePosShaderID;
    //Adding point light effects
    public GameObject coreLight;
    private Light lightComp;
    [SerializeField] public float maxDist = 25;

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

        //Set lighting object
        lightComp = coreLight.GetComponent<Light>();

    }

    void Update()
    {
        // Send core and cube position to shader
        Vector3 dist = core.transform.position - gameObject.transform.position;

        //Adjust lighting
        Vector3 diff = dist / maxDist;


        rend.material.SetVector(corePosShaderID, core.transform.position);
        rend.material.SetVector(objePosShaderID, gameObject.transform.position);

        // Debug.Log(dist);
    }
}
