using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    [SerializeField] private Sprite x;
    [SerializeField] private Sprite o;
    [SerializeField] private int blockIndex = 0;
    private bool clicked = false;
    public GameScript gs;
    private Image image;

    private void Start()
    {
        image = transform.GetComponent<Image>();
    }

    public void buttonClick()
    {
        if (!clicked)
        {
            if (gs.currentPlayer.Equals(1))
            {
                image.sprite = x;
                gs.gba[blockIndex] = 1;
                gs.currentPlayer = 2;
            }
            else if (gs.currentPlayer.Equals(2))
            {
                image.sprite = o;
                gs.gba[blockIndex] = 2;
                gs.currentPlayer = 1;
            }
            clicked = true;
        }
    }
}
