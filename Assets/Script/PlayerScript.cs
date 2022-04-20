using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;

    [SerializeField] 
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;

    public Text ScoreText;

    public Text Instructions;

    public GameObject CanvasGameObject;

    public Button RetryButton;

    public AudioSource jumpSound;

    public AudioSource splatSound;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        RetryButton.onClick.AddListener(RetryOnClick);
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(Instructions, 5);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
                if (!jumpSound.isPlaying)
                {
                    jumpSound.Play();
                }
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreText.text = "Score: " + score.ToString("F");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            if (!splatSound.isPlaying)
            {
                splatSound.Play();
            }
            isAlive = false;
            CanvasGameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RetryOnClick()
    {
        //CanvasGameObject.SetActive(false);
        Time.timeScale = 1;
        
        SceneManager.LoadScene("SampleScene");

    }


}
