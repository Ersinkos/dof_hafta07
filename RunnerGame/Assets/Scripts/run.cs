using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    Animator animator;
    Animator coinAnimator;
    public float hizCarpani;
    Rigidbody rb;
    int toplananCoin = 0;
    int toplamCoin;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("ToplamCoin", 0);
        animator = GetComponent<Animator>();
        coinAnimator = GameObject.Find("coin").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        print("Þu ana dek toplanan coinler : "+PlayerPrefs.GetInt("ToplamCoin"));
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
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
            coinAnimator.SetBool("isDestroy", true);
            Destroy(other.gameObject, 1);
        }
    }
}
