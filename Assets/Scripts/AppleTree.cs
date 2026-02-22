using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;

    public float speed = 1f;

    public float edgeDist = 10f;

    public float flipChance = 0.1f;

    public float appleDropDelay = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        






    }

    // Update is called once per frame
    void Update()
    {
        // make tree move
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        

        // possibly flip direction
        if (pos.x < - edgeDist){
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > edgeDist){
            speed = - Mathf.Abs(speed);
        }
        else if ( Random.value < flipChance){
            speed *= - 1;
        }
    }
    void FixedUpdate()
    {
        if (Random.value < flipChance){
            speed *= - 1;
        }
    }
}
