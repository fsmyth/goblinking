using UnityEngine;
using UnityEngine.UI;

public class Crossbow : MonoBehaviour
{
    public float damage = 1f;
    public float range = 100f;
    public int ammo;
    public Text ammoText;

    public Camera shootCam;
    public GameObject gm;
    public ActivateProjectile ap;

    void Start() {
        ap = gm.GetComponent<ActivateProjectile>();
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo>0) { //When the player clicks fire, make sure they have ammo, then run the shoot function and the bolt function.
            Shoot();
            ap.bolt();

        }

        ammoText.text = "Ammo: " + ammo.ToString();
    }

    void Shoot() { //This function sends a raycast to check if the player hit anything.
        RaycastHit hit;
        ammo--; //Remove 1 ammo
        // Debug.Log (ammo);
        if (Physics.Raycast(shootCam.transform.position, shootCam.transform.forward, out hit, range)) {
            // Debug.Log(hit.transform.name); //Tell the console what the player hit

            Enemy enemy = hit.transform.GetComponent<Enemy>(); //If the player hit an enemy, damage the enemy
            if (enemy != null) {
                enemy.HurtEnemy(damage);
            }
//8:13
        }
    }
}
