using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeComb : MonoBehaviour
{
    public Transform VRHeadset;
    public float time;
    public int positionIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(VRHeadset);
    }

    // 시간 위치 
    private void OnCollisionEnter(Collision other)
    {
        
    }
}
