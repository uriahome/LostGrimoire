using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;//スコア表示用
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:"+score.ToString();
    }
    
    public void Initialize()
    {
        score = 0;

    }
    
    public void AddScore(int add)
    {
        score += add;
    }
}
