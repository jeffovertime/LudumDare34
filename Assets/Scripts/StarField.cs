using UnityEngine;

public class StarField : MonoBehaviour {

    public GameObject starPrefab;
    public Transform followTarget;
    public int maxStarCount = 300;
    public float starSpread = 15.0f;
    public float minStarSize = 0.5f;
    public float maxStarSize = 0.5f;
    public float minSpeed = 0.1f;
    public float maxSpeed = 0.2f;
    public bool isFalling;

    private Transform[] stars;
    private Color[] starColors = new Color[3];

    void Start() {
        isFalling = false;
        stars = new Transform[maxStarCount];

        starColors[0] = new Color(0.14f, 1.0f, 1.0f, 0.59f);    // Blue
        starColors[1] = new Color(1.0f, 1.0f, 0.55f, 0.59f);    // Yellow
        starColors[2] = new Color(1.0f, 1.0f, 1.0f, 0.59f);     // White

        CreateStars();
    }

    void CreateStars() {
        for (int i = 0; i < maxStarCount; i++)
        {
            var star = Instantiate(starPrefab, Random.insideUnitCircle * starSpread + (Vector2)transform.position, Quaternion.identity) as GameObject;
            stars[i] = star.transform;
            stars[i].SetParent(transform);
            stars[i].localScale *= Random.Range(minStarSize, maxStarSize);
            star.GetComponent<Star>().FallingSpeed = Random.Range(minSpeed, maxSpeed);
            star.GetComponent<SpriteRenderer>().color = starColors[Random.Range(0, 3)];
        }
    }

    void MoveStars() {
        foreach (Transform star in stars)
        {
            star.Translate(-Vector3.up * star.GetComponent<Star>().FallingSpeed);
        }
    }

    void CheckStarLocations() {
        for (int i = 0; i < maxStarCount; i++)
        {

            if (Camera.main.WorldToViewportPoint(stars[i].position).y < 0.0f)
            {
                stars[i].GetComponent<Star>().FallingSpeed = Random.Range(minSpeed, maxSpeed);
                stars[i].position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), Random.Range(1.0f, 2.0f), 10));
            }
        }
    }

    public void SpeedUp () {
        isFalling = false;
        minSpeed *= 20.0f;
        maxSpeed *= 20.0f;
        Invoke("ChangeSpeed", 1.2f);
    }

    void ChangeSpeed () {
        isFalling = true;
        foreach (Transform star in stars)
        {
            star.GetComponent<Star>().FallingSpeed *= 20;
        }
    }

    void LateUpdate() {
        if (isFalling)
        {
            Vector3 position = followTarget.position;
            position.z = 0;
            transform.position = position;
            MoveStars();
        }
        CheckStarLocations();
    }
}