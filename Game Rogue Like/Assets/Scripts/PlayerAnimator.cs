using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    PlayerMovement pm;
    SpriteRenderer sr;

    void Awake()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.moveDir.x != 0 || pm.moveDir.y != 0) {
            anim.SetBool("Move", true);
        }
    }
}
