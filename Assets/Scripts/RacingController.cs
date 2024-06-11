using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingController : MonoBehaviour
{
    public List<GameObject> horses;
    [SerializeField] private float speed = 10f;

    private void Awake()
    {
        if (horses == null)
        {
            horses = new List<GameObject>();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(WaitForStart());
    }

    private void HorseRacing()
    {
        foreach (var horse in horses)
        {
            horse.transform.Translate(0, 0, Random.Range(speed,speed/2) * Time.deltaTime);

            Animator animator = horse.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetFloat("vertical", 1);
            }
        }
    }
    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(3f);
        HorseRacing();
    }
}
