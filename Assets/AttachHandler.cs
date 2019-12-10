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

    void Start()
    {
        pedestal = gameObject;
        barySphere = GameObject.Find("BarySphere");
        lockPosition = pedestal.transform.position + pedestalOffset;
        nowAttached = true;
        p1 = GameObject.Find("Pedestal");
        p2 = GameObject.Find("Pedestal (1)");
        p1.GetComponent<Material>().SetColor("_Color", Color.white);
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
            }
            else
            {

            }
        }
    }
}
