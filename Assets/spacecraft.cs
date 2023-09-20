using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spacecraft : MonoBehaviour
{
    public Transform[] Targets; 
    private Transform currentTarget;
    private bool isMovingStraight = false; 
    private int count = 0;
    void Start()
    {
        currentTarget = Targets[0]; 
    }

    void Update()
    {
        
        CheckPlanetProximity();

        if (isMovingStraight)
        {
           
            transform.Translate(Vector3.left * Time.deltaTime * 80f);
        }
        else
        {
          
            transform.RotateAround(currentTarget.position, Vector3.forward, 150 * Time.deltaTime);
        }

     
        if (count>3){
            SceneManager.LoadScene("GameOver");
        }
        else if (Input.GetKeyDown(KeyCode.Space)){
            isMovingStraight = !isMovingStraight;
            count++;
            Debug.Log("Count is"+count);
        }



       
       
    }

   void CheckPlanetProximity()
    {
      
        float proximityDistance = 3.0f;
    
        foreach (Transform planet in Targets)
        {
            float distance = Vector3.Distance(transform.position, planet.position);
            
          
            if (distance < proximityDistance && currentTarget!=planet)
            {
                currentTarget = planet;
                isMovingStraight = false;
                break;
            }
        }
    }
}
