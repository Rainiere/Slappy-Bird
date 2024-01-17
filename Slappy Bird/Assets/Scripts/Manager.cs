using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
 using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    [SerializeField] private Obstacles Obstacle;
    [SerializeField] private float Timer;       //Adjustable timer between Obstacle spawns
                     private float TimerToUse = 0.5f;  //Timer variable to use in the code to spawn obstacles and assign back to the Timer value when < 

    [SerializeField] private int MaxObstacles;

    private int Counter;

    private void Init(){
        if(Counter == MaxObstacles){
            return;
        }
        Instantiate(Obstacle, new Vector2(10, Random.Range( -3,  4)), Quaternion.identity);
        Counter++;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerToUse -= Time.deltaTime;
        if(TimerToUse <= 0){
            Init();
            TimerToUse = Obstacle.ResetSpeed / MaxObstacles;
        }
    }
}
