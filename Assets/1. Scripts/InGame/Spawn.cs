using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnPeriod_A = 1f;
    public GameObject target = null;
    private float time = 0f;

    private Transform[] spawnPositionList;

    private void Awake()
    {
        spawnPositionList = GetComponentsInChildren<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnPeriod_A)
        {
            time = 0f;
            // spawn();
            fireAtIndexPosition(Random.Range(1, 10), 0);
        }
    }
    void spawn()
    {
        GameObject instance = Instantiate(target, this.transform);
        instance.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
    }

    void fireAtIndexPosition(int positionIndex, int type)
    {
        Transform firePosition = spawnPositionList[positionIndex];
        GameObject projectile = TargetManager.targetManager.pooling(type);
        projectile.transform.position = spawnPositionList[positionIndex].position;

        projectile.GetComponent<Target>().setTrack();
    }
}
