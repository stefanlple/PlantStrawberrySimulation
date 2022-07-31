using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryInBucket : AnimationAktion
{
    public GameObject water;
    public GameObject stawberry2pb;
    public GameObject bucket;

    public void putStrawberryIntoBucket()
    {
        water.transform.position=new Vector3(-19.29f, 17.6f, -20.42798f);;
    }
    public void deactivateStrawberryIntoBucket()
    {
        stawberry2pb.SetActive(false);
        bucket.SetActive(false);

    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
