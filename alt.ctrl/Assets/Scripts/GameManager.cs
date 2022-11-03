using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public int score;
    public Text scoreText;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Invoke("spawnNote", 3f);
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

        //instantiate invis fail collider use note.transform.position and note.transform.rotation for the notes current location

        Invoke("despawnNote", 3f);
    }

    private void despawnNote() 
    {
        Destroy(note);
        CancelInvoke("despawnNote");
        Invoke("spawnNote", 3f);
    }

    private void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Collider2D hit = Physics2D.OverlapCircle(player.transform.position, 0.12f, LayerMask.GetMask("Note ;)"));
            if (hit != null)
            {

                Instantiate(deathNotePrefab, note.transform.position, note.transform.rotation);
                addScore();
                despawnNote();

            }

        }

    }   

}
