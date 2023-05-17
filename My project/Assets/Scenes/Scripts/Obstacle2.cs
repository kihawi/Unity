using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle2 : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;
            Hero.Instance.GetDamage();
        }
    }

}
