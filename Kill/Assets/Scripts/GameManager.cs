using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private bool _gotWavedBy = false;
    private GameObject[] _spawners;
    private int _numberOfSpawners = 3;
    private int _randomRange;
    private int _ennemiMax = 3;
    public int waveNumber = 1;

    public int countEnemi;

    public GameObject redGuy;

    public int timer = 0;

    public int score;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            _spawners = GameObject.FindGameObjectsWithTag("Spawners");
            timer = 30;
            StartCoroutine((Wave()));
            
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (countEnemi >= _ennemiMax)
        {
            countEnemi = 0;
            if (timer <= 120)
            {
                timer = timer + 10;
            }

            _ennemiMax = _ennemiMax + 2;
            waveNumber++;
            switch (waveNumber)
            {
                case 4:
                    door1.SetActive(false);
                    break;
                case 7:
                    door2.SetActive(false);
                    break;
                case 10:
                    door3.SetActive(false);
                    break;
                case 13:
                    door4.SetActive(false);
                    break;
                case 16:
                    door5.SetActive(false);
                    break;
                    
            }

            _gotWavedBy = true;
            StartCoroutine(Wave());
        }
    }

    private IEnumerator Wave()
    {
        Debug.Log("Durée wave :" + timer);
        for (int i = 0; i < _ennemiMax; i++)
        {
            _randomRange = Random.Range(0, _numberOfSpawners);
            Instantiate(redGuy, _spawners[_randomRange].transform.position, _spawners[_randomRange].transform.rotation);
            yield return  new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(timer);
        if (_gotWavedBy == false)
        {
            if (timer <= 120)
            {
                timer = timer + 10;
            }

            _ennemiMax = _ennemiMax + 2;
            waveNumber++;
            switch (waveNumber)
            {
                case 4:
                    door1.SetActive(false);
                    break;
                case 7:
                    door2.SetActive(false);
                    break;
                case 10:
                    door3.SetActive(false);
                    break;
                case 13:
                    door4.SetActive(false);
                    break;
                case 16:
                    door5.SetActive(false);
                    break;

            }

            StartCoroutine(Wave());
            countEnemi = 0;
        }

        _gotWavedBy = false;
        yield return 0 ;
    }
}

