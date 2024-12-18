using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float center;
    void Start()
    {
        center = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate (){
        Vector2 pos = transform.position;

        float sin = Mathf.Sin (pos.x);
        pos.y=center + sin;



        transform.position = pos;
    }
}
