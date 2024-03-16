using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;

    public virtual void Shoot()
    {
        // Lógica de disparo común para todas las armas
        Debug.Log("Disparando " + weaponData.weaponName);
    }
}
