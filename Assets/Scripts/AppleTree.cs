using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;

    public GameObject branchPrefab;
    public float branchChance = 0.1f; // 10% chance

    public float speed = 1f;

    public float edgeDist = 10f;

    public float flipChance = 0.1f;

    public float appleDropDelay = 1f;

    public bool gameOver = false;
    
    // Start is called before the first frame update
    void Start(){
        Invoke("DropApple", 2f);
    }

    void DropApple() {
        if (gameOver) return; 
        
        GameObject prefabToSpawn;

        float chance = Random.value; // 0.0 to 1.0

        if (chance < branchChance)
        {
            prefabToSpawn = branchPrefab;  // spawn branch (bad object)
        }
        else
        {
            prefabToSpawn = applePrefab;   // spawn normal apple
        }

       if (prefabToSpawn != null)
        {
            GameObject obj = Instantiate(prefabToSpawn);
            obj.transform.position = transform.position;
        }

        // schedule next drop
        Invoke("DropApple", appleDropDelay);
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
