using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachHandler : MonoBehaviour
{
    public Vector3 pedestalOffset;
    GameObject pedestal;
    Vector3 lockPosition;
    GameObject barySphere;
    bool rEnabled;

    void Start()
    {
        pedestal = gameObject;
        barySphere = GameObject.Find("BarySphere");
        lockPosition = pedestal.transform.position + pedestalOffset;
        rEnabled = true;
    }

    void Update()
    {
        float dist = Vector3.Distance(lockPosition, barySphere.transform.position);
        Debug.Log(dist);

        if (rEnabled)
        {
            if (dist <= 1f)
            {
                barySphere.GetComponent<Rigidbody>().useGravity = false;
                barySphere.GetComponent<Rigidbody>().isKinematic = true;
                barySphere.transform.position = lockPosition;
                barySphere.transform.parent = pedestal.transform;
            }
        }
        else
        {
            if (dist >= 1f)
            {
                
            }
        }
    }
}
