using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public const int NORMAL_ROWS = 20;
    public const int MAX_ROWS = 23;
    public const int MAX_COLUMNS = 10;
    private Transform[,] map = new Transform[MAX_COLUMNS, MAX_ROWS];
    public int score = 0;
    public int highScore;
    private int numbersGame = 0;
    public bool isDataUpdate = false;
    public int Score { get { return score; } }
    public int HighScore { get { return highScore; } }

    public void Awake()
    {
        LoadData();
    }
    public bool isGameOver() {
        for (int i = NORMAL_ROWS; i < MAX_ROWS; i++) {
            for (int j = 0; j < MAX_COLUMNS; j++) {
                if (map[j, i] != null) {
                    SaveData();
                    return true;
                }
             
            }
        }
        return false;
    }
    public bool isValidMapPosition(Transform t) {
        foreach (Transform child in t) {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round()/200;
            Debug.Log(pos);
            if (isInsideMap(pos) == false) return false;
            if (map[(int)pos.x, (int)pos.y] != null) return false;
        }
        return true;
    }

    private bool isInsideMap(Vector2 pos) {
        return pos.x >= 0 && pos.x < MAX_COLUMNS && pos.y >= 0;
    }
    public bool PlaceShape(Transform t) {
        foreach (Transform child in t) {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round() / 200;
            map[(int)pos.x, (int)pos.y] = child;
        }
        return CheckMap();
    }

    private bool CheckMap() {
        int count = 0;
        for (int i = 0; i < MAX_ROWS; i++)
        {
            bool isFull = CheckIsRowFull(i);
            if (isFull) {
                count++;
                DeleteRow(i);
                MoveDownRowsAbove(i + 1);
                i--;
            }
        }
        if (count > 0) {
            score += count * 100;
            if (score > highScore)
            { 
                highScore = score;
            }
            isDataUpdate = true;
            return true;
        } 
        else return false;
    }
    private bool CheckIsRowFull(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++) {
            if (map[i, row] == null) return false;

        }
        return true;

    }
    private void DeleteRow(int row)
    {
        for (int i = 0;  i <MAX_COLUMNS;i++) { Destroy(map[i, row].gameObject); map[i, row] = null; }
        
    }
    private void MoveDownRowsAbove(int row) {
        for (int i = row; i < MAX_ROWS; i++) { 
            MoveDownRow(i);
        }
    }
    private void MoveDownRow(int row) {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] != null)
            {
                map[i, row - 1] = map[i, row];
                map[i, row] = null;
                map[i, row - 1].position += new Vector3(0, -200, 0);
            }
        }
    }
    private void LoadData()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        numbersGame = PlayerPrefs.GetInt("NumbersGame", numbersGame);
    }
    private void SaveData() {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("NumbersGame", numbersGame);
    }

    public void Restart()
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
            for (int j = 0; j < MAX_ROWS; j++)
            {
                if (map[i, j] != null) {
                    Destroy(map[i, j].gameObject); 
                    map[i, j] = null;
                }
            }
        score = 0;
    }
}
