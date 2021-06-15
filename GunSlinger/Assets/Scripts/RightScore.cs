using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RightScore : MonoBehaviour
{
    public static RightScore instance;
    public Text scoreText;
    public int rscore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = rscore.ToString();
    }
    public void AddPoint()
    {
        rscore += 1;
        scoreText.text = rscore.ToString();
    }

    private void Update()
    {
        if (rscore >= 10)
        {
            SceneManager.LoadScene(5);

        }
    }
}
