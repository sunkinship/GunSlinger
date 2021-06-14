using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float scalar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Time.deltaTime * scalar * Input.GetAxis("Horizontal");
        float posY = Time.deltaTime * scalar * Input.GetAxis("Vertical");
        transform.position += new Vector3(posX, posY, transform.position.z);
    }
}
