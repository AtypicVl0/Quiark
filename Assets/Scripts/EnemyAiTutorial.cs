using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent enemy;
    private PlayerMovement plyrmvmnt;
    public Transform player;

    private Animator anim;

    private void Start()
    {
        plyrmvmnt = player.GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //anim.SetBool("Run", true);
        enemy.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            Debug.Log("icerdema");
            plyrmvmnt.slide.value -= 0.01f;
            anim.SetBool("Run", false);
            anim.SetBool("Atak", true);
            plyrmvmnt.anim.SetBool("Attack", true);
            StartCoroutine(die());
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            anim.SetBool("Atak", false);
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
