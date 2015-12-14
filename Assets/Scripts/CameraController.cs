using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float yOffset;

    private Transform moon;
    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moon = GameObject.FindGameObjectWithTag("Moon").transform;
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

    public void GoToTheMoon () {
        StartCoroutine(FlyToTheMoon());
    }

    IEnumerator FlyToTheMoon () {
        yield return new WaitForSeconds(1.2f);
        while (Vector2.Distance(transform.position, moon.position) > 10)
        {
            Vector3 moonPos = moon.position - Vector3.up * 5;
            moonPos.z = transform.position.z;
            transform.position += Vector3.up * 10;
            yield return null;
        }
        Vector3 pos = moon.position;
        pos.z = transform.position.z;
        pos.y -= 10.0f;
        transform.position = pos;
        foreach (GameObject starSystem in GameObject.FindGameObjectsWithTag("StarSystem"))
        {
            starSystem.GetComponent<StarField>().isFalling = false;
        }
    }
}
