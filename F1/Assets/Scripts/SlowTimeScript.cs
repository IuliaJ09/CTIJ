using UnityEngine;

public class SlowTimeScript : MonoBehaviour 
{
    public PowerUpData data; // Folosim "value" pentru factor (ex: 0.5) și "duration" dacă ai adăugat-o
    public float duration = 3f; // Cât timp să dureze încetinirea

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Timer.instance != null)
            {
                // data.value ar putea fi 0.5f (adică jumătate din viteză)
                Timer.instance.ActivateSlowTime(data.value, duration);
                Debug.Log("Slow Time activat!");
            }
            Destroy(gameObject);
        }
    }

}
