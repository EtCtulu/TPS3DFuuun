using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    [Header("Variables")] public float hp = 100f;

    // Déclaration en privé du joueur et de l'agent
    private GameObject player;
    private NavMeshAgent agent;

    // La destination
    Vector3 destination;

    // Attack Pattern
    bool attack = false;

    // Attack prefab
    public GameObject attackPre;


    void Start()
    {
        // On cherche le joueur puis l'agent
        player = GameObject.FindWithTag("Player Model");
        agent = GetComponent<NavMeshAgent>();
        // On cherche l'objet dans le gameObject des dégats
        attackPre = this.transform.Find("Attack").gameObject;
        destination = player.transform.position;
        agent.destination = destination;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.transform.eulerAngles.y,
            transform.rotation.eulerAngles.z);

        // Si l'enemy est proche du joueur, l'attaque est lancée après 1 seconde
        if ((this.transform.position - player.transform.position).sqrMagnitude < 2f && attack == false)
        {
            // Le joueur est détecté, l'enemy s'arrète
            destination = this.transform.position;
            agent.destination = destination;
            StartCoroutine(Attack());
        }


        // La destination est set a Player, on recherche donc son transform
        destination = player.transform.position;
        // On déclare que la destination est set a destination
        agent.destination = destination;

        // Permets de définir une localisation celle-ci est le player
        Vector3 direction = (player.transform.position - transform.position).normalized;


    }

    private IEnumerator Attack()
    {
        attack = true;
        destination = this.transform.position;
        agent.destination = destination;
        yield return new WaitForSeconds(0.5f);
        attackPre.SetActive(true);
        destination = this.transform.position;
        agent.destination = destination;
        yield return new WaitForSeconds(1f);
        destination = this.transform.position;
        agent.destination = destination;
        attackPre.SetActive(false);
        // La destination est set a Player, on recherche donc son transform
        destination = player.transform.position;
        // On déclare que la destination est set a destination
        agent.destination = destination;
        attack = false;
        yield return (0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExplosionMine"))
        {
            hp = hp - 100;
            if (hp >= 0)
            {
                Destroy(gameObject);
            }
        }

        
    }
    private void OnDestroy()
    {
        GameManager._instance.score = GameManager._instance.score + 100;
        Debug.Log("Score : " + GameManager._instance.score);
        //FindObjectOfType<AudioManager>().Play("ImpDeath");
        GameManager._instance.countEnemi++;
    }
}



    

