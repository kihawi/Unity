using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;


            // ѕровер€ем, €вл€етс€ ли столкновение с верхней стороны
            if (Vector2.Dot(normal, Vector2.down) > 0.7f)
            {
                Hero.Instance.GetDamage();
            }
        }
    }

}
