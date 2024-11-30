using System;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] bool esSi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (esSi)
        {
            Debug.Log("HoverSi");
        }
        else
        {
            Debug.Log("HoverNo");
        }
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse exit");
    }
}
