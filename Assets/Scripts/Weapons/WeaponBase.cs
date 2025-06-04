using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "FPS/Weapon")]
public class WeaponBase : ScriptableObject
{
    [Header("Launcher Only")]
    
    public GameObject weaponPrefab;
    public string weaponName;
    public Sprite weaponIcon;
    public int maxAmmo;
    public float damage;
    public float range;
    public float reloadTime;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    public bool isSniper;
    public bool isPenetrate;
    public bool isLauncher;    
    public float explosionRadius = 3f;
}

