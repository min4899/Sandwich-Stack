using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Sandwich sandwich;
    public FoodSpawn foodSpawn;
    public Camera cam;
    public float score;
    //public float camOffset = 11f;
    public float camSpeed = 1f;

    private float camOffset;
    private float nextSpawn;

    void Awake()
    {
        instance = this;
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        camOffset = cam.transform.position.y;

        //cam.transform.position = new Vector3(-4.5f, sandwich.height + camOffset, -4.5f);
        cam.transform.position = new Vector3(cam.transform.position.x, sandwich.height + camOffset, cam.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(cam.transform.position.x, sandwich.height + camOffset, cam.transform.position.z);
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, targetPosition, camSpeed * Time.deltaTime);
    }

    public void updateScore()
    {
        score++;

        //cam.transform.position = new Vector3(-4.5f, sandwich.height + camOffset, -4.5f);
        //Vector3 targetPosition = new Vector3(-4.5f, sandwich.height + camOffset, -4.5f);
        //cam.transform.position = Vector3.MoveTowards(cam.transform.position, targetPosition, camSpeed * Time.deltaTime);
    }
}
