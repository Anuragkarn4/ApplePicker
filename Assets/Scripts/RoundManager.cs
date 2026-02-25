using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public Text roundText;
    public GameObject restartButton;

    public AppleTree appleTree;

    void Start()
    {
        UpdateRound(4); // start with 4 baskets
        restartButton.SetActive(false);
    }

    public void UpdateRound(int basketsLeft)
    {
        if (basketsLeft > 0)
        {
            int roundNumber = 5 - basketsLeft;
            roundText.text = "Round " + roundNumber;
        }
        else
        {
            roundText.text = "Game Over";
            restartButton.SetActive(true);
        }

        if (appleTree != null)
        {
            appleTree.gameOver = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}