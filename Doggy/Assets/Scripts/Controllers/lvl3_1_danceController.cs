using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_1_danceController : MonoBehaviour
{

    public GameObject ana;
    public GameObject perrero;

    private Animator anaAnimator;
    private Animator perreroAnimator;

    private Vector2 movement;

    void Start()
    {
        anaAnimator = ana.GetComponent<Animator>();
        perreroAnimator = perrero.GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anaAnimator.SetFloat("x", movement.x);
        anaAnimator.SetFloat("y", movement.y);
    }
}
