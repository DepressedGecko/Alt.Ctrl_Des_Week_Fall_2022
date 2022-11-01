using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject notePrefab;
    public float ranNumXpos;
    public float ranNumYpos;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void spawnNote()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ranNumXpos = Random.Range(-6.9f, 6.9f);
        ranNumYpos = Random.Range(-3f, 3f);

       // Vector3 
    }
}
