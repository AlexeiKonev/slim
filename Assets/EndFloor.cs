using UnityEngine;

public class EndFloor : MonoBehaviour {
    public GameObject newFloor;
    public Transform nextFloorPos;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Instantiate(newFloor,nextFloorPos.position, Quaternion.identity);
            Debug.Log("end detected");
        }
    }
}
