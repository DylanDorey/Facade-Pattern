using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [04/23/2024]
 * [The engine of a bike controller that burns fuel and raises/lowers temperature (the facade)]
 */

public class BikeEngine : MonoBehaviour
{
    //fuel system and temperature system variables
    public float burnRate = 1f;
    public float fuelAmount = 100f;
    public float tempRate = 5f;
    public float minTemp = 50f;
    public float maxTemp = 65f;
    public float turboDuration = 2f;
    public float currentTemp;

    //determines if the engine is on or not
    private bool isEngineOn;

    //references to the fuel pump, cooling system, and turbo charger components
    private FuelPump _fuelPump;
    private CoolingSystem _coolingSystem;
    private TurboCharger _turboCharger;

    private void Awake()
    {
        //initialize the fuel pump, cooling system, and turbo charger components by adding them to this game object
        _fuelPump = gameObject.AddComponent<FuelPump>();
        _coolingSystem = gameObject.AddComponent<CoolingSystem>();
        _turboCharger = gameObject.AddComponent<TurboCharger>();
    }

    private void Start()
    {
        //initialize the Bike Engine class for each of the fuel pump, cooling system, and turbo charger components
        _fuelPump.engine = this;
        _turboCharger.engine = this;
        _coolingSystem.engine = this;
    }

    /// <summary>
    /// Turns on the bike engine
    /// </summary>
    public void TurnOn()
    {
        //set is engine on to true
        isEngineOn = true;

        //start burning fuel and start cooling the engine from both the fuel pump, and cooling system components
        StartCoroutine(_fuelPump.burnFuel);
        StartCoroutine(_coolingSystem.coolEngine);
    }

    /// <summary>
    /// Turns off the bike engine
    /// </summary>
    public void TurnOff()
    {
        //set is engine on to false
        isEngineOn = false;

        //stop burning fuel and stop cooling the engine from both the fuel pump, and cooling system components
        StopCoroutine(_fuelPump.burnFuel);
        StopCoroutine(_coolingSystem.coolEngine);
    }

    /// <summary>
    /// Turns the turbo system on
    /// </summary>
    public void ToggleTurbo()
    {
        //if the bike engine is on
        if (isEngineOn)
        {
            //Access the turbo charger system and turn the turbo on/off. Pass in this bikes cooling system to cool the engine
            _turboCharger.ToggleTurbo(_coolingSystem);
        }
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //change the UI color to green
        GUI.color = Color.green;

        //display the status of the engine (if it is on or off)
        GUI.Label(new Rect(100, 0, 500, 20), "Engine Running: " + isEngineOn);
    }
}
