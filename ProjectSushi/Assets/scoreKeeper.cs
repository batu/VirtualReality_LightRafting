using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : MonoBehaviour {

    TextMeshPro scoreText;
    public bool boatScoreActive = false;
    public int baloonScore = 10;

    int currentScore = 0;
    // Use this for initialization
    void Start () {

        if (boatScoreActive) {
            scoreText = GameObject.FindGameObjectWithTag("scoreBoat").GetComponent<TextMeshPro>();
            GameObject.FindGameObjectWithTag("score").SetActive(false);
        }
        if (!boatScoreActive) {
            scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<TextMeshPro>();
            GameObject.FindGameObjectWithTag("scoreBoat").SetActive(false);
        }
        StartCoroutine(increaseScore());
    }
	
    public void addBaloonToScore() {
        currentScore += baloonScore;
        scoreText.text = currentScore.ToString();
    }
    IEnumerator increaseScore() {
        while (true) {
            ++currentScore;
            scoreText.text = currentScore.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
