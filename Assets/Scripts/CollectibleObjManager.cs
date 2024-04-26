using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleObjManager : MonoBehaviour
{
    Animator myAnimator;

    [SerializeField] TextMeshProUGUI coinCountText;
    [SerializeField] Image heartImage, swordImage;

    public bool hasSword;

    int coinCount = 0;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("HasSword", false);
        hasSword = false;               
        swordImage.gameObject.SetActive(false);
        heartImage.gameObject.SetActive(false);
        WriteCoinCountToUI(coinCount);
    }

    void WriteCoinCountToUI(int coin_count)
    {
        coinCountText.text = coin_count.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            WriteCoinCountToUI(coinCount);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Heart"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                heartImage.gameObject.SetActive(true);
                Destroy(collision.gameObject);
            }           
        }
        else if (collision.gameObject.CompareTag("Sword"))
        {
            hasSword = true;
            myAnimator.SetBool("HasSword", true);
            swordImage.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
