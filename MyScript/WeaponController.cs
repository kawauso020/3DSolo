using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WE���ĉ��H��������N���X�Ȃ́H
/// </summary>
public class WeaponController : MonoBehaviour
{
    //public�̕��������ׂ�SerializeField�ɕύX�����B�N���X�̊O����A�N�Z�X���K�v�ȏꍇ�̓v���p�e�B��p�ӂ��Ă��������B
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

        if (Input.GetKeyDown(KeyCode.R) && !isReloading) //NewInputSystem�ɕύX����悤��
        {
            StartCoroutine(Reload());
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && !isReloading && currentAmmoInMagazine > 0) //NewInputSystem�ɕύX����悤��
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

/// <summary>
/// �e������
/// </summary>
    private void Shoot()
    {
        currentAmmoInMagazine--;

        // �e�̃C���X�^���X���쐬
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // �ˌ������Đ�
        fireSound.Play();
    }

/// <summary>
/// �e�������[�h����
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
