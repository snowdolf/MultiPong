using Photon.Pun;
using UnityEngine;

public class Ball : MonoBehaviourPun
{
    public bool IsMasterClientLocal => PhotonNetwork.IsMasterClient && photonView.IsMine;

    private Vector2 direction = Vector2.up;
    private readonly float speed = 5f;
    private readonly float randomReflectionIntensity = 0.1f;

    private void FixedUpdate()
    {
        if (!IsMasterClientLocal || PhotonNetwork.PlayerList.Length < 2)
        {
            return;
        }

        var distance = speed * Time.fixedDeltaTime;
        var hit = Physics2D.Raycast(transform.position, direction, distance);

        if (hit.collider != null)
        {
            var goalPost = hit.collider.GetComponent<GoalPost>();

            if (goalPost != null)
            {
                if (goalPost.playerNumber == 1)
                {
                    GameManager.Instance.AddScore(2, 1);
                }
                else if (goalPost.playerNumber == 2)
                {
                    GameManager.Instance.AddScore(1, 1);
                }

            }

            direction = Vector2.Reflect(direction, hit.normal);
            direction += Random.insideUnitCircle * randomReflectionIntensity;
        }

        transform.position += (Vector3)(direction * distance);
    }
}
