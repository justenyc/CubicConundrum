﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.levelManager.winEvent += OnWin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out Cube c))
                {
                    //Debug.Log(c.name);
                    c.ChangeEmission();
                    c.FindNext();
                }
            }
        }
    }

    public void OnWin()
    {
        this.enabled = false;
    }
}