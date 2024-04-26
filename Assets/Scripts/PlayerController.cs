using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    Transform myTransform;
    SpriteRenderer mySpriteRenderer;

    [SerializeField] int jumpForce = 250;
    [SerializeField] float speedMul;
   
     CollectibleObjManager myCollectibleObjManager;

    
    bool isGrounded;
    float speedX;
    Vector3 direction;
    

    void Start()
    {
        myCollectibleObjManager=GetComponent<CollectibleObjManager>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();  
        myTransform=GetComponent<Transform>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        ChangeDirection(speedX);
        PlayerMovement(speedX);
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) { PlayerJump(); }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded) {  myAnimator.SetTrigger("Slide");  }
        else if (Input.GetKeyDown(KeyCode.Q) && myCollectibleObjManager.hasSword) { myAnimator.SetTrigger("Attack"); }
    }


    void PlayerMovement(float speed_x)
    {
        myAnimator.SetFloat("SpeedX", Mathf.Abs(speed_x));

        direction=new Vector3 (speed_x,0,0);

        myTransform.position += direction * speedMul*Time.deltaTime ;
    }

    void ChangeDirection(float speed)
    {
        if (speed < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
       
    }

    void PlayerJump()
    {  
        myRigidbody.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        myAnimator.SetTrigger("Jump");
        myAnimator.SetBool("Grounded", false);
        isGrounded = false; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("DamageObj"))
        {
            myAnimator.SetBool("Grounded", true);
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("DamageObj"))
        {
            myAnimator.SetTrigger("Hurt");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        

    }

}
