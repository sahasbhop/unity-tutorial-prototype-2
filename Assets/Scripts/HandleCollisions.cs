using UnityEngine;

public class HandleCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
        if (other.CompareTag("Animal"))
        {
            var hungerSlider = other.GetComponent<HandleHungerBar>();
            hungerSlider.Feed();
        }
    }
}