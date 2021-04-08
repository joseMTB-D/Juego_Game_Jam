using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    public void quit()
    {
        Invoke("s", 0);
    }
    public void s()
    {
        Application.Quit();
        Debug.Log("Sortint");
    }
}
