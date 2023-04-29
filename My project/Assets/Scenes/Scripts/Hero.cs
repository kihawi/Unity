using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpforce = 15f;
    [SerializeField] private int lives;
    [SerializeField] private float startingHealth;
    [SerializeField] private float deathHeight = -5f;
    private Vector2 startPosition;
    private float lastDamageTime;
    public float restartDelay = 5f; // врем€ задержки перед перезапуском сцены
    

    private bool isGrounded = false;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public Image Bar;

    public virtual void Die()
    {

        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public float currentHealth { get; private set; }
    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            Bar.fillAmount = (float)lives / startingHealth;
        }
    }

    public static Hero Instance { get; set; }


    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }


    private void Awake()
    {
        startPosition = transform.position;
        currentHealth = startingHealth;
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
        if (transform.position.y < deathHeight)
        {
            Die();
        }
    }
    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.jump;
    }

    public void GetDamage()
    {
        if (Time.time - lastDamageTime > 0.1f) // ѕровер€ем, прошло ли 0.5 секунд с момента последнего урона
        {
            lives -= 1;
            
            lastDamageTime = Time.time; // «аписываем текущее врем€ в переменную последнего урона
            currentHealth -= 1;
            Bar.fillAmount = currentHealth / 5;
           
        }
      


        if (lives < 1)
            Die();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            startPosition = transform.position; // обновл€ем позицию начала падени€
        }
    }





}

public enum States
{
    idle,
    run,
    jump

}

