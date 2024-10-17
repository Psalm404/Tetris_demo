using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private Controller controller;
    private gameManager gamemanager;
    public bool isPause = false;
    private bool isSpeedUp = false;
    private float timer = 0;
    private float stepTime = 0.8f;
    private int multiple = 16;
    private Transform pivot;
    public void Awake()
    {
        pivot = transform.Find("pivot");
    }
    private void Update()
    {
        if (isPause) return;
        timer += Time.deltaTime;
        if (timer > stepTime) {
            timer = 0;
            Fall();
        }
        InputControl();
    }
    public void Init(Color color,Controller controller, gameManager gamemanager) { 
        foreach (Transform t in transform)
        {
            if (t.tag == "Block") {
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }
        this.controller = controller;
        this.gamemanager = gamemanager;
    }
    public void Fall()
    {
        Vector3 pos = transform.position;
        pos.y -= 200;
        transform.position = pos;
        if (controller.model.isValidMapPosition(this.transform) == false) {
            pos.y += 200;
            transform.position = pos;
            isPause = true;
            
            bool isLineClear = controller.model.PlaceShape(this.transform);
            if (isLineClear) { controller.audioManager.PlayLineClear(); }
            gamemanager.FallDown();
            return;
        }
        controller.audioManager.PlayDrop();
    }
    private void InputControl()
    {
        if (isSpeedUp) return;
        float h = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            h = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            h = 1;
        }
        UnityEngine.Debug.Log(h);
        if (h != 0)
        {
            Vector3 pos = transform.position;
            pos.x += h * 200;
            transform.position = pos;
            if (controller.model.isValidMapPosition(this.transform) == false)
            {
                pos.x -= h * 200;
                transform.position = pos;
            }
            else
            {
                controller.audioManager.PlayControl();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(pivot.position, Vector3.forward, -90);
            UnityEngine.Debug.Log(transform.position);
            if (controller.model.isValidMapPosition(this.transform) == false)
            {
                transform.RotateAround(pivot.position, Vector3.forward, 90);
            }
            else
            {
                controller.audioManager.PlayControl();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isSpeedUp = true;
            stepTime /= multiple;
        }
    }
    public void Pause() {
        isPause = true;
    }
    public void Resume() {
        isPause = false;
    }
}
