using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool canBugGame;

    private GameObject player;

    private void Awake()
    {
        canBugGame = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Bugbegins()
    {
        if (canBugGame == true)
        {

        }
    }
}
