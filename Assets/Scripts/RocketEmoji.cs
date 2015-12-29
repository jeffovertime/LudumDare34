using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RocketEmoji : Emoji {

    private Transform player;
    private Transform moon;
    private bool showingHurt;

    protected override void Start () {
        base.Start();
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
        SetText(";(");
        StartCoroutine(HurtFaceAnimation());
    }

    IEnumerator HurtFaceAnimation () {
        showingHurt = true;
        yield return new WaitForSeconds(0.5f);
        showingHurt = false;
    }
}