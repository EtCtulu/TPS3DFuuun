using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private GameObject[] _spawners;

    private int _timer = 0;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            //_spawners = GameObject.FindGameObjectsWithTag("Spawner");
            _timer = 30;
            StartCoroutine((Wave()));
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Wave()
    {
        Debug.Log("Durée wave :" + _timer);
        yield return new WaitForSeconds(_timer);
        _timer = _timer + 10;
        StartCoroutine(Wave());
        yield return 0 ;
    }
}

