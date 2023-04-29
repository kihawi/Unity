using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingFace : Entity
{
    private SpriteRenderer sprite;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private int lives;

    private void Awake()
    {
        sprite= GetComponentInChildren<SpriteRenderer>();
        lives = 3;
    }

    private void Update()
    {
        sprite.flipX = aiPath.desiredVelocity.x <= 0.01f;
    }

    private void OnCollisionStay2D(Collision2D collision)
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


        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            // Проверяем, является ли столкновение с низом коллайдера игрока
            if (normal.y < 0.7f)
            {
                lives--;
            }

            if (lives < 0)
                Die();
        }
    }
}
