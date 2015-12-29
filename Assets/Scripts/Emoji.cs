using UnityEngine;
using UnityEngine.UI;

public abstract class Emoji : MonoBehaviour {

    protected Text _text;

    protected virtual void Start () {
        _text = GetComponent<Text>();
    }

    protected virtual void SetText (string nText) {
        _text.text = nText;
    }
}