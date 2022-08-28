using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    Playermove playerMove;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMove = GetComponentInParent<Playermove>();
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        //Debug.Log(colliders.Length);
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            //Debug.Log(colliders[i]);
            if(e != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public override void CheckUpdateSkill(){
        
    }

    public override void Attack()
    {
        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
    }
}

//public class WhipWeapon : MonoBehaviour
//{
//    [SerializeField] float timeToAttack = 4f;
//    float timer;

//    [SerializeField] GameObject leftWhipObject;
//    [SerializeField] GameObject rightWhipObject;


//    Playermove playerMove;
//    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
//    [SerializeField] int whipDamage = 1;


//    private void Awake()
//    {
//        playerMove = GetComponentInParent<Playermove>();
//    }

//    private void Update()
//    {
//        timer -= Time.deltaTime;
//        if (timer < 0f)
//        {
//            Attack();
//        }
//    }

//    private void Attack()
//    {
//        timer = timeToAttack;

//        if (playerMove.lastHorizontalVector > 0)
//        {
//            rightWhipObject.SetActive(true);
//            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
//            ApplyDamage(colliders);
//        }
//        else
//        {
//            leftWhipObject.SetActive(true);
//            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
//            ApplyDamage(colliders);
//        }
//    }

//    private void ApplyDamage(Collider2D[] colliders)
//    {
//        //Debug.Log(colliders.Length);
//        for (int i = 0; i < colliders.Length; i++)
//        {
//            IDamageable e = colliders[i].GetComponent<IDamageable>();
//            //Debug.Log(colliders[i]);
//            if (e != null)
//            {
//                e.TakeDamage(whipDamage);
//            }
//        }
//    }
//}
