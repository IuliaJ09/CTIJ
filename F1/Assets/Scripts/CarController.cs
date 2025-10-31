using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 5f;
    public float turnSpeed = 50f;

    private float currentSpeed = 0f;

    // Audio
    public AudioSource engineAudio;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        // Acceleratie
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

        // Miscare masina
        transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

        // Control sunet motor
        if (Mathf.Abs(currentSpeed) > 0.1f) // daca masina se misca
        {
            if (!engineAudio.isPlaying)
                engineAudio.Play();
        }
        else
        {
            if (engineAudio.isPlaying)
                engineAudio.Pause();
        }

        // Optional: poti ajusta volumul/pitch in functie de viteza
        engineAudio.pitch = 0.5f + Mathf.Abs(currentSpeed) / maxSpeed; // mai rapid = sunet mai inalt
    }
}
