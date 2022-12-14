using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject notePrefab;
    private GameObject note;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject deathNotePrefab;
    [SerializeField]
    private GameObject invisNoteFailState;
    private GameObject invsNote;

    public float ranNumXpos;
    public float ranNumYpos;

    public int score;
    public Text scoreText;

    public float spawnBuffer = 1.66f;
    public float difficultyChanger = 5f;

    public float noteSpawnTimer = 2.6f;

    public AudioSource source;
    public AudioClip trumpetFail;
    public AudioClip hitSound;

    private Rigidbody2D rb;

    public int maxHealth = 100;
    int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        InvokeRepeating("spawnNote", spawnBuffer, spawnBuffer);


        currentHealth = maxHealth;
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
        invsNote = Instantiate(invisNoteFailState, note.transform.position, note.transform.rotation);
        

        //instantiate invis fail collider use note.transform.position and note.transform.rotation for the notes current location

       // Invoke("despawnNote", 3f);
    }

    private void despawnNote() 
    {
        Destroy(note);
        Destroy(invsNote);

        //CancelInvoke("despawnNote");
        //Invoke("spawnNote", spawnBuffer);
    }

    private void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void timer()
    {
        print("time");
        if (noteSpawnTimer >= 2.6f)
        {
            print("timer started");
        }

        if (noteSpawnTimer > 0)
        {
            noteSpawnTimer -= Time.deltaTime;
        }

        if (noteSpawnTimer <= 0)
        {
            spawnNote();
            noteSpawnTimer = 2.6f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //timer();

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Collider2D hit = Physics2D.OverlapCircle(player.transform.position, 0.12f, LayerMask.GetMask("Note ;)"));
            if (hit != null)
            {

                source.PlayOneShot(hitSound);
                Instantiate(deathNotePrefab, note.transform.position, note.transform.rotation);
                addScore();
                despawnNote();

                /*
                // make the notes spawn half a second faster every 5 points the player collects, this time stops decreasing at 0.5 seconds
                if (score >= difficultyChanger)
                {
                    spawnBuffer = (spawnBuffer - 0.5f);
                    difficultyChanger = (difficultyChanger + 5f);
                }

                if (spawnBuffer <= 0.5f)
                {
                    spawnBuffer = 0.5f;
                }
                */
            }

            //fail note peram
            Collider2D hit2 = Physics2D.OverlapCircle(player.transform.position, 0.12f, LayerMask.GetMask("FailNote"));
            if (hit2 != null)
            {
                source.PlayOneShot(trumpetFail);
                despawnNote();
            }

        }
    }

    //public void TakeDamage(int damage)
   // {
    //    currentHealth -= damage;

        //Play hurt animation
        //animator.SetTrigger("Hurt");

    //    if (currentHealth <= 0)
    //    {
    //        Die();
    //    }
   // }

   // void Die()
   // {
   //     Debug.Log("Enemy Died!");

        // Die animation
        // animator.SetBool("IsDead", true);

        //Disable enemy
       // GetComponent<Collider2D>().enabled = false;
       // this.enabled = false;
  //  }

}
