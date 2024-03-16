using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveWeapon : Weapon
{
    public GameObject explosiveProjectilePrefab; // Prefab del proyectil explosivo
    public Transform firePoint; // Punto de origen del disparo

    public override void Shoot()
    {
        base.Shoot();

        // Instanciar el proyectil explosivo en el punto de origen del disparo
        Instantiate(explosiveProjectilePrefab, firePoint.position, firePoint.rotation);
    }
}
