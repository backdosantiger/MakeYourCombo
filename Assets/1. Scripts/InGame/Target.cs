using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 이 스크립트에선 피격체가 피격되었을 때 일어나는 일들을 다룬다.
/// 1. 맞은 부위에서 이펙트 발생
/// 2. 
/// </summary>
public class Target : MonoBehaviour
{
    private float time;
    private bool timeCheck;
    private Vector3 hitPoint;

    public int type = -1;

    private Rigidbody rigidbody;

    public Transform test;

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
        if (timeCheck)
        {
            time += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        timeCheck = true;
        hitPoint = other.GetContact(0).point;
        rigidbody.useGravity = true;
        StartCoroutine(disableAfterTime(3.0f));
    }

    public bool IsType(int index)
    {
        if (type == -1)
        {
            print("발사체의 타입 설정이 안 됐습니다.");
            throw new System.NotImplementedException();
        }
        if (type == index)
            return true;
        else
            return false;
    }

    public void setTrack()
    {
        rigidbody.velocity = new Vector3(0, 0, -5);
    }

    IEnumerator disableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }


}
