using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerTextScript : MonoBehaviour
{
    [SerializeField] private GameScript gameScript;
    [SerializeField] private Text currentPlayerText;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (gameScript.currentPlayer == 1)
        {
            currentPlayerText.text = "PLAYING: X";
        }

        else if (gameScript.currentPlayer == 2)
        {
            currentPlayerText.text = "PLAYING: O";
        }

        string winner = WinnerScript.winner;
        if (winner != null)
        {
            currentPlayerText.text = winner.ToUpper() + " WINS";
        }
    }
}
