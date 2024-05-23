using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [04/23/2024]
 * [The fuel pump of a bike engine that burns fuel at different rates]
 */

public class FuelPump : MonoBehaviour
{
    //reference to our facade (bike engine)
    public BikeEngine engine;

    //coroutine variable for burning fuel
    public IEnumerator burnFuel;

    private void Start()
    {
        //initialize the coroutine variable to the BurnFuel method
        burnFuel = BurnFuel();
    }

    /// <summary>
    /// Burns fuel at a desired burn rate
    /// </summary>
    /// <returns> the time to wait before burning more fuel </returns>
    public IEnumerator BurnFuel()
    {
        while (true)
        {
            //wait one second before burning more fuel
            yield return new WaitForSeconds(1f);

            //take the engines fuel amount and subtract the fuel burn rate
            engine.fuelAmount -= engine.burnRate;

            //if the engine runs out of fuel
            if(engine.fuelAmount <= 0f)
            {
                //turn off the engine and exit the coroutine
                engine.TurnOff();
                yield return 0;
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

        //display the engine's fuel amount
        GUI.Label(new Rect(100, 40, 500, 20), "Fuel: " + engine.fuelAmount);
    }
}
