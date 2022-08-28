using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : WeaponBase
{

    Playermove playerMove;
    WeaponManager weaponManager;
    LetFireballProjectile letFireballProjectile;
    [SerializeField] GameObject fireballPrefab;
    int DMG = 0;
    float SPD = 10f;
    int PowerUpDMG = 0;
    float PercentageDMG = 1f;

    private void Awake()
    {
        playerMove = GetComponentInParent<Playermove>();
        weaponManager = GetComponentInParent<WeaponManager>();
    }

    private void Start() {
        DPSCalculate(weaponStats.damage, weaponStats.timeToAttack);
    }

    public override void CheckUpdateSkill(){
        FireBallPowerUp();
    }

    public override void Attack()
    {
        GameObject letFireball = Instantiate(fireballPrefab);
        letFireball.transform.position = transform.position;
        letFireball.GetComponent<LetFireballProjectile>().SetStat(DMG,SPD);
        letFireball.GetComponent<LetFireballProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
    }

    public void FireBallPowerUp(){
        if(weaponManager.FireBallPPUp){
            PowerUpDMG += 10;
            weaponManager.FireBallPPUp = false;
            DPSCalculate(DMG, weaponStats.timeToAttack);
            PowerUpDMG = 0;
            Debug.Log("cal");
        }
    }

    
    public void DPSCalculate(int BaseDPS,float BaseSPD){
        DMG = (int)((BaseDPS + PowerUpDMG)*PercentageDMG);
    }
}

//public class Fireball : MonoBehaviour
//{
//    [SerializeField] float timeToAttack;
//    float timer;

//    Playermove playerMove;

//    [SerializeField] GameObject fireballPrefab;

//    private void Awake()
//    {
//        playerMove = GetComponentInParent<Playermove>();
//    }

//    private void Update()
//    {
//        if (timer < timeToAttack)
//        {
//            timer += Time.deltaTime;
//            return;
//        }

//        timer = 0;
//        SpawnFireball();
//    }

//    private void SpawnFireball()
//    {
//        GameObject letFireball = Instantiate(fireballPrefab);
//        letFireball.transform.position = transform.position;
//        letFireball.GetComponent<LetFireballProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
//    }
//}
