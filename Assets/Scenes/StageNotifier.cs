using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNotifier : MonoBehaviour
{
    public GameObject notifier;
    private float TimeLeft = 3.0f, nextTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > TimeLeft)
        {
            Destroy(notifier);
        }
    }
}
