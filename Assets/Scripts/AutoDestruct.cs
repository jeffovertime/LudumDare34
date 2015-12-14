using UnityEngine;

public class AutoDestruct : MonoBehaviour {

    public float lifeTime = 1.0f;
    void Start () {
        Destroy(gameObject, lifeTime);
    }
}