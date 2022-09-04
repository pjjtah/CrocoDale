using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class CameraController : MonoBehaviour {

    public static bool finish;
    private float y;

    public Tilemap[] ground;
    public bool darken;
    public float intensity;


    public GameObject playerObject;
    private Transform player;

    private PlayerController playerScript;
    // Use this for initialization
    void Start () {
        finish = false;
        player = playerObject.GetComponent<Transform>();
        playerScript = playerObject.GetComponent<PlayerController>();
		
	}

    // Update is called once per frame
    void Update() {

        if (player != null && !finish)
        {
            if (darken)
            {
                foreach (Tilemap t in ground)
                {


                    t.color = Color.Lerp(Color.white, Color.black, player.position.x * intensity);
                }
            }
            if (playerScript.IsGrounded() || player.position.y<transform.position.y || player.position.y>transform.position.y+3)
            {
                y = Vector3.MoveTowards(transform.position, new Vector3(player.position.x , player.position.y+1, -10), Time.deltaTime*20).y;
            }
            transform.position = new Vector3(player.position.x +5, y, -10);
        }
    }
}
