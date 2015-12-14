using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RocketEmoji : MonoBehaviour {

    private Text _text;
    private Transform player;
    private Transform moon;
    private bool showingHurt;

    void Start () {
        _text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moon = GameObject.FindGameObjectWithTag("Moon").transform;
    }

    void Update() {
        if (!showingHurt)
        {
            if (Vector2.Distance(moon.position, player.position) < 500.0f)
            {
                _text.text = ">:D";
            }
            else
            {
                _text.text = ">:3";
            }
        }
    }

    public void ShowHurtEmoji () {
        _text.text = ";(";
        StartCoroutine(HurtFaceAnimation());
    }

    IEnumerator HurtFaceAnimation () {
        showingHurt = true;
        yield return new WaitForSeconds(0.5f);
        showingHurt = false;
    }
}