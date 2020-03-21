﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Material mat;
    public Color onColor;
    public bool on = false;

    // Start is called before the first frame update
    public void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");

        LevelManager.levelManager.winEvent += OnWin;
    }

    public virtual void FindNext()
    {

    }

    public void FlipOn()
    {
        on = !on;
        ChangeEmission();
        LevelManager.levelManager.UpdateCubes(on);
    }

    public void ChangeEmission()
    {
        try
        {
            if (on)
            {
                mat.SetColor("_EmissionColor", onColor);
            }
            else
            {
                mat.SetColor("_EmissionColor", Color.black);
            }
        }
        catch
        {
            mat = this.GetComponent<Renderer>().material;
            ChangeEmission();
        }
    }

    public void TurnOff()
    {
        on = false;
        mat.SetColor("_EmissionColor", Color.black);
    }

    public void CheckWin()
    {
        LevelManager.levelManager.CheckWin();
    }

    public void OnWin()
    {
        this.enabled = false;
    }
}
