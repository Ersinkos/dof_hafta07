using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    int toplananCoin=0;
    int toplamCoin;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        print("carpisma");
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isDestroy", true);
            Destroy(gameObject,1);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
