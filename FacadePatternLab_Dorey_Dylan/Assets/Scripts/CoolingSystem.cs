using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [04/23/2024]
 * [The cooling system of a bike engine that cools the engine at different temperature rates]
 */

public class CoolingSystem : MonoBehaviour
{
    //reference to our facade (bike engine)
    public BikeEngine engine;

    //coroutine variable for cooling the engine
    public IEnumerator coolEngine;

    //determines if the cooling process has been paused or not
    private bool isPaused;

    void Start()
    {
        //initialize the coroutine variable to the CoolEngine method
        coolEngine = CoolEngine();
    }

    /// <summary>
    /// Pauses engine cooling
    /// </summary>
    public void PauseCooling()
    {
        //set isPaused to true/false
        isPaused = !isPaused;
    }

    /// <summary>
    /// Resets the temperature of the engine to default (0)
    /// </summary>
    public void ResetTemperature()
    {
        //set the engine's current temperature to 0
        engine.currentTemp = 0f;
    }    

    /// <summary>
    /// Cools the engine by a desired temperature rate over a specific amount of time
    /// </summary>
    /// <returns> the time between the rate of temperature change for the engine </returns>
    public IEnumerator CoolEngine()
    {
        while(true)
        {
            //wait 1 second before adjust engine temperature
            yield return new WaitForSeconds(1f);

            //if cooling is not paused
            if (!isPaused)
            {
                //if the current engine temperature is greater than the engines minimum temperature
                if (engine.currentTemp > engine.minTemp)
                {
                    //cool the engine by removing the temp rate from the current temperature
                    engine.currentTemp -= engine.tempRate;
                }

                //if the current engine temperature is less than the engines minimum temperature
                if (engine.currentTemp < engine.minTemp)
                {
                    //heat the engine by adding the temp rate to the current temperature
                    engine.currentTemp += engine.tempRate;
                }
            }
            else
            {
                //otherwise if cooling is paused, heat the engine by adding the temp rate to the current temperature
                engine.currentTemp += engine.tempRate;
            }

            //if the current engine temperature is greater than the engines maximum temperature
            if (engine.currentTemp > engine.maxTemp)
            {
                //turn off the engine
                engine.TurnOff();
            }
        }
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //change the UI color to green
        GUI.color = Color.green;

        //display the engine's current temperature
        GUI.Label(new Rect(100, 20, 500, 20), "Temp: " + engine.currentTemp);
    }
}
