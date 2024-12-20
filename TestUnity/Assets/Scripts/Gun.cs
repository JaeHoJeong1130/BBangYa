﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float hitForce = 30f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        
    }
    void Fire()
    {
        muzzleFlash.Play();
        audioSource.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,
            fpsCam.transform.forward,
            out hit,
            range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
            GameObject hitEffectObj = Instantiate(hitEffect,
                hit.point,
                Quaternion.LookRotation(-hit.normal));
            Destroy(hitEffectObj, 2f);
        }
    }
}
