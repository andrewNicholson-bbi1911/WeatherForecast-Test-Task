using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    private float _lowestY = -44;
    private float _highestY = -38;
    private float _speedOfLevitating = 0.5f;
    private Vector3 _levitatingVector = new Vector3(0, 1, 0);
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= _lowestY | transform.position.y >= _highestY)
            _levitatingVector *= -1;
        transform.Translate(_levitatingVector * _speedOfLevitating * Time.deltaTime);
    }
}
