using UnityEngine;
using TMPro;
using System;

public class GameHandler : MonoBehaviour
{
    private TextMeshProUGUI ballCountText;
    public GameObject ballPrefab;
    public int ballCount = 0;

    public Vector2 SpawnArea;

    private Color[] ballColors = new Color[] {
        new Color(0.47058823529f, 0.67058823529f, 0.69803921569f), // Color #118ab2
        new Color(0.02352941176f, 0.83921568627f, 0.62745098039f), // Color #06d6a0
        new Color(1f, 0.83921568627f, 0.4f),                       // Color #ffd166
        new Color(0.93725490196f, 0.27843137255f, 0.49803921569f)  // Color #ef476f
    };

    private void Start()
    {
        ballCountText = GameObject.Find("BallCountText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
        ballCountText.text = ballCount.ToString();

        if (ballCount <= 0)
            SpawnBall(); 
    }

    public void SpawnBall()
    {
        Vector2 pos = new Vector2(UnityEngine.Random.Range(-3.5f, 3.5f), 2.5f);

        GameObject ball = Instantiate(ballPrefab, pos, Quaternion.identity);

        Color randomColor = ballColors[UnityEngine.Random.Range(0, ballColors.Length)];
        ball.GetComponent<SpriteRenderer>().color = randomColor;
        
        Debug.Log("Spawned ball at " + pos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-3.5f, 2.5f, 0), new Vector3(3.5f, 2.5f, 0));
    }
}
