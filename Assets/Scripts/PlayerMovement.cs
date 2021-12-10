using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;

    public Rigidbody2D rb;

    public Rigidbody2D Enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine("DoCheck"); //Added
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Main");
        }
    }

    IEnumerator DoCheck() //Added
    {
        int direction = 1;

        for (int i = 0; i < 10000; i++)
        {
            direction = Random.Range(1, 5);

            if (direction == 1)
            {
                Instantiate(Enemy, new Vector3(8, 0, 0), Quaternion.identity);
            }
            if (direction == 2)
            {
                Instantiate(Enemy, new Vector3(-8, 0, 0), Quaternion.identity);
            }
            if (direction == 3)
            {
                Instantiate(Enemy, new Vector3(0, 4, 0), Quaternion.identity);
            }
            if (direction == 4)
            {
                Instantiate(Enemy, new Vector3(0, -4, 0), Quaternion.identity);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}