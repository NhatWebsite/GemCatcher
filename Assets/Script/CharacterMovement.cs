using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float remaintime = 5f;
    public float time;
    private Animator animator;
    [SerializeField]private  float JumpForce;
    [SerializeField] private int  MaxJumpCount;
    [SerializeField ] private Rigidbody2D rb;
    [SerializeField] private ScoreManager scoreManager ;
    
    private bool isGrounded;
    private int JumpCount;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isGrounded = true;
        //bắt đuầ animation khéop mở chân
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0;
        //khai baos bieens ismoving
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
            //neu nhan vat duy chuyen
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space ) && JumpCount < MaxJumpCount  )
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            JumpCount++;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            JumpCount = 0;

        }
        if (collision.gameObject.tag == "pillar")
        {

            JumpCount = 0;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {

            scoreManager.addScore(2);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "GemDevil")
        {

            scoreManager.addScore(-1);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "GemX2")
        {

            scoreManager.MultipleScore(2);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "GemBooster")
        {

            speed = speed + 5f;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "GemTime")
        {

            time = remaintime + 5f;
            Destroy(collision.gameObject);

        }
    }


}
