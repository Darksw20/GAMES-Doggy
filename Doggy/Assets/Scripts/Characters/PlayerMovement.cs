﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool isJumping = false;
    bool isCrouching = false;
    public AudioClip jump;
    AudioSource musicObject;

    void Update()
    {
        musicObject = GameObject.FindGameObjectsWithTag("JumpSound")[0].GetComponent<AudioSource>();

        if (!pauseController.isPaused)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (gameObject.transform.position.y <= -10 && SceneManager.GetActiveScene().name == "Level1_1")
            {
                Vector2 vector2 = new Vector2(1.84F, -0.38F);
                gameObject.transform.position = vector2;
                GameManager.instancia.health--;
                if (GameManager.instancia.health == 0)
                {
                    // 0 vidas
                }
            }

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                musicObject.PlayOneShot(jump);
            }
            if (Input.GetButtonDown("Crouch"))
                isCrouching = true;
            else if (Input.GetButtonUp("Crouch"))
                isCrouching = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
    }
}
