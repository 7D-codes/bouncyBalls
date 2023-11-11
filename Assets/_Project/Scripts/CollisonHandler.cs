using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    GameHandler gh;
    public GameObject enemy;

    private void Start()
    {
        gh = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gh.SpawnBall();
            Debug.Log("Hit");
            
            // Check if the local scale of the enemy is smaller than (2, 1, 2) before scaling.
            if (enemy.transform.localScale.x < 2f && enemy.transform.localScale.y < 1f && enemy.transform.localScale.z < 2f)
            {
                // Scale the enemy by adding (0.1, 0.1, 0.1) to its local scale.
                enemy.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
    }
}
