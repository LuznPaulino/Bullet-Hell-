using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //Adds an aditional namespace for UI elements to be used

public class GameControl : MonoBehaviour
{
    //Create a variable that holds an instance of this class
    public static GameControl control; //Static variable means there is only one copy of it

    //Declare variables
    public int health; //Health Score
    public int points; //Game Score

    // Awake precedes the Start() function as the very first thing initialized 
    void Awake()
    {
        //Check if this is the first scene the GameControl object will be used in 
        if (control == null)
        {
            //Tag the object as Do Not Destroy
            DontDestroyOnLoad(gameObject);

            //Make the control variable point to the current object
            control = this;
        }

        //Otherwise, check for any subsequent scene that uses GameControl
        else if (control != this)
        {
            //If I am the new instance of the GameControl script...
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Find the text label for Health and edit the value
        GameObject healthPoints = GameObject.Find("Health Text");
        healthPoints.GetComponent<Text>().text = "Health: " + health.ToString();

        //Find the text label for Score and edit the value
        GameObject scorePoints = GameObject.Find("Score Text");
        scorePoints.GetComponent<Text>().text = "Score: " + points.ToString();
    }
}

