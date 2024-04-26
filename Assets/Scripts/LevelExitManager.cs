using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelExitManager : MonoBehaviour
{
    [SerializeField] GameObject yesNoPanel;

    private void Start()
    {
        yesNoPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            yesNoPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            yesNoPanel.SetActive(false);
        }
    }

    public void YesButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NoButton()
    {
        yesNoPanel.SetActive(false);
    }
}
