using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeftScore : MonoBehaviour
{
    public static LeftScore instance;
    public Text scoreText;
    public int lscore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = lscore.ToString();
    }
    public void AddPoint()
    {
        lscore += 1;
        scoreText.text = lscore.ToString();
    }

    private void Update()
    {
        if (lscore >= 10)
        {
            SceneManager.LoadScene(4);

        }
    }
}
