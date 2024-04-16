using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Car : MonoBehaviour
{
    private FuelBank _fuelBank;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private Light _spotLight;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _force;
    [SerializeField]
    private BorderClamp _positionClampX;
    [SerializeField]
    private BorderClamp _positionClampY;
    [SerializeField]
    private BorderClamp _positionClampZ;
    [SerializeField]
    private float _speedBost;
    [SerializeField]
    private float _powerUpTime;
    [SerializeField]
    private Slider _powerUpSlider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _fuelBank = GetComponent<FuelBank>();

    }    
    private void Update()
    {
        BorderController();
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(_spotLight.enabled == false)
            {
                _spotLight.enabled = true;
            }
            else
            {
                _spotLight.enabled = false;
            }
        }

        if (_fuelBank.GetFuel > 0)
        {
            Move();
        }
    }
    void Move()
    {
        _fuelBank.RemoveFuel();
        float vertycalInput = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
        _rigidbody.AddForce(transform.forward * _force * vertycalInput, ForceMode.VelocityChange);
        transform.Rotate(0, horizontalInput, 0);
        if(_spotLight.enabled == true )
        {
            _fuelBank.RemoveFuelWitnLight();
        }
    }
    private void BorderController()
    {
        if (transform.position.x > _positionClampX.GetMaximum)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        if (transform.position.x < _positionClampX.GetMinimum)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        if (transform.position.z > _positionClampZ.GetMaximum)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        if (transform.position.z < _positionClampZ.GetMinimum)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        Vector3 currentPosition = transform.position;
        float clampX = Mathf.Clamp(currentPosition.x, _positionClampX.GetMinimum, _positionClampX.GetMaximum);
        float clampY = Mathf.Clamp(currentPosition.y, _positionClampY.GetMinimum, _positionClampY.GetMaximum);
        float clampZ = Mathf.Clamp(currentPosition.z, _positionClampZ.GetMinimum, _positionClampZ.GetMaximum);
        transform.position = new Vector3(clampX, clampY, clampZ);
    }
    public void Acceleration()
    {
        _speed += _speedBost;
        StartCoroutine(PowerUpTime());
    }

    private IEnumerator PowerUpTime()
    {
        _powerUpSlider.maxValue = _powerUpTime;
        float time = 0;
        while(time < _powerUpTime)
        {
            time += Time.deltaTime;
            _powerUpSlider.value = time;
            yield return new WaitForEndOfFrame();
        }
        _powerUpSlider.value = 0;
        _speed -= _speedBost;

    }
}
[Serializable]
public class BorderClamp
{
    [SerializeField]
    private float _minimal;
    [SerializeField]
    private float _maximum;

    public float GetMinimum => _minimal;
    public float GetMaximum => _maximum;
}
