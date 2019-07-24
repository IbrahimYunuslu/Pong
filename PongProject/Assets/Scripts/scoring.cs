using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    public Text userScoreUI, computerScoreUI;
    [HideInInspector] public int userScore, computerScore;
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
    }

    public void ComputerScore(){
        computerScore += 1;
    }
}
