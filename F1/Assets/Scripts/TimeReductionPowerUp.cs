using UnityEngine;

public class TimeReductionPowerUp : MonoBehaviour
{
    public PowerUpData data; // legãm aici ScriptableObject-ul

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Scade timpul folosind Timer.instance
            if (Timer.instance != null)
            {
                Timer.instance.SubtractTime(data.value);
                Debug.Log($"Timp redus cu {data.value} secunde!");
            }

            // Distruge power-up-ul dupã colectare
            Destroy(gameObject);
        }
    }
}
