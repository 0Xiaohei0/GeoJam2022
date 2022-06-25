using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject circle;
    public GameObject redSpawnPosition;
    public GameObject blueSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCircle()
    {
        Instantiate(circle, redSpawnPosition.transform.position, redSpawnPosition.transform.rotation);
    }

}
