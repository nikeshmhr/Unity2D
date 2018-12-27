using System.Collections;
using UnityEngine;

public class ActBroken : MonoBehaviour {

    // Break delay in seconds
    public float breakDelay = 0.5f;

    private AudioSource audioSource;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            // Change gameobject's rigibody behaviour after certain delay
            StartCoroutine(breakPlank());
        }
    }

    IEnumerator breakPlank() {
        yield return new WaitForSeconds(breakDelay);
        audioSource.Play();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

}
