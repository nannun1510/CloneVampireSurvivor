using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : WeaponBase
{

    Playermove playerMove;
    LetFireballProjectile letFireballProjectile;

    [SerializeField] GameObject fireballPrefab;

    private void Awake()
    {
        playerMove = GetComponentInParent<Playermove>();
    }

    public override void Attack()
    {
        //Debug.Log(weaponStats.damage);
        GameObject letFireball = Instantiate(fireballPrefab);
        letFireball.transform.position = transform.position;
        letFireball.GetComponent<LetFireballProjectile>().SetStat(weaponStats.damage,10f);
        letFireball.GetComponent<LetFireballProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
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
