using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public float yOffset;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        yOffset = transform.position.y - player.position.y;
    }

    void Update() {
        if (player != null)
        {
            Vector3 position = transform.position;
            position.y = player.position.y + yOffset;
            transform.position = position;
        }
    }
}
