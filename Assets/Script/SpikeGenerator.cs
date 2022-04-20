using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    void Awake()
    {
        currentSpeed = minSpeed;
        generateSpike();
    }

    public void GenerateNextSpikeGap()
    {
        float random = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", random);
    }

    public void generateSpike()
    {
        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);

        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < maxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}
