using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject notePrefab;
    [SerializeField]
    private GameObject note;

    public float ranNumXpos;
    public float ranNumYpos;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();


    }

    Vector2 RanNum()
    {
        ranNumXpos = Random.Range(-6.9f, 6.9f);
        ranNumYpos = Random.Range(-3f, 3f);
        return new Vector2(ranNumXpos,ranNumYpos);
    }

    private void spawnNote()
    {
        note = Instantiate(notePrefab, RanNum(), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            print("gay");
            spawnNote();
        }
       
    }
}
