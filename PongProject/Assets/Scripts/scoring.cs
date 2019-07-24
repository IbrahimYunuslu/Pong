using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoring : MonoBehaviour
{
    public Text userScoreUI, computerScoreUI;
    [HideInInspector] public int userScore, computerScore;
    public int beatingScore;
    // Start is called before the first frame update
    void Start()
    {
        userScore = 0;
        computerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        userScoreUI.text = userScore.ToString();
        computerScoreUI.text = computerScore.ToString();
    }

    public void PlayerScore(){
        userScore += 1;
        if (userScore == beatingScore)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    public void ComputerScore(){
        computerScore += 1;
        if (computerScore == beatingScore)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
