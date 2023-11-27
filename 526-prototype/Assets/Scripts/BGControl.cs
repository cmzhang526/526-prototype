using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGControl : MonoBehaviour
{
    private CharacterController2D cc;
    bool fixedBG = false;
    void Start()
    {
        cc = gameObject.GetComponentInParent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cc.m_FacingRight && !fixedBG)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            fixedBG = true;
        }
        if (cc.m_FacingRight && fixedBG)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            fixedBG = false;
        }
    }
}
