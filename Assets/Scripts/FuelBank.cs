using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBank : MonoBehaviour
{
    [SerializeField]
    private float _fuel;
    public float GetFuel => _fuel;
    [SerializeField]
    private float _addFuel;
    [SerializeField]
    private float _fuelConsumption;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveFuel()
    {
        _fuel -= _fuelConsumption * Time.deltaTime;
    }
    public void RemoveFuelWitnLight()
    {
        float lightConsumption = (_fuelConsumption / 10) * Time.deltaTime;
        _fuel -= lightConsumption;
    }
    public void AddFuel(float fuel )
    {
        _fuel +=fuel;
    }
    }
