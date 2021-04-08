using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale; 
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = (UserController.vida/94);

        transform.localScale = localScale;
    }
}
