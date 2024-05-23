using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [04/23/2024]
 * [The turbo charger system of a bike engine that boosts the bike engine for a specific duration]
 */

public class TurboCharger : MonoBehaviour
{
    //reference to our facade (bike engine)
    public BikeEngine engine;

    //determines if the turbo has been activated or not
    private bool isTurboOn;

    //reference to the bikes cooling system component
    private CoolingSystem _coolingSystem;

    /// <summary>
    /// Enables/disables the bike engines turbo mode to go faster, but pauses cooling
    /// </summary>
    /// <param name="coolingSystem"> the passed in cooling system of a bike engine </param>
    public void ToggleTurbo(CoolingSystem coolingSystem)
    {
        //initialize the cooling system to the passed in cooling system parameter
        _coolingSystem = coolingSystem;

        //if the turbo is not on
        if(!isTurboOn)
        {
            //enable the turbo
            StartCoroutine(TurboCharge());
        }
    }

    /// <summary>
    /// Enables the turbo for the bike engine for a specific duration
    /// </summary>
    /// <returns> the turbo mode's duration </returns>
    public IEnumerator TurboCharge()
    {
        //set is turbo on to true and pasue cooling in the cooling system
        isTurboOn = true;
        _coolingSystem.PauseCooling();

        //wait for the turbo duration befor disabling the turbo mode
        yield return new WaitForSeconds(engine.turboDuration);

        //set is turbo on to false and start cooling again in the cooling system
        isTurboOn = false;
        _coolingSystem.PauseCooling();
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //change the UI color to green
        GUI.color = Color.green;

        //display the engine's turbo status
        GUI.Label(new Rect(100, 60, 500, 20), "Turbo Activated: " + isTurboOn);
    }
}
