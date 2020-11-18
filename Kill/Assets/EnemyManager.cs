using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float hp = 100;
    public GameObject player;
    public float speed = 6f;
    private Vector3 playerPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ExplosionMine")
        {
            hp = hp - 100;
            if(hp >= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
