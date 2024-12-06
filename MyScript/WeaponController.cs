using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WEって何？何をするクラスなの？
/// </summary>
public class WeaponController : MonoBehaviour
{
    //publicの部分をすべてSerializeFieldに変更した。クラスの外からアクセスが必要な場合はプロパティを用意してください。
    [SerializeField] int magazineCapacity = 10; 
    [SerializeField] int currentAmmoInMagazine;
    [SerializeField] int totalAmmo;
    [SerializeField] float reloadTime = 2f;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] AudioSource reloadSound;
    [SerializeField] AudioSource fireSound;
    [SerializeField] Text ammoText;
    [SerializeField] int bulletsPerReload = 1;

    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    private void Start()
    {
        currentAmmoInMagazine = magazineCapacity;
    }

    private void Update()
    {
        ammoText.text = $"{currentAmmoInMagazine} / {totalAmmo}";

        if (Input.GetKeyDown(KeyCode.R) && !isReloading) //NewInputSystemに変更するように
        {
            StartCoroutine(Reload());
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && !isReloading && currentAmmoInMagazine > 0) //NewInputSystemに変更するように
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

/// <summary>
/// 弾を撃つ
/// </summary>
    private void Shoot()
    {
        currentAmmoInMagazine--;

        // 弾のインスタンスを作成
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 射撃音を再生
        fireSound.Play();
    }

/// <summary>
/// 弾をリロードする
/// </summary>
/// <returns></returns>
    private IEnumerator Reload()
    {
        isReloading = true;

        int ammoNeeded = magazineCapacity - currentAmmoInMagazine;
        int ammoToReload = Mathf.Min(ammoNeeded, totalAmmo, bulletsPerReload);

        while (ammoToReload > 0 && totalAmmo > 0)
        {
            reloadSound.Play();
            yield return new WaitForSeconds(reloadTime);

            currentAmmoInMagazine += ammoToReload;
            totalAmmo -= ammoToReload;

            ammoNeeded = magazineCapacity - currentAmmoInMagazine;
            ammoToReload = Mathf.Min(ammoNeeded, totalAmmo, bulletsPerReload);
        }

        isReloading = false;
    }
}
