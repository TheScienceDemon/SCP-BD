using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waffe : MonoBehaviour
{
    //private bool isAiming;
    private bool isReloading;

    public float damage;
    public float fireRate;
    public float reloadTime;
    //public float sniperScopeFOV;
    private float nextTimeToFire = 0f;
    //private float normalCamFOV;

    public int maxAmmo;
    public int currentAmmo;

    public Camera fpsCam;
    public Animator anim;
    //public ParticleSystem muzzleFlash;
    //public GameObject weaponCam;
    //public GameObject impactEffect;
    //public GameObject impactSound;
    //public GameObject WeaponShotSound;
    //public GameObject EmptyMagazineShotSound;
    //public GameObject WeaponShotSoundLocation;
    //public GameObject Crosshair;
    //public GameObject ScopeOverlay;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (currentAmmo <= 0)
        {
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        anim.Play("KubussReloduss");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        //muzzleFlash.Play();
        currentAmmo--;
        anim.Play("KubussSchuss");

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            PlayerHealth target = hit.transform.GetComponentInParent<PlayerHealth>();
            if (target != null)
            {
                target.TakingDamage(damage);
            }
        }
    }
}
