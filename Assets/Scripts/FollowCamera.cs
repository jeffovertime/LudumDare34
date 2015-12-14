using UnityEngine;

public class FollowCamera : MonoBehaviour {

    private Transform cam;

    void Start () {
        cam = Camera.main.transform;
    }

    void LateUpdate () {
        Vector3 position = cam.position + Vector3.up * 30.0f;
        position.z = 0;
        transform.position = position;
    }
}