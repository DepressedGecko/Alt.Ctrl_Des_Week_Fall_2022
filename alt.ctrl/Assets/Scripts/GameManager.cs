using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject notePrefab;
    [SerializeField]
    private GameObject note;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject deathNotePrefab;
    [SerializeField]
    private GameObject invisNoteFailState;

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

    private void despawnNote() 
    { 
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Jump"))
        {
            spawnNote();
        }

        Collider2D hit = Physics2D.OverlapCircle(player.transform.position, 0.12f, LayerMask.GetMask("Note ;)"));

        if (Input.GetKeyDown("h")) 
        {                      

            if (hit != null)
            {
                Instantiate(deathNotePrefab, note.transform.position, note.transform.rotation);
                Destroy(note);
                //increase score
                spawnNote();

            }

        }
        else if (hit == null)
        {
            Destroy(note, 3f);
        }

    }   

}
