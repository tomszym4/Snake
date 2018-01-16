using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class GameManager {

    public static int Score { get; set; }

    public static void NewGame()
    {
        Score = 0;
    }
}
