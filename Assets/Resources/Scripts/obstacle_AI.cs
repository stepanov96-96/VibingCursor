using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_AI : MonoBehaviour
{
    public Transform trans;
    private SpriteRenderer rend;
    private PolygonCollider2D coll;
    
    public Vector3 localScale;
    float sc = 0.2f;
    int score = 0;
    private camera_AI camera_AI;

    private void Awake()
    {
        sc = camera_AI.levelUp;
        
    }

    void Start()
    {
        //START -->
        // Transform block -->
        trans = gameObject.GetComponent<Transform>();
        trans.transform.position = new Vector3(0, 0, 1);
        trans.transform.localScale = new Vector2(14, 14);
        // Sprite Renderer block -->
        rend = gameObject.AddComponent<SpriteRenderer>();
        rend.sprite = Resources.Load<Sprite>("Sprites/obstacle_2");
        rend.sortingOrder = 0;
        // PolygonCollider2D block -->
        gameObject.AddComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (transform.localScale.y <= 1.1f)
        {
            Destroy(gameObject);
            camera_AI.Score();
        }

        
        transform.localScale -= new Vector3(sc, sc, 0);
    }

    void Score1() { score++; Debug.Log(score); }
}
