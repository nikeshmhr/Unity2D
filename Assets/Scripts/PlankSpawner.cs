using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSpawner : MonoBehaviour {

    public Transform[] plankSpawnPoints;
    public float spawnDelay = 1f;   // Spaw every 
    public float brokenSpawnDelay = 2f;    // Spawn broken plank every 10 seconds
    public Transform plankPrefab;   // TODO: This could be list with plank types in future
    public Transform brokenPlankPrefab;     // This will fall once it is stepped on (collision detected)

    // There are two patterns to spawn a planks
    // This holds the previously used pattern
    private int previousSpawnPattern = SpawnPattern.EDGE;

    public float timeToSpawnBrokenPlank;
    private bool useBrokenPlank;

    private void Start() {
        timeToSpawnBrokenPlank = brokenSpawnDelay;
        useBrokenPlank = false;
        StartCoroutine(spawn());
    }

    private void Update() {
        if (timeToSpawnBrokenPlank <= 0f) {
            useBrokenPlank = true;
            timeToSpawnBrokenPlank = brokenSpawnDelay;
        } else {
            timeToSpawnBrokenPlank -= Time.deltaTime;
        }
    }

    IEnumerator spawn() {
        while (true) {
            yield return new WaitForSeconds(spawnDelay);
            // New spawn pattern
            int spawnPattern = 0;
            if (previousSpawnPattern == SpawnPattern.CENTER) {
                spawnPattern = SpawnPattern.EDGE;
            } else if (previousSpawnPattern == SpawnPattern.EDGE) {
                spawnPattern = SpawnPattern.CENTER;
            }

            // Get indices of spawn points to use
            int[] pointIndices = getSpawnIndicesForPattern(spawnPattern);
            for (int i = 0; i < pointIndices.Length; i++) {
                Transform spawnPoint = plankSpawnPoints[pointIndices[i]];
                Transform prefab = plankPrefab;
                if(useBrokenPlank) {
                    prefab = brokenPlankPrefab;
                    useBrokenPlank = false;
                }
                Instantiate(prefab, new Vector2(spawnPoint.position.x, spawnPoint.position.y), spawnPoint.rotation);
            }

            if (pointIndices == null) {
                Debug.Log("Spawn Point Invalid");
            }
            previousSpawnPattern = spawnPattern;
        }
    }

    int[] getSpawnIndicesForPattern(int spawnPattern) {
        if (spawnPattern == SpawnPattern.CENTER) {
            return new int[2] { 1, 3 };
        } else if(spawnPattern == SpawnPattern.EDGE) {
            float rand = Random.Range(0f, 1f);
            int i = 4;  // Default right plank (index)
            if(rand > 0 && rand <= 0.5) {
                i = 0;
            }
            return new int[2] { 2, i };
        } else {
            return null;
        }
    }

    private class SpawnPattern {
        public const int CENTER = 1;    // _P_P_    -> P is plank
        public const int EDGE = 2;      // P_P_P    ->Once P from either left or right will be removed randomly
    }
}
