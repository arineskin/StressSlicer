using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    static GameSystem _system;

    public GameObject GameScoreCanvas;
    public GameObject EndGameCanvas;
    public Text EndScoreText;
    public Text EndBestScoreText;
    public static GameSystem System
    {
        get
        {
            if (_system == null)
            {
                _system = GameObject.FindObjectOfType<GameSystem>();
                if (_system == null)
                {
                    GameObject container = new GameObject("GameSystem");
                    _system = container.AddComponent<GameSystem>();
                }
            }

            return _system;
        }
    }
    public void Update()
    {
        if (LEVEL.doubleScoreTime > 0)
        {
            LEVEL.UpdateDoubleScoreTime(Time.deltaTime);
        }
        if (LEVEL.metalIgnoreTime > 0)
        {
            LEVEL.UpdateMetalIgnoreTime(Time.deltaTime);
        }
    }
    public void Start()
    {
        LEVEL.SetBestScore(ScoreManager.Instance.LoadBestScore());
    }

    public void OnRestart()
    {
        EndGameCanvas.SetActive(true);
        GameScoreCanvas.SetActive(false);

        SceneManager.LoadScene(0);
    }
    public void OnKnifeKill()
    {
        EndScoreText.text = LEVEL.Score.ToString();
        EndBestScoreText.text = LEVEL.bestScore.ToString();
        EndGameCanvas.SetActive(true);
        GameScoreCanvas.SetActive(false);
    }
    public Level LEVEL;
}
[System.Serializable]
public class Level
{
    public float CurrentSpeed = 20;
    public int Score;
    public int bestScore;
    public Text ScoreText;
    public Text BestScoreText;
    public float doubleScoreTime = 0;  // Время действия двойного счёта
    public float metalIgnoreTime = 0;   // Время действия второго бустера
    public bool ignoreMetalObstacles = false;
    public int AdditionalScore = 0; // Новая переменная для хранения дополнительного счета
    public Text AdditionalScoreText;

    public void UpdateAdditionalScore(int amount)
    {
        AdditionalScore += amount;
        AdditionalScoreText.text = AdditionalScore.ToString();

    }
    public void SetBestScore(int score)
    {                                   
        bestScore = score;
        if (BestScoreText != null)
        {
            BestScoreText.text = bestScore.ToString();
        }
    }

    public void IncreaseScore(bool isDouble = false)
    {
        int scoreToAdd = 1;
        if (isDouble)
        {
            scoreToAdd = 2;
        }
        Score += scoreToAdd;
        ScoreText.text = Score.ToString();

        if (Score > bestScore)
        {
            bestScore = Score;
            ScoreManager.Instance.SaveBestScore(bestScore);
            if (BestScoreText != null)
            {
                BestScoreText.text = bestScore.ToString();
            }
        }

        float Speed = CurrentSpeed;
        if (CurrentSpeed != 60)
        {
            if (Score >= 200)
                Speed = 25;

            if (Score >= 400)
                Speed = 30;

            if (Score >= 600)
                Speed = 35;

            if (Score >= 800)
                Speed = 40;

            if (Score >= 1000)
                Speed = 45;

            if (Score >= 1200)
                Speed = 50;

            if (Score >= 1400)
                Speed = 55;

            if (Score >= 1600)
                Speed = 60;

            UpdateLevelSpeed(Speed);
        }
    }

    private void UpdateLevelSpeed(float Speed)
    {
        ObjectSpawner spawner = GameObject.FindObjectOfType<ObjectSpawner>();
        Animator knifeAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        if (Speed == 20)
        {
            spawner.IntervalBetweenSpawn = 0.55f;

        }
        if (Speed == 25)
        {
            spawner.IntervalBetweenSpawn = 0.48f;

        }
        if (Speed == 30)
        {
            spawner.IntervalBetweenSpawn = 0.4f;
            
        }
        if (Speed == 35)
        {
            spawner.IntervalBetweenSpawn = 0.32f;

        }
        if (Speed == 40)
        {
            spawner.IntervalBetweenSpawn = 0.25f;
            
        }
        if (Speed == 45)
        {
            spawner.IntervalBetweenSpawn = 0.2f;

        }
        if (Speed == 50)
        {
            spawner.IntervalBetweenSpawn = 0.15f;

        }
        if (Speed == 55)
        {
            spawner.IntervalBetweenSpawn = 0.1f;

        }
        if (Speed == 60)
        {
            spawner.IntervalBetweenSpawn = 0.05f;

        }
        CurrentSpeed = Speed;
    }
    public void UpdateDoubleScoreTime(float deltaTime)
    {
        if (doubleScoreTime > 0)
        {
            doubleScoreTime -= deltaTime;
            if (doubleScoreTime <= 0)
            {
                doubleScoreTime = 0;
                            
            }
        }
    }
    public void UpdateMetalIgnoreTime(float deltaTime)
    {
        if (metalIgnoreTime > 0)
        {
            metalIgnoreTime -= deltaTime;
            if (metalIgnoreTime <= 0)
            {
                metalIgnoreTime = 0;
                ignoreMetalObstacles = false; // Выключаем игнорирование
            }
        }
    }

    public void OnVegetableCut()
    {
        IncreaseScore(doubleScoreTime > 0);
    }
    public void ActivateBoosters()
    {
        // Создаем список для хранения всех доступных бустеров
        List<Action> boosters = new List<Action>();

        // Добавляем бустер для увеличения счёта
        boosters.Add(() =>
        {
            doubleScoreTime = 15.0f;
        });

        // Добавляем бустер для игнорирования MetalObstacle
        boosters.Add(() =>
        {
            ignoreMetalObstacles = true;
            metalIgnoreTime = 15.0f;
        });

        // Добавляем новый бустер для начисления дополнительного счета
        boosters.Add(() =>
        {
            UpdateAdditionalScore(10); // Начисляем 10 единиц в AdditionalScore
        });

        // Выбираем и активируем случайный бустер
        int randomIndex = UnityEngine.Random.Range(0, boosters.Count);
        boosters[randomIndex].Invoke();
    }

}
