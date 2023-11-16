using UnityEngine;

public class DestroyOnOutOfBound : MonoBehaviour
{
    private const float UpperBound = 25;
    private const float LowerBound = -10;
    private const float XBound = 25;

    void Update()
    {
        if (transform.position.z is > UpperBound or < LowerBound || transform.position.x is < -XBound or > XBound)
        {
            Destroy(gameObject);
        }
    }
}