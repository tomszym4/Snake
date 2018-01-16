using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary> Keeps track of what button waas pressed last and show score in-game. </summary>
public class InGameUI : MonoBehaviour {


    private bool leftPressed, rightPressed;

    /// <value> LeftPressed property gets / sets the value of bool field leftPressed. </value>
    public bool LeftPressed
    {
        set
        {
            leftPressed = value;
            rightPressed = !value;
        }
        get
        {
            return leftPressed;
        }
    }


    /// <value> RightPressed property gets / sets the value of bool field rightPressed. </value>
    public bool RightPressed
    {
        set
        {
            rightPressed = value;
            leftPressed = !value;
        }
        get
        {
            return rightPressed;
        }
    }

    /// <summary> Sets all flags of InGameUi class to false. </summary>
    public void ResetBools()
    {
        rightPressed = leftPressed = false;
    }

}
