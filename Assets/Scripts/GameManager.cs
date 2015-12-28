using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text bigText;
    public Text littleText;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    bool BothPressed () {
        return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D);
    }

    public void Win () {
        StartCoroutine(WinConditionMet());
    }

    public void Lose (float height) {
        StartCoroutine(AbsoulteFailure(height));
    }

    IEnumerator WinConditionMet () {
        yield return new WaitForSeconds(0.5f);
        bigText.text = "<b>TAKE THAT, MOON</b>";
        yield return new WaitForSeconds(0.75f);
        littleText.text = "A + D or LeftArrow + RightArrow to restart";
        while (!BothPressed())
        {
            yield return null;
        }
        bigText.text = "";
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator AbsoulteFailure(float height) {
        yield return new WaitForSeconds(0.75f);
        bigText.text = @"You didn't punish the moon for existing :(";
        yield return new WaitForSeconds(0.75f);
        bigText.text += "\nElevation: " + height.ToString("#");
        littleText.text = "A + D or LeftArrow + RightArrow to restart";
        while (!BothPressed())
        {
            yield return null;
        }
        bigText.text = "";
        Application.LoadLevel(Application.loadedLevel);
    }
}