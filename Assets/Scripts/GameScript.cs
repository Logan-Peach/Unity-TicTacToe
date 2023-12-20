using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public int[] gba = {0,0,0,0,0,0,0,0,0};
    public int currentPlayer = 1;
    private string winner;
    
    private void Start()
    {
        WinnerScript.winner = null;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckWin();
    }

    private void CheckWin()
    {
        //Check horizontal and vertical wins
        for (int i = 0; i < 3; i++)
        {
            if (gba[i] == gba[i + 3] && gba[i] == gba[i + 6])
            { 
                if (gba[i] == 1) { winner = "x"; }
                else if (gba[i] == 2) { winner = "o"; }
            }
        }
        for (int i = 0; i < 7; i += 3)
        {
            if (gba[i] == gba[i + 1] && gba[i] == gba[i + 2])
            {
                if (gba[i] == 1) { winner = "x"; }
                else if (gba[i] == 2) { winner = "o"; }
            }
        }
        //Check diagonal wins
        if (gba[0] == gba[4] && gba[0] == gba[8])
        {
            if (gba[0] == 1) { winner = "x"; }
            else if (gba[0] == 2) { winner = "o"; }
        }
        if (gba[2] == gba[4] && gba[2] == gba[6])
        {
            if (gba[2] == 1) { winner = "x"; }
            else if (gba[2] == 2) { winner = "o"; }
        }
        //If there is a winner, end the game
        if (winner != null)
        {
            WinnerScript.winner = winner;
            currentPlayer = 0;
            Invoke("LoadNext", 1.0f);
        }
        //If board is full and no winner, end the game
        if (winner == null && !gba.Contains(0))
        {
            WinnerScript.winner = "NO ONE";
            currentPlayer = 0;
            Invoke("LoadNext", 1.0f);
        }
    }

    //Load next scene method to use with Invoke to add a delay before swapping scenes
    private void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
