using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 25;

    private GameManager _gameManager;
    private const float BoundaryX = 15;
    private const float BoundaryZ = 7;
    private float _horizontalInput;
    private float _verticalInput;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        var playerTransform = transform;
        var position = playerTransform.position;
        if (position.x < -BoundaryX)
        {
            playerTransform.position = new Vector3(-BoundaryX, position.y, position.z);
        }
        else if (position.x > BoundaryX)
        {
            playerTransform.position = new Vector3(BoundaryX, position.y, position.z);
        }
        else
        {
            playerTransform.Translate(Vector3.right * (_horizontalInput * speed * Time.deltaTime));    
        }

        if (position.z > BoundaryZ)
        {
            playerTransform.position = new Vector3(position.x, position.y, BoundaryZ);
        }
        else if (position.z < 0)
        {
            playerTransform.position = new Vector3(position.x, position.y, 0);
        }
        else
        {
            playerTransform.Translate(Vector3.forward * (_verticalInput * speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, new Vector3(position.x, position.y, position.z + 1), projectile.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.ReduceLive();
    }
}