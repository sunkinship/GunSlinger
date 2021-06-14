using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    
    public float scalar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Time.deltaTime * scalar * Input.GetAxis("Horizontal2");
        float posY = Time.deltaTime * scalar * Input.GetAxis("Vertical2");
        transform.position += new Vector3(posX, posY, transform.position.z);
    }
}
