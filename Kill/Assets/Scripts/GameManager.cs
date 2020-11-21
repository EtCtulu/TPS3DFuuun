using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private GameObject[] _spawners;
    private int _randomRange;
    private int _ennemiMax = 3;

    public GameObject redGuy;

    private int _timer = 0;

    public int score;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            _spawners = GameObject.FindGameObjectsWithTag("Spawners");
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
        for (int i = 0; i < _ennemiMax; i++)
        {
            _randomRange = Random.Range(0, 7);
            Instantiate(redGuy, _spawners[_randomRange].transform.position, _spawners[_randomRange].transform.rotation);
            yield return  new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(_timer);
        _timer = _timer + 10;
        _ennemiMax = _ennemiMax + 2;
        StartCoroutine(Wave());
        yield return 0 ;
    }
}

