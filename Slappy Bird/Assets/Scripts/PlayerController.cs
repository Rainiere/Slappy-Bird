using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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
    }
private void OnTriggerExit2D(Collider2D col){
    if(col.CompareTag("Point")){

    }
}

}
