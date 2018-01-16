using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> Loading new scenes. </summary>
public class LevelManager : MonoBehaviour {

    public void LoadScene(string name)
    {
        if (name == "02_MainGame")
        {
            GameManager.NewGame();
        }
        SceneManager.LoadScene(name);
    }
}
