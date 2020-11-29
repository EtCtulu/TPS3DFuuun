using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private bool _isItemOn = true;
    public GameObject itemToSpawn;
    public GameObject locationToUse;

    private void Start()
    {
        Instantiate(itemToSpawn, locationToUse.transform);
        _isItemOn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _isItemOn == true)
        {
            _isItemOn = false;
            StartCoroutine(SpawnerTimer());
        }
    }

    private IEnumerator SpawnerTimer()
    {
        yield return new WaitForSeconds(30f);
        Instantiate(itemToSpawn, locationToUse.transform);
        _isItemOn = true;
        yield return 0;
        
    }
}
