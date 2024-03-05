using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPostion;
    // loai phong 0 --> ho trai phai (RoomLeftRight); 1 --> ho trai phai duoi(RoomLRB); 
    //2 --> ho trai phai tren(RoomTRL); 3 -- > ho het(RoomF) 4end ( chua dc tao),5 begin
    public GameObject[] Rooms;
    public int direction;
    public float moveAmount = 20;
    public float MaxX = 70f, MinX = 0f, MinY = -80f;
    public bool generation = true;
    public LayerMask room;
    private int downcounter;

    [SerializeField]private float timeBetweenMoves = 1f;
    private float timer = 0f;
    void Start()
    {
        transform.position = startingPostion[UnityEngine.Random.Range(0, startingPostion.Length)].position;
        Instantiate(Rooms[5], transform.position, quaternion.identity);
        direction = UnityEngine.Random.Range(1, 4);
    }

    private void Move()
    {
        if (direction == 1)
        {
            if (transform.position.x < MaxX)
            {
                downcounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;
                Instantiate(Rooms[UnityEngine.Random.Range(0, 4)], transform.position, quaternion.identity);
                direction = UnityEngine.Random.Range(1, 4);
                if (direction == 2)
                {
                    direction = 1;
                }
            }
            else
            {
                direction = 3;
            }

        }
        else if (direction == 2)
        {
            if (transform.position.x > MinX)
            {
                downcounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;
                Instantiate(Rooms[UnityEngine.Random.Range(0, 4)], transform.position, quaternion.identity);
                direction = UnityEngine.Random.Range(1, 4);
                if (direction == 1)
                {
                    direction = 2;
                }
            }
            else
            {
                direction = 3;
            }

        }
        else if (direction == 3)
        {
            downcounter++;
            if (transform.position.y > MinY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<RoomValidator>().RoomType != 1 && roomDetection.GetComponent<RoomValidator>().RoomType != 3)
                {
                    roomDetection.GetComponent<RoomValidator>().Delete();
                    if (downcounter > 1)
                    {
                        Instantiate(Rooms[3], transform.position, quaternion.identity); 
                    }
                    else
                    {
                        int roomtype = UnityEngine.Random.Range(1, 4);
                        if (roomtype == 2)
                        {
                            roomtype = 1;
                        }
                        Instantiate(Rooms[roomtype], transform.position, quaternion.identity);
                    }
                }
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;
                Instantiate(Rooms[UnityEngine.Random.Range(2, 4)], transform.position, quaternion.identity);
                direction = UnityEngine.Random.Range(1, 4);
            }
            else
            {
                Collider2D roomCollider = Physics2D.OverlapCircle(transform.position, 1, room);
                Destroy(roomCollider.gameObject);
                Instantiate(Rooms[4], transform.position, quaternion.identity);
                generation = false;
            }
        }
    }
    private void FillEmptySpaces()
    {
        for (float x = 0; x <= 80; x += moveAmount)
        {
            for (float y = 0; y >= -80; y -= moveAmount)
            {
                
                Vector2 position = new Vector2(x, y);
                Collider2D roomDetection = Physics2D.OverlapCircle(position, 1, room);
                if (roomDetection == null)
                {
                    
                    Instantiate(Rooms[UnityEngine.Random.Range(0, 4)], position, Quaternion.identity);
                }
            }
        }
    }
    private void Update()
    {
        if (generation)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenMoves)
            {
                Move();
                timer = 0f;
            }
        }
        else{
        FillEmptySpaces();
        }
    }
}