using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float ballSpeed;
    public Image bar;
    public float reduceAmount, lerpTime;
    public bool IsHotSpot;
    public Color[] colors;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        Mathf.Clamp(bar.fillAmount, 0, 1);


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.AddTorque(new Vector3(horizontal, 0, vertical) * ballSpeed );

        if(IsHotSpot == true)
        {
            IncreaseHeatBar();
        }
        else
        {
            ReduceHeatBar();
        }

        if(bar.fillAmount >=1)
        Debug.Log("OVERHEATED");

     


    }


    public void ReduceHeatBar()
    {
        bar.fillAmount -= Time.deltaTime * reduceAmount;
       // bar.color = Color.Lerp(bar.color, lowBar, lerpTime*Time.deltaTime);

    }

    public void IncreaseHeatBar()
    {
        bar.fillAmount += Time.deltaTime * reduceAmount;
       // bar.color = Color.Lerp(bar.color, fullBar, lerpTime*Time.deltaTime);
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hotspot"))
        {
            IsHotSpot = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Hotspot"))
        {
            IsHotSpot = false;

        }
    }

}
