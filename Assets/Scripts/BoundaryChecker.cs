using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryChecker : MonoBehaviour {

    public CameraEffects cameraEffects;

    private void Start() {
        if(cameraEffects == null) {
            Debug.Log("Camera Effects not available.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("Trigger Entered: " + collision.GetComponent<Collider2D>().name);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Destroy GameObjects that exit the Boundary (Box) trigger collider
        //Debug.Log("Trigger Exited: " + collision.GetComponent<Collider2D>().name);
        if(collision.gameObject.tag == "Player") {
            Player p = collision.gameObject.GetComponent<Player>();
            if(p == null) {
                Debug.Log("Player component not found.");
            }
            cameraEffects.ShakeCamera(p.shakeAmount, p.shakeLength);
        }
        Destroy(collision.gameObject);
    }
}
