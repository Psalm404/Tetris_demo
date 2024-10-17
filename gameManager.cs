using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private bool isPause = true;
    // Start is called before the first frame update
    private Shape currentShape = null;
    public Shape[] shapes;
    public Color[] colors;
    private Controller controller;
    
    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause) return;
        if (currentShape == null)
            SpawnShape();
    }
    public void StartGame() { 
        isPause = false;
        if (currentShape != null)
            currentShape.Resume();
    }
    public void PauseGame() {
        isPause = true;
        if (currentShape != null)
            currentShape.Pause();

    }
    void SpawnShape() { 
        int index = Random.Range(0, shapes.Length-1);
        int indexColor = Random.Range(0, colors.Length-1);
        Debug.Log(index, shapes[index]);
        currentShape = GameObject.Instantiate(shapes[index]);
        currentShape.Init(colors[indexColor],controller,this);
        currentShape.gameObject.SetActive(true);
    
    }
    public void FallDown() {
        currentShape = null;
        if (controller.model.isDataUpdate) {
            controller.view.UpdateGameUI(controller.model.Score, controller.model.HighScore);
        }
        if (controller.model.isGameOver()) { 
            PauseGame();
            controller.view.ShowGameOverUI(controller.model.Score);
        }
    }
}
