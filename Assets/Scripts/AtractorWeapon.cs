using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractorWeapon : Weapon
{
    public GameObject attractionProjectilePrefab; // Prefab del proyectil de atracción
    public Transform firePoint; // Punto de origen del disparo

    public override void Shoot()
    {
        base.Shoot();

        // Instanciar el proyectil de atracción en el punto de origen del disparo
        Instantiate(attractionProjectilePrefab, firePoint.position, firePoint.rotation);
    }
}

