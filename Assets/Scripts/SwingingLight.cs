using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingLight : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(Timer());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }

    IEnumerator Timer()
    {
        animator.SetBool("onLanded", true);
        yield return new WaitForSeconds(1.0f);
            animator.SetBool("onLanded", false);

    }
}
