using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Used on SpecialFood gameobjects. </summary>
public class SpecialFood : MonoBehaviour {

    private int points = 10;

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
