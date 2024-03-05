using UnityEngine;

public class CreateRandom : MonoBehaviour
{
    public GameObject[] gameObjects;

    void Start()
    {
            int gameObjectSize = gameObjects.Length;
            int rand = UnityEngine.Random.Range(0, gameObjectSize);
            Instantiate(gameObjects[rand], transform.position, Quaternion.identity);
    }
}
