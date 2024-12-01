using System;
using TMPro;
using UnityEngine;

public class HoverMenu : MonoBehaviour
{
    [SerializeField] private bool esSi;
    [SerializeField] private TextMeshPro text;

    private Material mat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        text = GetComponentInChildren<TextMeshPro>();
    }
    
    private void OnMouseEnter()
    {
        if (esSi)
        {
            mat.SetFloat("_Hovering", 1.0f);
            text.text = "Jugar";
            mat.color = new Color(0.517f, 1f, 0.914f);
        }
        else
        {
            mat.SetFloat("_Hovering", 1.0f);
            text.text = "Salir";
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
