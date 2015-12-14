using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScreen : MonoBehaviour {

    public GameObject[] objectsToActivate;
    
    public Text title;
    public Text instructions;
    private PlayerController player;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        title.text = "Rockets Hate the Moon";
        instructions.text = "A + D to start";
        StartCoroutine(WaitForStart());
    }

    IEnumerator WaitForStart () {
        while (!Started())
        {
            yield return null;
        }
        title.text = "";
        instructions.text = "";

        yield return new WaitForSeconds(2.0f);
        player.Launch();
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
        foreach (GameObject starSystem in GameObject.FindGameObjectsWithTag("StarSystem"))
        {
            starSystem.GetComponent<StarField>().isFalling = true;
        }
    }

    bool Started () {
        return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D);
    }
}