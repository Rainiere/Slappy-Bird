using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Manager _Manager;
    private Rigidbody2D PlayerRigidbody;                        //Rigidbody2D Component van de Player
    [SerializeField] private Vector2 Jump = new Vector2();      //Jump om de player omhoog te bewegen

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();          //Toewijzing van het Rigidbody2D component zodat we die kunnen gebruiken
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){                    //Jump functie
            PlayerRigidbody.velocity = Jump;
        }

        ScoreTMP.text = "Score: " + Score;
    }

    private int Score;
    [SerializeField] private TMP_Text ScoreTMP; 
private void OnTriggerExit2D(Collider2D col){
    if(col.CompareTag("Point")){
        Score++;

    }
    if (col.CompareTag("Wall")){
        Time.timeScale = 0;
        _Manager.Highscore(Score);
    }
    return;
}

}
