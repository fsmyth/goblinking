using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        //Apply accelleration to the projectile
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
