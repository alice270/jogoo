using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{ 
    public Rigidbody2D rbody;
    private float speed = 10f;
    public Animator anim;
    private static bool playerExists;
    public bool batalha;
    public event Action iniciarBatalha;


    public void HandleUpdate()
    {
        UnityEngine.Vector2 movement = new UnityEngine.Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(movement != UnityEngine.Vector2.zero)
        {
            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", movement.x);
            anim.SetFloat("input_y", movement.y);
        }
        else
        {
            anim.SetBool("is_walking", false);
        }
        rbody.MovePosition(rbody.position + movement * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.O))
        {
            iniciarBatalha();
        }
    }
    /* public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy") && other.isTrigger)
        {
            iniciarBatalha();
        }
    }*/
}
