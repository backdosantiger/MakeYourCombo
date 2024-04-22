using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    static public TargetManager targetManager;

    public List<GameObject> targets = new List<GameObject>();
    private List<GameObject> pools = new List<GameObject>();

    // 식별할 수 있는 조건
    // 

    // Start is called before the first frame update

    public Transform spawnPosition;

    private void Awake()
    {
        targetManager = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject pooling(int index)
    {
        GameObject gameObject = null;

        for (int i = 0; i < pools.Count; i++)
        {
            gameObject = pools[i];

            if (gameObject.activeSelf && gameObject.GetComponent<Target>().IsType(index))
            {
                return gameObject;
            }
        }

        gameObject = Instantiate(targets[index], spawnPosition);

        // TODO 생성된 타겟 초기화. 속도 
        // gameObject.GetComponent<Target>().Init();
        return gameObject;
    }

    public void MakeByData()
    {

    }
}
