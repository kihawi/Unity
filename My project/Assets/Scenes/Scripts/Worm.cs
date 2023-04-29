using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Worm : Entity
{
    [SerializeField] private int lives;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            // Проверяем, является ли столкновение с боковой стороны
            if (Mathf.Abs(normal.x) > 0.7f && Mathf.Abs(normal.y) < 0.2f)
            {
                Hero.Instance.GetDamage();


            }

            else
            {
                lives--;
                Debug.Log("у червяка" + lives);
            }
        }



        if (lives < 1)

            Die();
            
    }

    
}
    
