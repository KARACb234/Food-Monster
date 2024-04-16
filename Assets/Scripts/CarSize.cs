using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSize : MonoBehaviour
{
    [SerializeField]
    private float _delay;
    [SerializeField]
    private float _reductionFactor;
    [SerializeField]
    private Transform _skinTransform;
    [SerializeField]
    private float _minSize;
    [SerializeField]
    private float _maxSize;
    [SerializeField]
    private Transform _cameraTransform;
    private FuelBank _fuelBank;
    [SerializeField]
    private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DecreaseCorutine());
        _fuelBank = GetComponent<FuelBank>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            UpdateCameraPosition(3);
            _skinTransform.localScale = new Vector3(3, 3, 3);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            UpdateCameraPosition(50);
            _skinTransform.localScale = new Vector3(50, 50, 50);
        }
    }
    
    public void Increase(float magnificationFactor)
    {

        if(_skinTransform.localScale.x < _maxSize)
        {
            _skinTransform.localScale += new Vector3(magnificationFactor, magnificationFactor, magnificationFactor);
            _fuelBank.AddFuel(magnificationFactor);
        }
        else
        {
            _skinTransform.localScale = new Vector3(_maxSize, _maxSize, _maxSize);
        }
        UpdateCameraPosition(_skinTransform.localScale.z);
        _scoreManager.AddScore(10);
    }

    public void Decrease(float reductionFactor)
    {

        if (_skinTransform.localScale.x > _minSize)
        {
            _skinTransform.localScale -= new Vector3(reductionFactor, reductionFactor, reductionFactor);
        }
        else
        {
            _skinTransform.localScale = new Vector3(_minSize, _minSize, _minSize);
        }
    }
    IEnumerator DecreaseCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Decrease(_reductionFactor);
        }
    }
    private void UpdateCameraPosition(float sizeZ)
    {
        float positionZ = sizeZ.Remap(3, 50 ,-9, -71f);
        float positionY = sizeZ.Remap(3, 50, 5, 48);
        _cameraTransform.localPosition = new Vector3(_cameraTransform.localPosition.x, positionY, positionZ);
    }

}
