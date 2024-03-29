﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Material mat;
    public Color onColor;
    public bool on = false;
    public GameObject particleShot;
    public bool foundMirror = false;
    public int numOfFlips = 0;
    AudioSource audioSource;

    // Start is called before the first frame update
    public void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");

        audioSource = this.GetComponent<AudioSource>();
        LevelManager.levelManager.winEvent += OnWin;
    }

    public virtual void FindNext()
    {

    }

    public void FlipOn()
    {
        numOfFlips++;
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

    public void FireParticle(Vector3 v3)
    {
        particleShot.GetComponent<ParticleShot>().particleColor = onColor;
        particleShot.GetComponent<ParticleShot>().direction = v3;
        Instantiate(particleShot, this.transform.position + v3 / 2, Quaternion.identity);
    }

    public void TurnOff()
    {
        on = false;
        mat.SetColor("_EmissionColor", Color.black);
    }

    public void CheckWin()
    {
        audioSource.Stop();
        audioSource.Play();
        LevelManager.levelManager.CheckWin();
    }

    public void OnWin()
    {
        this.enabled = false;
    }
}
