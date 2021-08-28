using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGoingUp : MonoBehaviour
{
    //conf param
    [SerializeField] float waterGoingUpDelta = 0.1f;

    //states
    float timeDelta = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float moveDelta = waterGoingUpDelta * Time.deltaTime / timeDelta;
        transform.Translate(new Vector2(0f, moveDelta));
    }
}
