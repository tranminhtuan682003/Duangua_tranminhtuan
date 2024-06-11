using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private float speed = 10f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime);
        animator.SetFloat("vertical", 1);
        StartCoroutine(ChangeAnimation());

    }

    IEnumerator ChangeAnimation()
    {
        yield return new WaitForSeconds(5f);
        animator.SetFloat("vertical", 0.5f);
        speed = speed / 2;
        //yield return new WaitForSeconds(2f);
        //animator.SetFloat("vertical", 0.25f);
        //speed = speed / 4;
        //yield return new WaitForSeconds(2f);
        //animator.SetFloat("vertical", 0f);
        //speed = 0;

    }

}
