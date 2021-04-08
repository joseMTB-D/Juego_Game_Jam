using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N1 : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator yubes;
    public int vida;
    public float speed;
    public float andares;
    public float ataque;
    public float post_ataque;
    public string preataque;
    public string dire;
    public AudioSource N;

    // Start is called before the first frame update
    void Start()
    {
        preataque = "";
        dire = "izquierda";
        post_ataque = 0.0f;
        ataque = 0.0f;
        andares = 0;
        rb2D = GetComponent<Rigidbody2D>();
        yubes = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (vida > 0)
        {
            ataque = ataque + Time.deltaTime;
            if (dire.Equals("izquierda"))
            {
                andares = andares + Time.deltaTime;

                if (andares < 2)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    rb2D.velocity = new Vector3(-speed, rb2D.velocity.y, 0.0f);
                    yubes.SetInteger("N1", 0);

                }
                else
                {
                    dire = "derecha";
                    andares = 0.0f;
                }
            }
            if (dire.Equals("derecha"))
            {
                andares = andares + Time.deltaTime;

                if (andares < 2)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);

                    rb2D.velocity = new Vector3(speed, rb2D.velocity.y, 0.0f);
                    yubes.SetInteger("N1", 0);
                }
                else
                {
                    dire = "izquierda";
                    andares = 0.0f;

                }
            }


            if (ataque > 4)
            {
                ataque = 0.0f;
                preataque = dire;
                dire = "ataque";
                this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                N.Play();

}

            if (dire.Equals("ataque"))
            {
                post_ataque = post_ataque + Time.deltaTime;
                yubes.SetInteger("N1", 1);

                if (post_ataque>0.98f)
                {
                    this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    post_ataque = 0.0f;

                    if (preataque.Equals("izquierda"))
                    {
                        dire = "derecha";
                    }
                    if (preataque.Equals("derecha"))
                    {
                        dire = "izquierda";
                    }
                }
               
            }


        }
        else
        {
            yubes.SetInteger("N1", 4);
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
    

    public void daño (int a)
    {
        vida = vida - a;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<UserController>().Daño_Player(20);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("medio");
            collision.gameObject.GetComponent<UserController>().Daño_Player(2);
        }
    }
    }
