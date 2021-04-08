
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class santa_santa_granada : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private float desaparece;
    public AudioSource bomba;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        desaparece = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == 0)
        {
            rb2D.velocity = new Vector3(-speed, rb2D.velocity.y, 0.0f);
        }
        else
        {
            rb2D.velocity = new Vector3(speed, rb2D.velocity.y, 0.0f);
        }
        desaparece = desaparece + Time.deltaTime;
        if (desaparece > 4)
        {
            Destroy(this.gameObject);
            desaparece = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("N1"))
        {
            bomba.Play();

            collision.gameObject.GetComponent<N1>().daño(100);
            Destroy(this.gameObject);

        }
        if (collision.gameObject.CompareTag("N2"))
        {
            bomba.Play();

            collision.gameObject.GetComponent<N2>().daño(100);
            Destroy(this.gameObject);


        }
        if (collision.gameObject.CompareTag("boss"))
        {
            bomba.Play();
            this.GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<boss>().daño(100);
            Invoke("die", 1.4f);

        }
    }
    public void die()
    {
        Destroy(this.gameObject);

    }
}

