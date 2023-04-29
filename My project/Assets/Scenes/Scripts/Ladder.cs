using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 3f;

    private bool isClimbing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimbing = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isClimbing && collision.CompareTag("Player"))
        {
            float input = Input.GetAxisRaw("Vertical");

            Vector2 velocity = collision.attachedRigidbody.velocity;
            velocity.y = input * climbSpeed;
            collision.attachedRigidbody.velocity = velocity;
        }
    }
}

