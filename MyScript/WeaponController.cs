using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;

/// <summary>
/// ����̃R���g���[���[�N���X
/// ���̃N���X�́A����̒e��Ǘ��A�ˌ��A�����[�h�Ȃǂ̋@�\���Ǘ�
/// </summary>
public class WeaponController : MonoBehaviour
{
    public int magazineCapacity = 10;
    public int currentAmmoInMagazine;
    public int totalAmmo;
    public float reloadTime = 2f;
    public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioSource reloadSound;
    public AudioSource fireSound;
    public Text ammoText;
    public int bulletsPerReload = 1;

    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    private void Start()
    {
        currentAmmoInMagazine = magazineCapacity;
    }

    private void Update()
    {
        ammoText.text = $"{currentAmmoInMagazine} / {totalAmmo}";

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && !isReloading && currentAmmoInMagazine > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    /// <summary>
    /// �e�𔭎˂��郁�\�b�h
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
    /// �����[�h�������s���R���[�`��
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
