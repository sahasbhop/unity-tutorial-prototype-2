using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private const float SpawnGapInSecond = 0.5f;
    private float _spawnTimestamp;
    public GameObject dogPrefab;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.fixedTime - _spawnTimestamp > SpawnGapInSecond)
        {
            _spawnTimestamp = Time.fixedTime;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
