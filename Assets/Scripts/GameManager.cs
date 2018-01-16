using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int Score { get; set; }

    private void Start()
    {
        Score = 0;
    }
}
