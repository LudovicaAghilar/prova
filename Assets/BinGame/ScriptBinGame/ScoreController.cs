using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;

    private int score;

    void Start()
    {
     gameOverPanel.SetActive(false);
    }


    void Update()
    {
        scoreText.text = score.ToString();

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bomb")
            gameOverPanel.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Garbage")
        {
            Destroy(target.gameObject);
            score++;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
