using System;

using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 이 스크립트에선 피격체를 타격할 때의 일들을 다룹니다.
/// 1. 충돌 시 속도 측정
/// 2. 이펙트 발생
/// </summary>
public class Hand : MonoBehaviour
{
    public Queue<Tuple<int, float>> speedList = new Queue<Tuple<int, float>>();
    new Rigidbody rigidbody;

    public Tuple<int, float> maxSpeed = new Tuple<int, float>(0, 0f);

    public int fixedUpdateCount = 0;

    public bool collision = false;

    public List<GameObject> particles;

    public bool printed = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        fixedUpdateCount++;
        if (maxSpeed.Item2 < rigidbody.velocity.magnitude)
        {
            maxSpeed = new Tuple<int, float>(fixedUpdateCount, rigidbody.velocity.magnitude * 1000);
        }
        // print(fixedUpdateCount + "째 물리 업데이트입니다.");
        // print("-------------------------------------");

        if (!collision)
            if (speedList.Count < 3)
            {
                speedList.Enqueue(new Tuple<int, float>(fixedUpdateCount, rigidbody.velocity.magnitude * 1000));
            }
            else
            {
                speedList.Dequeue();
                speedList.Enqueue(new Tuple<int, float>(fixedUpdateCount, rigidbody.velocity.magnitude * 1000));
            }
        else if (collision && !printed)
        {
            printed = true;
            printSpeed();
        }
    }

    public void printSpeed()
    {
        // print(fixedUpdateCount + "번째 업데이트 때 실행됐습니다.");
        foreach (Tuple<int, float> speed in speedList)
        {
            print("시간 : " + speed.Item1 + " 속도 : " + speed.Item2);
        }
        print("최고 속도는 " + maxSpeed.Item2);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            collision = true;
            print(fixedUpdateCount + " 충돌 시 속도 :  " + rigidbody.velocity.magnitude * 10000000);
            
            // 타격 이펙트 발생.
            OnHit(other);
        }
    }

    void OnHit(Collision other)
    {
        print("뭔데?");
        int random = Random.Range(0, 4);
        GameObject hitEffect = Instantiate(particles[random]);
        hitEffect.transform.position = other.GetContact(0).point;
    }

}
