using UnityEngine;

public class Minimap : MonoBehaviour
{
	// public Transform player;

	// void LateUpdate()
	// {
	// 	Vector3 newPosition = player.position; 	// Capture the player position
	// 	newPosition.y = transform.position.y;
	// 	transform.position = newPosition; 		// Change into a newPosition

	// 	transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); // Rotation
	// }

	[SerializeField] private Transform _playerTransform;  
    [SerializeField] private Transform _playerIcon;
    private float _playerIconOffset = 1.5f;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playerIcon = GameObject.Find("PlayerIcon");

        if (player != null)
            _playerTransform = player.GetComponent<Transform>();

        if (playerIcon != null)
            _playerIcon = playerIcon.GetComponent<Transform>();
    }

    void Update()
    {
        if (_playerTransform != null && _playerIcon != null)
        {
            // Match the sprite's position to the player's position
            _playerIcon.transform.position = new Vector3(_playerTransform.position.x,
                                                         transform.position.y - _playerIconOffset,
                                                         _playerTransform.position.z);

            // Calculate the desired rotation for the player icon
            Quaternion desiredRotation = Quaternion.Euler(90f, _playerTransform.eulerAngles.y, 0f);

            // Match the player icon's rotation to the desired rotation
            _playerIcon.rotation = desiredRotation;

        }
    }
}