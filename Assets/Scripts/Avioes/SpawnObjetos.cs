using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnObjetos : MonoBehaviour
{
    [SerializeField] GameObject spawn, objeto;
    [SerializeField] float fireRate;
    float canShoot = 0.0f;

    private void Update()
    {
        if (Time.time > canShoot)
        {
            Instantiate(objeto, new Vector2(spawn.transform.position.x, spawn.transform.position.y), spawn.transform.rotation);
            canShoot = Time.time + fireRate;
        }         
    }
}


