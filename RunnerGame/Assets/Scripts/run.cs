using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class run : MonoBehaviour
{
    Animator animator;
    Animator coinAnimator;
    public float hizCarpani;
    Rigidbody rb;
    int toplananCoin = 0;
    int toplamCoin;
    public bool isGrounded = true;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    public TextMeshProUGUI toplananCoinText;
    public TextMeshProUGUI gameFinishedText;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("ToplamCoin", 0);
        animator = GetComponent<Animator>();
        coinAnimator = GameObject.Find("coin").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        print("Þu ana dek toplanan coinler : " + PlayerPrefs.GetInt("ToplamCoin"));
        hizCarpani = PlayerPrefs.GetFloat("PlayerSpeed");
        toplananCoinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        gameFinishedText = GameObject.Find("GameFinished").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, hizCarpani) * Time.deltaTime);
        }
        else animator.SetBool("isRunning", false);
        if (Input.GetKey(KeyCode.A))
        {
            //animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(-hizCarpani, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(hizCarpani, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, -hizCarpani) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
        GroundCheck();
        animator.SetBool("isGround", isGrounded);
        if (isFalling())
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("tuzak"))
        {
            Destroy(gameObject);
            toplamCoin = PlayerPrefs.GetInt("ToplamCoin");
            toplamCoin += toplananCoin;
            PlayerPrefs.SetInt("ToplamCoin", toplamCoin);

        }
        if (other.CompareTag("coin"))
        {
            toplananCoin++;
            toplananCoinText.text = toplananCoin.ToString();
            coinAnimator.SetBool("isDestroy", true);
            Destroy(other.gameObject, 1);
        }
        if (other.CompareTag("FinishLine"))
        {
            gameFinishedText.enabled = true;

        }
    }
    public void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
    public bool isFalling()
    {
        bool isFalling = false;
        if (gameObject.transform.position.y <= -2) isFalling = true;
        return isFalling;
    }

}
