using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicWeapon : Weapon
{
    public Transform firePoint; // Punto de origen del disparo
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public GameObject projectilePrefab; // Prefab del proyectil

    private bool isParabolicActive = false; // Variable para controlar si el arma parabólica está activa

    public override void Shoot()
    {
        base.Shoot();

        if (isParabolicActive)
            return; // Si el arma parabólica está activa, no disparar proyectil

        // Lógica de disparo con trayectoria parabólica
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calcular la dirección del disparo
            Vector3 shootDirection = firePoint.forward;

            // Aplicar la velocidad al proyectil
            rb.velocity = shootDirection * projectileSpeed;

            // Desactivar el proyectil después de un tiempo
            Destroy(projectile, 3f); // Cambia el 3f al tiempo que desees
        }
        else
        {
            Debug.LogWarning("El proyectil no tiene un componente Rigidbody.");
        }
    }

    public void SetParabolicActive(bool isActive)
    {
        isParabolicActive = isActive; // Método para activar o desactivar el arma parabólica
    }
}
