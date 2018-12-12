using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use to apply camera effects
// Shake, Death paint.....
public class CameraEffects : MonoBehaviour {

    public Camera cam;

    private float shakeAmount = 0;
    private Vector3 camOriginalPos;

	void Awake () {
        if (cam == null) {
            cam = Camera.main;
        }
	}

    public void ShakeCamera(float shakeAmt, float shakeDuration) {
        shakeAmount = shakeAmt;
        InvokeRepeating("Shake", 0, 0.01f);
        Invoke("StopShake", shakeDuration);
    }

    private void Shake() {
        if(shakeAmount > 0) {
            // Store position before shaking so that we can restore it back.
            camOriginalPos = cam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;   // This formula works better
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;

            Vector3 camPos = cam.transform.position;
            camPos.x += offsetX;
            camPos.y += offsetY;

            cam.transform.position = camPos;
        }
    }

    private void StopShake() {
        CancelInvoke("Shake");
        // Restore camera's original position
        cam.transform.position = camOriginalPos;
    }



}
