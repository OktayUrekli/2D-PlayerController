using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamgeManager : MonoBehaviour
{

    Animator animator;
    [SerializeField] Image healtBarGreen;

    float playerMaxHealt = 100f;
    float playerActiveHealt;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Dead", false);       
        playerActiveHealt = playerMaxHealt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageObj"))
        {
            playerActiveHealt -= 25f;
            if (playerActiveHealt>0)
            {
                float newGreenBarXScale =playerActiveHealt / playerMaxHealt;
                healtBarGreen.fillAmount = newGreenBarXScale;
                animator.SetTrigger("Hurt");
            }
            else
            {
                float newGreenBarXScale = playerActiveHealt / playerMaxHealt;
                healtBarGreen.fillAmount = newGreenBarXScale;
                animator.SetBool("Dead", true);
            }
        }
    }
}
