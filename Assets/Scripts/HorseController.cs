using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    private Animator animator;
    private float maxSpeed = 20f;
    private float currentSpeed;
    private float distanceTraveled;
    private float checkDistance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        distanceTraveled = 0f;
        checkDistance = 30f;
        UpdateSpeed();
    }

    void FixedUpdate()
    {
        UpdateAnimation();
        MoveHorse();

    }
    void Update()
    {
    }
    private void MoveHorse()
    {
        float distanceThisFrame = currentSpeed * Time.deltaTime;
        transform.Translate(0, 0, distanceThisFrame);
        distanceTraveled += distanceThisFrame;
        Debug.Log(distanceTraveled);

        if (distanceTraveled >= checkDistance)
        {
            checkDistance += 30f;
            UpdateSpeed();
        }
    }

    private void UpdateSpeed()
    {
        if (distanceTraveled < 400f && distanceTraveled >= 0f)
        {
            currentSpeed = maxSpeed * Random.Range(0.85f, 1f);
        }
        else if(distanceTraveled >=400f && distanceTraveled < 630f)
        {
            currentSpeed = maxSpeed * Random.Range(1f, 1.2f);
        }
        else
        {
            currentSpeed = maxSpeed * 0.1f;
        }
    }

    private void UpdateAnimation()
    {
        if (distanceTraveled < 15f && distanceTraveled >= 0f)
        {
            animator.SetFloat("vertical", 0.5f);
        }
        else if (distanceTraveled < 630f && distanceTraveled >= 15f)
        {
            animator.SetFloat("vertical", 1f);
        }
        else
        {
            animator.SetFloat("vertical", 0.25f);
        }
    }
}
