using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private Rigidbody2D ObstaclesRigidbody;

    [SerializeField] private int ObstacleSpeed;

    public float ResetSpeed = 5;
    private float AliveTimer;

    // Start is called before the first frame update
    void Start()
    {
        ObstaclesRigidbody = GetComponent<Rigidbody2D>();
        AliveTimer = ResetSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ObstaclesRigidbody.velocity = new Vector2(-ObstacleSpeed, 0);
        if(AliveTimer > 0){
            AliveTimer -= Time.deltaTime;
        }
        if(AliveTimer <= 0){
            this.transform.position = new Vector2(10, Random.Range( -3,  4));
            AliveTimer = ResetSpeed;
        }
    }
}
