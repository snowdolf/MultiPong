using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;

    private float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (photonView.IsMine)
        {
            spriteRenderer.color = Color.blue;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        var input = InputButton.HorizontalInput;

        var distance = input * speed * Time.deltaTime;
        var targetPosition = transform.position + new Vector3(distance, 0, 0);

        playerRigidbody.MovePosition(targetPosition);
    }
}
