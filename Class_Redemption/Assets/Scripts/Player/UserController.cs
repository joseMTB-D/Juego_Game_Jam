using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UserController : MonoBehaviour
{
    //player
    private Rigidbody2D rb2D;
    private Animator yubes;
    public static float vida;
    public float speed;
    public bool morite;
    public float caida;
    private bool suelo;
    //armas
    public GameObject santisima;
    public GameObject supersantisima;
    //contador de santas
    public int santas;
    //contador de bombas santas:
    public int bbsanta;
 
    //HUB
    public Text Bombas;
    //public Text tiempo;







    // Start is called before the first frame update
    void Start()
    {
        santas = 0;
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

        if (morite == true)
        {
            Invoke("die", 2);
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
                    if (bbsanta > 0)
                    {
                        if (bbsanta >= 10)
                        {
                            if (transform.rotation.y == 0)
                            {

                                Instantiate(supersantisima, transform.position + new Vector3(-1.20f, 0.0f, 0.0f), transform.rotation);
                                bbsanta = bbsanta - 10;
                                Bombas.text = "Bombas Santas: " + bbsanta.ToString();
                            }
                            else
                            {
                                Instantiate(supersantisima, transform.position - new Vector3(-1.20f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 180f, 0.0f));
                               bbsanta = bbsanta - 10;
                                Bombas.text = "Bombas Santas: " + bbsanta.ToString();
                            }
                        }
                        else
                        {
                            if (transform.rotation.y == 0)
                            {
                                Instantiate(santisima, transform.position + new Vector3(-1.10f, 0.0f, 0.0f), transform.rotation);
                                bbsanta = bbsanta - 1;
                                Bombas.text = "Bombas Santas: " + bbsanta.ToString();
                            }
                            else
                            {
                                Instantiate(santisima, transform.position - new Vector3(-1.20f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 180f, 0.0f));
                                bbsanta = bbsanta-1;
                                Bombas.text = "Bombas Santas: " + bbsanta.ToString();
                            }
                        }
                    }
                   
                   

                }
                if ((caida > 1)&&(caida<4))
                {
                    int dañoc = (int)caida * 25;

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

        if (other.gameObject.CompareTag("santa_pickup"))
        {
            Destroy(other.gameObject);
            bbsanta = bbsanta + 1;
            Bombas.text = "Bombas Santas: " + bbsanta.ToString();

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("suelo"))
        {
            suelo = true;
        }
       


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
        public void prefinal()
        {
        Invoke("win", 6);
        }
        
        private void die()
        {
            SceneManager.LoadScene("final");
        }

        private void win()
        {
            SceneManager.LoadScene("final");
        }

    }

