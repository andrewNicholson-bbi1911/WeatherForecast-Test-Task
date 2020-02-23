using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerWeatherPrefab : MonoBehaviour
{
    [SerializeField] private GameObject[] _cloudPrefabs;
    [SerializeField] private GameObject _sun;
    [SerializeField] private ParticleSystem _rainAndSnow;
    [SerializeField] private Text _conditionField;

    private Color _snowColor = new Color (0.8382432f, 0.8382432f, 0.957f);
    private Color _rainColor = new Color(0.4386792f, 0.7502781f, 1f);


    private void Start()
    {
        _rainAndSnow.Stop();
    }

    public void InstantiateClouds()
    {
        Reset();

        if (_conditionField.text.Contains("clear")) {
            Instantiate(_sun, transform);
        }
        else if (_conditionField.text.Contains("cloudy"))
        {
            Instantiate(_sun, transform);
            Instantiate(_cloudPrefabs[0], transform);
        }
        else if (_conditionField.text.Contains("overcast"))
        {
            Instantiate(_cloudPrefabs[1], transform);
        }
        else if (_conditionField.text.Contains("thunderstorms"))
        {
            Instantiate(_cloudPrefabs[2], transform);
            _rainAndSnow.startColor = _rainColor;
            _rainAndSnow.Play();
        }

        if (_conditionField.text.Contains("snow"))
        {
            _rainAndSnow.startColor = _snowColor;
            _rainAndSnow.Play();
        }
        else if (_conditionField.text.Contains("rain"))
        {
            _rainAndSnow.startColor = _rainColor;
            _rainAndSnow.Play();
        }
        
    }

    private void Reset()
    {
        _rainAndSnow.Stop();
        foreach(Transform child in GetComponentsInChildren<Transform>())
            if(!child.GetComponent<SpawnerWeatherPrefab>())
                Destroy(child.gameObject);
    }
}
