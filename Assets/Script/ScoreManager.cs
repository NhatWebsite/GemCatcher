using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScore;
    private int totalScore;
    private float remainingTime;
    public GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    


    
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        remainingTime=30f;
        StartCoroutine(CountdownTimer());
        // là một phương thức nâng cao để gọi hàm CountdownTimer
        // nhằm cho phép đồng hồ chạy song song, tiếp tục đếm khi chuyển qua frame mới và kết thúc ở frame mới khi đạt đúng thời gian


    }

    public void addScore(int Score)
    {
        totalScore = totalScore + Score;
        if (totalScore < 0)
        {
            totalScore = 0;
        }
        txtScore.text = "score: "+totalScore.ToString();
    }

    public void MultipleScore(int Score)
    {
        totalScore = totalScore * Score;
        
        txtScore.text = "score: " + totalScore.ToString();
    }
    /* public void remainTime(float Timer)
     {
        *//* txtScore.text = "score: " + score + " | Time: " + remainTime;*//*
     }*/


    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score: " + totalScore + " | Time: " + Mathf.CeilToInt(remainingTime);
    }
    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        if (remainingTime <= 0)
        {
            GameOver();
        }
    }
    private void GameOver()

    {
        gameOverText.text = "Game Over!\nScore: " + totalScore;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        
        
    }

    
    
    
}
