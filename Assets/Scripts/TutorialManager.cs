using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    private int step;
    private bool firstStep;
    [SerializeField] private TextMeshProUGUI stepText;
    [SerializeField]private List<SpriteRenderer> pantallas;
    [SerializeField]private List<SpriteRenderer> interiores;
    [SerializeField]private List<Material> materials;
    Material material;
    LoadScene loadScene;

    private void Awake()
    {
        firstStep = true;
        step = 0;
        stepText.text = "";
        loadScene = FindFirstObjectByType<LoadScene>();
        foreach (var i in interiores)
        {
            i.color = Color.black;
        }

        foreach (var p in pantallas)
        {
            material = new Material(p.material);
            materials.Add(material);
            p.enabled = false;
        }
    }

    private void Update()
    {
        switch (step)
        {
            case 0:
                Tut0();
                break;
            case 1:
                Tut1();
                break;
            case 2:
                Tut2();
                break;
            case 3:
                Tut3();
                break;
            case 4:
                Tut4();
                break;
            case 5:
                Tut5();
                break;
            case 6:
                Tut6();
                break;
            case 7:
                Tut7();
                break;
            case 8:
                Tut8();
                break;
            case 9:
                Tut9();
                break;
            case 10:
                Tut10();
                break;
            case 11:
                Tut11();
                break;
            case 12:
                Tut12();
                break;
            default:
                break;
        }
    }

    private void Tut0()
    {
        stepText.text = "Bienvenido A.I.Sidro a tu pueto de trabajo, toca gestionar la ciudad de Madrid. Pulsa uno de los botones para iniciar el programa.";
    }

    private void Tut1()
    {
        stepText.text = "Muy bien! Vamos a iniciar las camaras de la ciudad!";
    }

    private void Tut2()
    {
        stepText.text = "Fantastico! Ahora ya podemos ver las distintas partes de Madrid. Recuerdas como funcionaba esto verdad?";
        foreach (var p in pantallas)
        {
            p.enabled = true;
        }
        foreach (var i in interiores)
        {
            i.color = Color.white;
        }
    }

    private void Tut3()
    {
        stepText.text = "Madrid, como todas las ciudades tiene diferentes zonas, tendras que mantener todas bien felices si quieres conservar tu trabajo";
    }

    private void Tut4()
    {
        if (firstStep)
        {
            firstStep = false;
            stepText.text = "Lo puedes ver por los distintos tipos de pantalla";
            pantallas[2].material.SetFloat("_Blink", 1f);
            pantallas[5].material.SetFloat("_Blink", 1f);
            pantallas[8].material.SetFloat("_Blink", 1f);
        }
    }

    private void Tut5()
    {
        if (firstStep)
        {
            firstStep = false;
            stepText.text = "Tambien cambiaran de estetica en funcion de lo bien o mal que lo vayas haciendo.";
            pantallas[2].material.SetFloat("_Blink", 0f);
            pantallas[5].material.SetFloat("_Blink", 0f);
            pantallas[8].material.SetFloat("_Blink", 0f);
            pantallas[1].material.SetFloat("_Blink", 1f);
            pantallas[4].material.SetFloat("_Blink", 1f);
            pantallas[7].material.SetFloat("_Blink", 1f);
        }
    }

    private void Tut6()
    {
        if (firstStep)
        {
            firstStep = false;
            stepText.text = "Asi que ten cuidado y manten a la ciudad feliz con tus decisiones";
            pantallas[1].material.SetFloat("_Blink", 0f);
            pantallas[4].material.SetFloat("_Blink", 0f);
            pantallas[7].material.SetFloat("_Blink", 0f);
            pantallas[0].material.SetFloat("_Blink", 1f);
            pantallas[6].material.SetFloat("_Blink", 1f);
            pantallas[3].material.SetFloat("_Blink", 1f);
        }
    }

    private void Tut7()
    {
        if (firstStep)
        {
            firstStep = false;
            stepText.text = "Todo ello sin olvidar los marcadores de la derecha!";
            pantallas[0].material.SetFloat("_Blink", 0f);
            pantallas[6].material.SetFloat("_Blink", 0f);
            pantallas[3].material.SetFloat("_Blink", 0f);
        }
    }

    private void Tut8()
    {
        if (firstStep)
        {
            firstStep = false;
            stepText.text = "Manten la satisfaccion de la gente bien!";
            pantallas[0].material.SetFloat("_Blink", 1f);
            pantallas[6].material.SetFloat("_Blink", 1f);
            pantallas[2].material.SetFloat("_Blink", 1f);
            //0, 0.5, 0.6
            pantallas[0].material.color = new Color(0.2f, 0.2f, 1f, 1f);
            pantallas[6].material.color = new Color(0.2f, 0.2f, 1f, 1f);
            pantallas[2].material.color = new Color(0.2f, 0.2f, 1f, 1f);
        }
    }

    private void Tut9()
    {
        if (firstStep)
        {
            firstStep = false;
            stepText.text = "Manten la cultura de la ciudad atractiva!";
            pantallas[0].material.SetFloat("_Blink", 0f);
            pantallas[6].material.SetFloat("_Blink", 0f);
            pantallas[2].material.SetFloat("_Blink", 0f);
            pantallas[0].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
            pantallas[6].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
            pantallas[2].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
            pantallas[1].material.SetFloat("_Blink", 1f);
            pantallas[4].material.SetFloat("_Blink", 1f);
            pantallas[5].material.SetFloat("_Blink", 1f);
            pantallas[1].material.color = new Color(0.8f, 0.5f, 0.2f, 1f);
            pantallas[4].material.color = new Color(0.8f, 0.5f, 0.2f, 1f);
            pantallas[5].material.color = new Color(0.8f, 0.5f, 0.2f, 1f);
        }
    }

    private void Tut10()
    {
        if (firstStep)
        {
            firstStep = false;
            stepText.text = "Consigue que el transporte de Madrid vaya viento en popa!";
            pantallas[1].material.SetFloat("_Blink", 0f);
            pantallas[4].material.SetFloat("_Blink", 0f);
            pantallas[5].material.SetFloat("_Blink", 0f);
            pantallas[1].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
            pantallas[4].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
            pantallas[5].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
            pantallas[3].material.SetFloat("_Blink", 1f);
            pantallas[7].material.SetFloat("_Blink", 1f);
            pantallas[8].material.SetFloat("_Blink", 1f);
            pantallas[3].material.color = new Color(0.1f, 0.9f, 0.2f, 1f);
            pantallas[7].material.color = new Color(0.1f, 0.9f, 0.2f, 1f);
            pantallas[8].material.color = new Color(0.1f, 0.9f, 0.2f, 1f);
        }
    }
    
    private void Tut11()
    {
        if (firstStep)
        {
            firstStep = false;
            stepText.text = "Y una vez repasito hecho, ya estas listo para la accion! Mucha suerte en tu jornada";
            pantallas[3].material.SetFloat("_Blink", 0f);
            pantallas[7].material.SetFloat("_Blink", 0f);
            pantallas[8].material.SetFloat("_Blink", 0f);
            pantallas[3].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
            pantallas[7].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
            pantallas[8].material.color = new Color(0.0f, 0.5f, 0.6f, 1f);
        }
    }
    
    private void Tut12()
    {
        if (firstStep)
        {
            firstStep = false;
            loadScene.selectScene(1);
        }
    }

    public void addStep()
    {
        step++;
        firstStep = true;
    }
}
