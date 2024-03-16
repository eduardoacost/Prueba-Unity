using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float fireRate;
    public float damage;
    public float range;
    // Otros atributos personalizables de arma
}
