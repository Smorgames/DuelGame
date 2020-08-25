using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public void ToGameField()
    {
        Application.LoadLevel("GameField");
    }
    public void ToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
