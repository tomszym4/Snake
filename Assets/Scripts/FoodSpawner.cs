using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns Food and SpecialFood prefabs and keeps track of them.
/// </summary>
public class FoodSpawner : MonoBehaviour {

    public Transform top, bottom, right, left;   //boundaries of play space
    public bool FoodSpawned { get; set; }
    public bool SpecialFoodSpawned { get; set; }
    public GameObject foodPrefab, specialFoodPrefab;
    private Food food;
    private SpecialFood specialFood;
    private SnakeBehaviour snakeBehaviour;

    private float x, y;     //keeps position of food
    private float timeToSpawnSpecialFood;
    private float timeToDisappear; //for SpecialFood

    private void Start()
    {
        food = FindObjectOfType<Food>();
        specialFood = FindObjectOfType<SpecialFood>();
        snakeBehaviour = FindObjectOfType<SnakeBehaviour>();
        FoodSpawned = false;
        SpecialFoodSpawned = false;
        RanTime();
    }

    private void Update()
    {
        if (FoodSpawned == false)
        {
            SpawnFood();
        }
        if (SpecialFoodSpawned == false)
        {
            timeToSpawnSpecialFood -= Time.deltaTime;
        }
        if (timeToSpawnSpecialFood <= 0)
        {
            SpawnSpecialFood();
        }
    }

    /// <summary> Spawns food at random position. </summary>
    void SpawnFood()
    {
        RanPos();
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
        FoodSpawned = true;
    }

    /// <summary> Spawns special food at random position in specified interval. </summary>
    void SpawnSpecialFood()
    {
        RanPos();
        RanTime();
        Instantiate(specialFoodPrefab, new Vector2(x, y), Quaternion.identity);
        SpecialFoodSpawned = true;
    }

    /// <summary> Sets interval time for spawning Special Food. </summary>
    /// <param name="min">Min value of interval, default is 10s.</param>
    /// <param name="max">Max value of interval, default is 30s.</param>
    void RanTime(int min = 10, int max = 30)
    {
        timeToSpawnSpecialFood = Random.Range(min, max);
    }
    
    /// <summary> Generates random position inside play area. And check if that position is free </summary>
    void RanPos()
    {
        x = ((int)Random.Range(left.position.x+1, right.position.x) - 0.5f);
        y = (int)Random.Range(bottom.position.y+1, top.position.y) - 0.5f;
        Vector2 pos = new Vector2(x, y);
        if (food || specialFood)
        {
            if (pos == food.FoodPos || pos == specialFood.SpFoodPos)
            {
                RanPos();
            }
        }
        else if (pos == snakeBehaviour.HPos)
        {
            RanPos();
        }else if(snakeBehaviour.GetSizeOfTail() > 0)
        {
            for (int i = 0; i < snakeBehaviour.GetSizeOfTail(); i++)
            {
                if (pos == snakeBehaviour.GetVecOfTail(i))
                {
                    RanPos();
                }
            }
        }

    }


}
