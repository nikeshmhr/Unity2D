using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    [HideInInspector]
    public float destroyAfter = 1f; // Destroy after xx seconds.

    public static GameMaster gm;

    void Awake() {
        if(gm == null) {
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
        }
    }

    public void Destroyer(GameObject gameObject, float destroyAfterSeconds) {
        if(gameObject == null) {
            return;
        }

        Destroy(gameObject, destroyAfterSeconds == -1 ? destroyAfter: destroyAfterSeconds);
    }

    public void Destroyer(GameObject gameObject) {
        Destroyer(gameObject, -1);
    }
}
