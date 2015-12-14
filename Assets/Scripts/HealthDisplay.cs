using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    public GameObject[] healthBlocks;

    private int healthRemaining;

    void Start() {
        foreach (GameObject block in healthBlocks)
        {
            block.SetActive(true);
        }

        healthRemaining = 3;
    }

    public void RemoveHealth () {
        healthRemaining--;
        healthBlocks[healthRemaining].SetActive(false);
    }
}