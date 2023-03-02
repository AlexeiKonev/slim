using Slime;
using System;
using UnityEngine;

public class FloorManager : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Player"){
            other.gameObject.GetComponent<PlayerMovement>().isMoving = false;
            Debug.Log("player detected");
        }
    }
}
