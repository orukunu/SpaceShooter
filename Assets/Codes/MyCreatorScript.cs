using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyCreatorScript : MonoBehaviour
{
    public GameObject asteroid;
    Vector3 randomPosition;
    public float waitToStart;
    public float waitToCreate;
    public float waitToRecycle;
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    bool gameIsRunning = true;
    bool restartMode = false;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score = " + score;
        StartCoroutine(AstroidCreator()); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && restartMode) {
            SceneManager.LoadScene("Level1");
        }
    }

    IEnumerator AstroidCreator()
    {
        yield return new WaitForSeconds(waitToStart);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vector = new Vector3(UnityEngine.Random.Range(-6, 6), 0, 14);
                Instantiate(asteroid, vector, Quaternion.identity);
                yield return new WaitForSeconds(waitToCreate);
            }
            if (!gameIsRunning)
            {
                restartText.text = "To Start Over Press 'R'";
                restartMode = true;
                break;
            }
            yield return new WaitForSeconds(waitToRecycle);
        }

        
    }

    public void ScoreIncreaser(int increaser) {
        score += increaser;
        scoreText.text = "Score = " + score;
    }

    public void gameOver() {
        gameOverText.text = "GAME OVER!";
        gameIsRunning = false;
    }
}
