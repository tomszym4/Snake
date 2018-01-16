using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour {


    [Range(0, 10)] //0 is setted to 4 as default in Start method
    public int snakeSpeed;
    public GameObject tailPrefab;
    [SerializeField]
    private int direction;
    private Vector2 hpos; // position of snake's head
    private bool snakeGrow; // true if snake ate food
    private LevelManager levMan;
    private FoodSpawner foodSpawner;

    private InGameUI inGameUI;
    private List<GameObject> tail = new List<GameObject>();

    private void Start()
    {
        inGameUI = FindObjectOfType<InGameUI>();
        levMan = FindObjectOfType<LevelManager>();
        foodSpawner = FindObjectOfType<FoodSpawner>();
        if(snakeSpeed == 0)
        {
            snakeSpeed = 4;
        }

        InvokeRepeating("SnakeMoving", 0.000001f, 1f/snakeSpeed);
    }



    /// <summary>
    /// Translates position of Head (depending on direction field) and Tail gameobjects.
    /// Also instantiate Tail gameobjects if snake ate a food.
    /// </summary>
    void SnakeMoving ()
    {
        CheckingDirection();
        hpos = transform.position;

        if(direction == 0)
        {
            transform.Translate(Vector2.up);
        }
        else if (direction == 1)
        {
            transform.Translate(Vector2.right);
        }
        else if (direction == 2)
        {
            transform.Translate(Vector2.down);
        }
        else if (direction == 3)
        {
            transform.Translate(Vector2.left);
        }
        
        if(tail.Count < 4)
        {
            snakeGrow = true;
        }
        if (snakeGrow)
        {
            GameObject obj = Instantiate(tailPrefab, hpos, Quaternion.identity) as GameObject;
            tail.Insert(0, obj);
            snakeGrow = false;
        }
        else if (tail.Count > 0)
        {
            tail[tail.Count - 1].transform.position = hpos;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<Food>())
        {
            Food food = collision.GetComponent<Food>();
            food.DestroyAndAddPoints();
            snakeGrow = true;
            foodSpawner.FoodSpawned = false;
            Destroy(obj);
        }else if(obj.GetComponent<SpecialFood>())
        {
            SpecialFood spFood = collision.GetComponent<SpecialFood>();
            spFood.DestroyAndAddPoints();
            snakeGrow = true;
            foodSpawner.SpecialFoodSpawned = false;
        }else
        {
            levMan.LoadScene("03_GameOver");
        }
    }


    /// <summary> Sets direction field depending on flags in InGameUI class. </summary>
    void CheckingDirection()
    {
        if (inGameUI.RightPressed)
        {
            direction++;
            inGameUI.ResetBools();
            if (direction >= 4)
            {
                direction = 0;
            }
        }else if (inGameUI.LeftPressed)
        {
            direction--;
            inGameUI.ResetBools();
            if (direction <= -1)
            {
                direction = 3;
            }
        }
    }

}


