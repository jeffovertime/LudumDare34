using UnityEngine;
using UnityEngine.UI;

public class MoonEmoji : MonoBehaviour {

    private Text _text;

    void Start () {
        _text = GetComponent<Text>();
    }

    public void AngryMoon () {
        _text.text = ">:\'(";
    }
}