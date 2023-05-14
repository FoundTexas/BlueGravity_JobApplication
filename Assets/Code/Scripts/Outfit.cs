using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Outfit : MonoBehaviour
{
    Animator anim, parent;

    private void Start()
    {
        anim = GetComponent<Animator>();
        parent = Player.inst.gameObject.GetComponent<Animator>();

    }

    private void Update()
    {

        anim.SetFloat("mag", parent.GetFloat("mag"));
        anim.SetFloat("X", parent.GetFloat("X"));
        anim.SetFloat("Y", parent.GetFloat("Y"));
    }
}
