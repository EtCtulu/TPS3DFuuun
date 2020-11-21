using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDetection : MonoBehaviour
{

    public GameObject blast;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
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
}
