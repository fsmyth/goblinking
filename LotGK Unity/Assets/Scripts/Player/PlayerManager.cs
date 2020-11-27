using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance; //Allow only one instance of the player manager

    void Awake() { //Ensure there is an instance of this object on Awake.
        instance = this;
    }

    #endregion

    public GameObject player;

}
