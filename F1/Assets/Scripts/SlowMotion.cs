using UnityEngine;
using System.Collections;

public class SlowMotionPowerUp : MonoBehaviour
{
    public PowerUpData data; // putem folosi ScriptableObject-ul pentru a seta intensitatea (ex: cât de lent)
    public float slowDuration = 2f; // cât ține efectul în secunde reale
    public float slowFactor = 0.5f; // cât de încet devine timpul (0.5 = la jumătate)

    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateSlowMotion());
        }
    }

    private IEnumerator ActivateSlowMotion()
    {
        isActivated = true;

        // activăm slow motion
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // important pentru fizică

        Debug.Log("Slow motion ACTIVAT!");

        // așteptăm 2 secunde în timp real (nu afectat de Time.timeScale)
        yield return new WaitForSecondsRealtime(slowDuration);

        // revenim la normal
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        Debug.Log("Slow motion dezactivat!");

        // distrugem obiectul după folosire
        Destroy(gameObject);
    }
}
