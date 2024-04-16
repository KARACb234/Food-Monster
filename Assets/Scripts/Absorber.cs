using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorber : MonoBehaviour
{
    private FuelBank _fuelBank;
    private CarSize _carSize;
    private bool _isConnect;
    [SerializeField]
    private float _delay;

    // Start is called before the first frame update
    void Start()
    {
        _fuelBank = GetComponent<FuelBank>();
        _carSize = GetComponent<CarSize>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _isConnect = true;
            StartCoroutine(AbsorberProcess(collision.transform));
        }
    }

    private IEnumerator AbsorberProcess(Transform collisionTransform )
    {
        while (_isConnect == true)
        {
            yield return new WaitForSeconds(_delay);
            if(collisionTransform == null)
            {
                break;
            }
            collisionTransform.localScale -= new Vector3(0.6f, 0.6f, 0.6f);
            _carSize.Increase(0.1f);
            if (collisionTransform.localScale.x < 0.5f)
            {
                Destroy(collisionTransform.gameObject);
                break;
            }
        }
        
    }
    public float GetSizeObject(Transform objectScale)
    {
        float scale = objectScale.localScale.x + objectScale.localScale.y + objectScale.localScale.z;
        return scale;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _isConnect = false;
        }
    }
}
