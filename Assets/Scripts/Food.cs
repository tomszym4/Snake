using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Used on Food gameobjects. </summary>
public class Food : MonoBehaviour {

    private int points = 1;
    public Vector2 FoodPos { get; set; } //Used by FoodSpawner to check if new spawned food do not collide

    public void DestroyAndAddPoints()
    {
        GameManager.Score += points;
        Destroy(gameObject);
    }
}
