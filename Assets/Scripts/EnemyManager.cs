using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] Animator enemyAnimator;
    [SerializeField] GameObject bullet,gun;

    private void Start()
    {
        enemyAnimator=GetComponent<Animator>();
    }

    void EnemyAttack()
    {
        Instantiate(bullet,Vector3.forward, Quaternion.identity,gun.gameObject.transform);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyAnimator.SetBool("AttackToPlayer", true);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            Invoke("EnemyAttack", 1.5f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyAnimator.SetBool("AttackToPlayer", false);
        }
    }
}
