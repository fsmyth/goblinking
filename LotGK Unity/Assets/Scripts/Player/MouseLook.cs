using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private GameObject player;
    private float minClamp = -45;
    private float maxClamp = 45;

    [HideInInspector] //These are public so other game objects, etc. can access them, but they will not be displayed in the Unity Editor
    public Vector2 rotation;
    private Vector2 currentLookRot;
    private Vector2 rotationV = new Vector2(0,0);

    public float lookSensitivity = 2;
    public float lookSmoothDamp = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {   //Change the sensitivity of the player camera.
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;
        //clamping the look values, do not look up or down too far.
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);
        //rotating the character based on the Mouse x-pos
        player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X")* lookSensitivity);
        //smooth current Y rotation
        currentLookRot.y = Mathf.SmoothDamp(currentLookRot.y, rotation.y, ref rotationV.y, lookSmoothDamp);
        //update camera x
        transform.localEulerAngles = new Vector3(-currentLookRot.y,0,0);
    }
}
