﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ChildTarget : MonoBehaviour
{
    public static Vector3 OriginalSize;

    public static Vector3 EnlargedSize;

    // Start is called before the first frame update
    void Start()
    {
        OriginalSize = transform.localScale;
        EnlargedSize = new Vector3(1.5f * OriginalSize.x, 1.5f * OriginalSize.y, 1.5f * OriginalSize.z);

    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void OnCollisionEnter(Collision collision)
    {
        //transform.parent.GetComponent<Target>().CollisionDetected(this);
        GetComponent<BoxCollider>().enabled = false;
        StartChildAnimation();
        Target.ChildTargetsHit++;
    }
    
    void StartChildAnimation()
    {
        StartCoroutine(Animations.Enlarge(transform, EnlargedSize, 0.3f));
        //StartCoroutine(Animations.Enlarge(transform, new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z * 1.5f), 0.3f));
        StartCoroutine(Animations.FadeTo(GetComponent<Renderer>().material, 0, 0.3f));
    }

    void Rotation()
    {
        if (transform.tag == "Rotate")
        {
            transform.Rotate(0, 0, -1);
        }
    }
}