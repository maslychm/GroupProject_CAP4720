using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachHandler : MonoBehaviour
{
    public Vector3 pedestalOffset;
    GameObject pedestal;
    Vector3 lockPosition;
    GameObject barySphere;
    bool nowAttached;
    Quaternion rot;
    Vector3 sc;
    Color originalColor;
    GameObject p1;
    GameObject p2;
    GameObject lights4;

    void Start()
    {
        pedestal = gameObject;
        barySphere = GameObject.Find("BarySphere");
        lockPosition = pedestal.transform.position + pedestalOffset;
        nowAttached = true;
        lights4 = GameObject.Find("Lights4");
        disableLights();
    }

    void Update()
    {
        float dist = Vector3.Distance(lockPosition, barySphere.transform.position);
        Debug.Log(dist);

        if (nowAttached)
        {
            if (dist <= 1f)
            {

            }
            else
            {
                //barySphere.transform.localScale = sc;
                nowAttached = false;
                disableLights();
            }
        }
        else
        {
            if (dist <= 1f)
            {
                barySphere.GetComponent<Rigidbody>().useGravity = false;
                barySphere.GetComponent<Rigidbody>().isKinematic = true;
                barySphere.transform.position = lockPosition;
                barySphere.transform.parent = pedestal.transform;
                nowAttached = true;

                enableLights();
            }
            else
            {

            }
        }
    }

    void enableLights()
    {
        foreach (Transform child in lights4.transform)
        {
            child.gameObject.SetActive(true);
            Debug.Log("disabled light");
        }
    }

    void disableLights()
    {
        foreach (Transform child in lights4.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
