using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacingController : MonoBehaviour
{
    public static RacingController instance;

    public List<GameObject> horses;
    public List<TextMeshProUGUI> nameHourse;
    [SerializeField] private float speed = 10f;

    private void Awake()
    {
        horses = new List<GameObject>();
        nameHourse = new List<TextMeshProUGUI>();
    }

    public static RacingController Instace()
    {
        if(instance == null)
        {
            instance = new RacingController();
        }
        return instance;
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
            horse.transform.Translate(0, 0, speed * Time.deltaTime);
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

    private void SetAnimation()
    {
        if(speed == speed / 2)
        {
        }
    }

}
