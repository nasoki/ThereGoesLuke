using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlippingScript : MonoBehaviour
{
    public GameObject playerRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRB.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            this.GetComponent<AreaEffector2D>().forceMagnitude = Mathf.Lerp(100f, 0f, 50f * Time.deltaTime);
        }
        else if(playerRB.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            this.GetComponent<AreaEffector2D>().forceMagnitude = Mathf.Lerp(-100f, 0f, 50f * Time.deltaTime); ;
        }
    }
}
