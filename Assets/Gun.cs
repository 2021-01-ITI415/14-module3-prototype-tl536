using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float timeBetweenShooting, spread, reloadtime, timeBetweenShots;
    public int megazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading;
    
    public Camera fpsCam;
    public Transform attakcPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public GameObject muzzleFlash, bulletHoleGraphic;
    public AudioSource ShootingSound;
    public AudioClip audioshoot;
    public AudioClip audioreload;
    public AudioClip outofammo;



    public CameraShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    public int wholesize;
    private int bulletsused = 0;

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);


        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < megazineSize && !reloading) Reload();





        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }


    }

    private void Awake()
    {
        ShootingSound = GetComponent<AudioSource>();
        bulletsLeft = megazineSize;
        readyToShoot = true;
    }


    private void Update()
    {
        MyInput();
        text.SetText(bulletsLeft + " / " + wholesize);

        if (Input.GetButtonDown("Fire1"))
        {

            if (bulletsLeft == 0)
            {

                ShootingSound.PlayOneShot(outofammo);
            }


        }
        if (Input.GetButtonUp("Fire1"))
        {
            
        }
    }


    private void Shoot()
    {
        if (bulletsLeft != 0)
        {

            ShootingSound.PlayOneShot(audioshoot);
        }
        //spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0); 

        readyToShoot = false;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);
            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<Enemy>().TakeDamage(damage);
        }

        StartCoroutine(camShake.Shake(camShakeDuration, camShakeMagnitude));

        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attakcPoint.position, Quaternion.identity);


        bulletsLeft--;
        bulletsShot--;
        bulletsused++;
        
        Invoke("ResetShot", timeBetweenShooting);
        if(bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);

    }

    private void ResetShot()
    {
        readyToShoot = true;


    }


    private void Reload()
    {
        if (wholesize != 0)
        {
            ShootingSound.PlayOneShot(audioreload);
            reloading = true;
            Invoke("ReloadFinished", reloadtime);
        }
        else
        {
            ShootingSound.PlayOneShot(outofammo);
        }
        


    }


    private void ReloadFinished()
    {
        if (wholesize < megazineSize)
        {
            if (wholesize < megazineSize- bulletsLeft)
            {
                bulletsLeft = bulletsLeft + wholesize;
                wholesize = 0;
                bulletsused = 0;
            }

            else
            {
                bulletsLeft = bulletsLeft + bulletsused;
                wholesize = wholesize - bulletsused;
                bulletsused = 0;
            }
           
        }
        else
        {
            bulletsLeft = megazineSize;
            wholesize = wholesize - bulletsused;
            bulletsused = 0;
        }
        reloading = false;

    }


}
