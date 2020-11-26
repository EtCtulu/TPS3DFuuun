using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDetection : MonoBehaviour
{

    public GameObject blast;

    private bool _engageTimeEnded = false;

    void Start()
    {
        StartCoroutine(WaitBeforeExplosion());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && _engageTimeEnded == true)
        {
            blast.SetActive(true);
            StartCoroutine(ExplosionEnd());
        }
    }
    private IEnumerator ExplosionEnd()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private IEnumerator WaitBeforeExplosion()
    {
        yield return new WaitForSeconds(3f);
        _engageTimeEnded = true;
    }
}
