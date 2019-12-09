using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLightColor : MonoBehaviour
{   
    public GameObject light;
    
    private Light lightComp;
    // Start is called before the first frame update
    void Start()
    {
        lightComp = light.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lightComp.intensity);
    }
}
