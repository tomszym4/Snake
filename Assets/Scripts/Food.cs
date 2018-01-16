using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Used on Food gameobjects. </summary>
public class Food : MonoBehaviour {

    private int points = 1;

    public void DestroyAndAddPoints()
    {
        GameManager.Score += points;
        Destroy(gameObject);
    }
}
