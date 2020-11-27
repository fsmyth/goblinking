using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{

    public GameObject projectile;
    private GameObject clone;

    // Instantiate the crossbow bolt when this function is called.
    public void bolt()
    {
        //Debug.Log("projectile");
        clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        
        //Destroy bullet after 2sec
        Destroy(clone, 2.0f);
        }
    
}
