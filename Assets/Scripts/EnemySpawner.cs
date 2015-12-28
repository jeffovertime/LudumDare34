using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public float minSpawnRate = 0.75f;
    public float maxSpawnRate = 1.5f;
    public float minSize = 1.0f;
    public float maxSize = 3.5f;
    public GameObject enemyPrefab;

    private Transform player;

	void Awake () {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, -0.1f,0));
	}

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while (player != null)
        {
            var enemyInstance = Instantiate(enemyPrefab, Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 1.1f, 0)), Quaternion.identity) as GameObject;
            enemyInstance.transform.position = new Vector3(enemyInstance.transform.position.x, enemyInstance.transform.position.y, 0);
            float rand = Random.Range(minSize, maxSize);
            enemyInstance.transform.localScale *= rand;
            //enemyInstance.GetComponent<Enemy>().health = (int)rand * 9;
            //enemyInstance.GetComponent<Enemy>().fallingSpeed -= 5 * rand;
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
        }
    }
}
