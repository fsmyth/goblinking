using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //When the projectile collides with something, delete it.
    void OnTriggerEnter() {
        gameObject.SetActive(false);
    }
}
