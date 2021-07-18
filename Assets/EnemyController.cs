using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public bool getHit = false;
    public float health;
    private Animator anim;
    private Collider colliderG;
    private NavMeshAgent agent;
    private GameObject player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        colliderG = gameObject.GetComponent<CapsuleCollider>();
        health = 100;
        anim.SetFloat("speed", 1f);
        
    }


    // Update is called once per frame
    void Update()
    {
        if (getHit)
        {
            health -= 20;
            getHit = false;

            //anim.SetFloat("speed", 0f);
            //agent.isStopped = true;
            if (health <= 0)
            {
                anim.SetBool("death", true);
                anim.SetBool("attack", false);
                Destroy(colliderG);
                Destroy(agent);
                Destroy(this);
            }
            else
            {
                anim.SetTrigger("hit");
            }
            return;
        }
     
            gameObject.transform.LookAt(player.transform);
            agent.SetDestination(player.transform.position);
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 20)
            {
                anim.SetBool("attack", false);
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= 3)
                {
                    agent.isStopped = false;
                    anim.SetFloat("speed", Vector3.Distance(gameObject.transform.position, player.transform.position)/20f);
                }
                else
                {
                    agent.isStopped = true;
                    anim.SetFloat("speed", 0f);
                    anim.SetBool("attack", true);
                }
            }
            else
            {
                agent.isStopped = true;
                anim.SetFloat("speed", 0f);
                
            }
    }
    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
