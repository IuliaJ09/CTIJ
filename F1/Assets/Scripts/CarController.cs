using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 5f;
    public float turnSpeed = 50f;

    public float currentSpeed = 0f;
    public float driftFactor = 1f;

    public AudioSource engineAudio;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");
        float dt = Time.deltaTime / Time.timeScale;
        if (!FirstButton.instance.gameStarted)
            return;


        if (moveInput > 0)
        {
            currentSpeed += acceleration * dt;
        }
        else if (moveInput < 0)
        {
            currentSpeed -= acceleration * dt;
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, acceleration * dt);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed / 2, maxSpeed);

      
        transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

       
        if (Mathf.Abs(currentSpeed) > 0.1f) 
        {
            if (!engineAudio.isPlaying)
                engineAudio.Play();
        }
        else
        {
            if (engineAudio.isPlaying)
                engineAudio.Pause();
        }

    
        engineAudio.pitch = 0.5f + Mathf.Abs(currentSpeed) / maxSpeed;
    }
  }
