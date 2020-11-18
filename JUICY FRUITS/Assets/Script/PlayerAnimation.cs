using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator myanim;
    void Start()
    {
        myanim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mover(float mover)
    {
        myanim.SetFloat("Mover", (mover));
    }
}

