using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject EpicMario;


    private  float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.z - EpicMario.transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (EpicMario.transform.position.x > transform.position.x) { 
            //   transform.position = player.transform.position + offset;
            transform.position = new Vector3(EpicMario.transform.position.x, transform.position.y, offset);
    }
    }
}
