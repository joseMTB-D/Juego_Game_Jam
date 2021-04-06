using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class santa_bomba : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public float speed;
    private float desaparece;
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
            rb2D.velocity = new Vector3(speed, rb2D.velocity.y, 0.0f);
            Debug.Log(transform.rotation.y);
        }
        else
        {
            rb2D.velocity = new Vector3(-speed, rb2D.velocity.y, 0.0f);
            Debug.Log(transform.rotation.y);
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
        /*
        if (collision.gameObject.CompareTag("Muerte"))
        {
            Debug.Log("Morite");
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
       else if(!collision.gameObject.CompareTag("Suelo"))
        {
            Debug.Log("OH NO");
            Destroy(gameObject);
        }*/
    }
}
