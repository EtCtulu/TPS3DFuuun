using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUDed : MonoBehaviour
{
    private GameObject[] _totalEnnemies = null;

    private void Start()
    {
        StartCoroutine(areyoudead());
    }

    IEnumerator areyoudead()
    {
        yield return new WaitForSeconds(2);
        _totalEnnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (_totalEnnemies == null)
        {
            Debug.Log("Enemy Null" + _totalEnnemies);
            GameManager._instance.timer = 1;
            Destroy(gameObject);
        }

        if (_totalEnnemies != null)
        {
            Debug.Log("Enemy Not Null" + _totalEnnemies);
            Destroy(gameObject);
        }
    }
}
