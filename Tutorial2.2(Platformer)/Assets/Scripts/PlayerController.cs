using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //====== Public Variables ======//

    public float speed;
    public float jumpForce;
    public Text countText;
    public Text winText;
    public Text livesText;

    public AudioClip levelMusic;
    public AudioClip winMusic;
    public AudioSource musicSource;

    //===============================//

    //====== Private Variables ======//

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    //===============================//
    

    // Start is called before the first frame update
    void Start()
    {
        
        musicSource.clip = levelMusic;
        musicSource.Play();

        musicSource.loop = true;

        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";

        SetAllText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        //================ Play Music ===================//
        
        

        //================================================//

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        //================================================//
        
        if (Input.GetKey("escape"))Application.Quit();

        if(lives == 0)
        {

            winText.text = "You Lose";
            gameObject.SetActive(false);

        }

        //================================================//
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //=========== Collision Detection ===============//

        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetAllText();
            
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives -= 1;

            SetAllText();

        }

        //=============== Check Score =================//
        
        if(count == 4)
        {
            lives = 3;
            transform.position = new Vector2(32.5F, 0F);

            SetAllText();
        }


                    //====== Victory Zone ======//

        if(count == 8)
        {
            winText.text = "You Win!";

            musicSource.clip = winMusic;
            musicSource.Play();

            musicSource.loop = true;

            transform.position = new Vector2(60F, 0F);
        }
        
        //================================================//
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void SetAllText()
    {
        countText.text = "Count: " + count.ToString();

        livesText.text = "Lives: " + lives.ToString();
    }
}
