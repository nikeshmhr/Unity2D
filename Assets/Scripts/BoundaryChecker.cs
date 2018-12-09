using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryChecker : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Trigger Entered: " + collision.GetComponent<Collider2D>().name);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Destroy GameObjects that exit the Boundary (Box) trigger collider
        Debug.Log("Trigger Exited: " + collision.GetComponent<Collider2D>().name);

        Destroy(collision.gameObject);
    }
}
