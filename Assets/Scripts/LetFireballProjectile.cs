using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetFireballProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 5;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3 (dir_x, dir_y);

        if(dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    public void SetStat(int dmg, float spd)
    {
        damage = dmg;
        speed = spd;
    }

    bool hitDetected = false;
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if(Time.frameCount % 6 == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);
            foreach (Collider2D c in hit)
            {
                Enemy enemy = c.GetComponent<Enemy>();
                if (enemy != null)
                {
                    MessageSystem.instance.PostMessage(damage.ToString(), transform.position);
                    enemy.TakeDamage(damage);
                    break;
                }
            }
            if (hitDetected == true)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
