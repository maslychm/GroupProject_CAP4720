using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    private GameObject player;
    private Collider playerCollider;
    private GameObject door;
    private bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FPSController");
        playerCollider = player.GetComponent<Collider>();
        door = GameObject.Find("Hologram Wall");
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange){
            if (Input.GetKeyDown("e")){
                door.SetActive(false);
            }
        }
    }
    
    //Allow the user to press the button to toggle the holographic door when they are close enough
    void OnTriggerEnter(Collider other){
        inRange = true;
    }

    void OnTriggerExit(Collider other){
        inRange = false;
    }
}
