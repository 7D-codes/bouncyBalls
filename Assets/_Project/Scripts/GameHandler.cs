using UnityEngine;
using TMPro;
public class GameHandler : MonoBehaviour
{
    private TextMeshProUGUI ballCountText;

    public GameObject ballPrefab;
    public int ballCount = 0;

    private void Start()
    {
        ballCountText = GameObject.Find("BallCountText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
        ballCountText.text = ballCount.ToString();
        
        Vector2 spawnPos = new Vector2(Random.Range(-3.5f, 3.5f), 2.5f);

        if (Input.GetMouseButtonDown(0))
        {
            SpawnBall(spawnPos);
        }
    }

    private void SpawnBall(Vector2 pos)
    {
        Debug.Log("Spawned ball at " + pos);
        GameObject ball = Instantiate(ballPrefab, pos, Quaternion.identity);
        ball.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        ball.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-100, 100);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-3.5f, 2.5f, 0), new Vector3(3.5f, 2.5f, 0));
    }

}
