using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 20f;      
    public float acceleration = 5f;    
    public float turnSpeed = 50f;

    private float currentSpeed = 0f;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");   
        float turn = Input.GetAxis("Horizontal");     

        
        if (moveInput > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (moveInput < 0)
        {
            currentSpeed -= acceleration * Time.deltaTime; 
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, acceleration * Time.deltaTime);
        }

       
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed / 2, maxSpeed);

       
        transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
    }
}
