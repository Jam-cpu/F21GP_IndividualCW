using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileGun : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading;

    // reference points
    public Camera fpsCam;
    public Transform attackPoint;

    // graphics
    public TextMeshProUGUI ammunitionDisplay;   // load ammunition display

    public bool allowInvoke = true;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Shoot()
    {
        readyToShoot = false;
        // determine hit point
        // Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // center of screen
        // RaycastHit hit;
        // // check for collision
        // Vector3 targetPoint;
        // if (Physics.Raycast(ray, out hit))
        // {
        //     targetPoint = hit.point;
        // }
        // else
        // {
        //     targetPoint = ray.GetPoint(75); // a point far away from player
        // }

        // // direction from attackPoint to targetPoint
        // Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        // // calculate spread
        // float x = Random.Range(-spread, spread);
        // float y = Random.Range(-spread, spread);

        // calculate new direction with spread
        //Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        // instantiate bullet
        GameObject bulletPrefab = Instantiate(bullet);

        bulletPrefab.transform.position = attackPoint.position;
        bulletPrefab.transform.forward = attackPoint.forward;
        // rotate bullet to shoot direction
        //bulletPrefab.transform.forward = directionWithSpread.normalized;

        // add forces to bullet
        bulletPrefab.GetComponent<Rigidbody>().AddForce(attackPoint.forward * shootForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        // invoke resetShot() function
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
            //playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }
    }
    private void ResetShot()
    {
        // allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); // invoke ReloadFinished function with your reloadTime as delay
    }

    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void MyInput()
    {
        // check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // reloading 
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        // shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            // set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Update()
    {
        MyInput();
        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
        }
    }
}
