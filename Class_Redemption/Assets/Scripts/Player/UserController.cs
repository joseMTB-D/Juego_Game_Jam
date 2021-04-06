using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UserController : MonoBehaviour
{
    //player
    private Rigidbody2D rb2D;
    private Animator yubes;
    public float vida;
    public float speed;
    public bool morite;
    public float caida;
    private bool suelo;
    //armas
    public GameObject santisima;
    public GameObject supersantisima;
    //mecanicas
    //contador de bombas santas:
    public int bbsanta;
    //HUB
    public Text Bombas;
    //public Text tiempo;



    // Start is called before the first frame update
    void Start()
    {
        suelo = false;
        caida = 0.0f;
        morite = false;
        vida = 100.0f;
        rb2D = GetComponent<Rigidbody2D>();
        yubes = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(suelo);
        if (morite == true)
        {

        }else if (morite == false)
        {
            //movimiento player
            float moveHorizontal = Input.GetAxis("Horizontal");
            if (suelo ==true)
            {

                if (moveHorizontal > 0)
                {
                    yubes.SetInteger("idle", 1);

                    transform.eulerAngles = new Vector3(0, 180, 0);
                    rb2D.velocity = new Vector3(speed, 0.0f, 0.0f);

                }
                else if (moveHorizontal < 0)
                {

                    yubes.SetInteger("idle", 1);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    rb2D.velocity = new Vector3(-speed, 0.0f, 0.0f);


                }
                else if (moveHorizontal == 0)
                {
                    yubes.SetInteger("idle", 0);

                }
                if (Input.GetKeyDown(KeyCode.E))
                {


                    if (transform.rotation.y == 0)
                    {
                        Instantiate(santisima, transform.position - new Vector3(0.80f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 180f, 0.0f));

                    }
                    else
                    {
                        Instantiate(santisima, transform.position + new Vector3(0.80f, 0.0f, 0.0f), transform.rotation);
                    }

                }
                if ((caida > 1)&&(caida<4))
                {
                    int dañoc = (int)caida * 25;
                    Debug.Log(caida);

                    caida = 0;
                    Daño_Player(dañoc);
                }
                else if(caida>4)
                {
                    vida = 0;
                }
                
            }
            else
            {
                caida = caida + Time.deltaTime;
                
            }

        }
          
        }
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Moneda"))
        {
            Destroy(other.gameObject);
            bbsanta = bbsanta + 1;
            Bombas.text = "Monedas: " + bbsanta.ToString();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("suelo"))
        {
            suelo = true;
        }
        /*if (collision.collider.CompareTag("Seta"))

        {
            Destroy(collision.gameObject);
            state = 1;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        if (collision.collider.CompareTag("Star"))

        {
            last = state;
            Destroy(collision.gameObject);
            star = true;
            
           
        }
       
        if (collision.collider.CompareTag("flo"))

            {
                Destroy(collision.gameObject);
                state = 2;
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
            }

            if (collision.collider.CompareTag("win"))
            {
                Invoke("win", 4);
            
        }

            if (collision.collider.CompareTag("Muerte"))
            {
            if (star)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                if (state == 2)
                {
                    state = 1;
                }
                if (state == 1)
                {
                    state = 0;
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }
                if (state == 0)
                {

                    Debug.Log(vidas);
                    EPMario.SetBool("morite", true);
                    morite = false;
                    Invoke("die", 4);

                }

            }

            }*/


        }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("suelo"))
        {
            suelo = false;
        }
    }
        public void Daño_Player(int a)
        {
         vida = vida - a;
        }
    
        
        private void die()
        {
            SceneManager.LoadScene("GameOver");
        }
        private void win()
        {
            SceneManager.LoadScene("GameOver");
        }

    }

