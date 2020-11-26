using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{

    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player Model").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.transform.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
