using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle3_AI : MonoBehaviour
{
    public Transform trans;
    private SpriteRenderer rend;
    private PolygonCollider2D coll;
    private camera_AI camera_AI;
    public Vector3 localScale;
    float sc = 0.02f;

    //private void Awake()
    //{
    //    sc = camera_AI.levelUp;
    //}

    // Start is called before the first frame update
    void Start()
    {
        //START —>
        // Transform block —>
        trans = gameObject.GetComponent<Transform>();
        trans.transform.position = new Vector3(0, 0, 1);
        trans.transform.localScale = new Vector2(0, 0);
        // Sprite Renderer block —>
        rend = gameObject.AddComponent<SpriteRenderer>();
        rend.sprite = Resources.Load<Sprite>("Sprites/obstacle_2");
        rend.sortingOrder = 0;
        // PolygonCollider2D block —>
        gameObject.AddComponent<PolygonCollider2D>();
        //<— END
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.localScale.y >= 1.5f)
        {
            Destroy(gameObject);
            camera_AI.Score();
        }

        transform.localScale += new Vector3(sc, sc, 0);
    }
}
