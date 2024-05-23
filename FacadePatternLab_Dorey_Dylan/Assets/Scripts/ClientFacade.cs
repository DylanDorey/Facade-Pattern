using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [04/23/2024]
 * [The client component that allows the user to interact with the demo]
 */

public class ClientFacade : MonoBehaviour
{
    //reference to our facade (bike engine)
    private BikeEngine engine;

    private void Start()
    {
        //initialize the bike engine component by adding it to this game object
        engine = gameObject.AddComponent<BikeEngine>();
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //create a button to turn on the engine
        if (GUILayout.Button("Turn On"))
        {
            //if pressed, turn on the engine
            engine.TurnOn();
        }

        //create a button to turn off the engine
        if (GUILayout.Button("Turn Off"))
        {
            //if pressed, turn off the engine
            engine.TurnOff();
        }

        //create a button to toggle the turbo mode
        if (GUILayout.Button("Toggle Turbo"))
        {
            //if pressed, toggle the turbo mode on/off
            engine.ToggleTurbo();
        }
    }
}
