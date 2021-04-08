
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        Invoke("re", 0);
    }
    public void re()
    {
        SceneManager.LoadScene("Juego");
    }
}
