using System;
using TMPro;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] bool esSi;

    [SerializeField] private GameManager gm;
    [SerializeField] private TextMeshPro text;

    private Material mat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        mat = GetComponent<SpriteRenderer>().material;
        text = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (esSi)
        {
            mat.SetFloat("_Hovering", 1.0f);
            text.text = gm.activeEvent.si;
            mat.color = new Color(0.517f, 1f, 0.914f);
        }
        else
        {
            mat.SetFloat("_Hovering", 1.0f);
            text.text = gm.activeEvent.no;
            mat.color = new Color(0.517f, 1f, 0.914f);
        }
    }

    public void OnMouseExit()
    {
        mat.SetFloat("_Hovering", 0.0f);
        mat.color = Color.clear;
        text.text = "";
    }
}
