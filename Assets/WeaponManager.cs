using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] WeaponData startingWeapon;

    // Fireball fb;

    private void Start()
    {
        AddWeapon(startingWeapon);
    }
    

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);
        
        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);
        Level level = GetComponent<Level>();
        // Debug.Log("xxx ="+weaponData.upgrades);
        if(level != null){
            level.AddUpgradesTheListOfAvailableUpgrades(weaponData.upgrades);
        }
    }

    public Boolean FireBallPPUp = false;
    public void UpgradeWeaponStat(string NameOfSkill){
        Debug.Log(NameOfSkill);
        if (NameOfSkill == "FireBallPowerUp"){
            Debug.Log("POWER UP !!!");
            FireBallPPUp = true;
        }
        else if (NameOfSkill == "FireBallSpeedUp"){
            Debug.Log("SPD UP !!!");
            FireBallPPUp = true;
        }
        
    }
}
