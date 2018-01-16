using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Used on SpecialFood gameobjects. </summary>
public class SpecialFood : MonoBehaviour {

    private int points = 10;
    public Vector2 SpFoodPos { get; set; } //Used by FoodSpawner to check if new spawned food do not collide

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void DestroyAndAddPoints()
    {
        GameManager.Score += points;
        Destroy(gameObject);
    }
}
