using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int countPoints;
    public GameObject point;
    public GameObject panelExit;

    private Tower _towerComponent;
    private PipeDirectionController _pipeDirection;
    private List<GameObject> _points = new List<GameObject>();
    private Pipes _pipes;

    private RandomSpawn _randomSpawn;

    [SerializeField]
    private GameObject scorePanel = null;

    [SerializeField]
    private Text scoreText = null;

    [SerializeField]
    private Text menuScoreText = null;

    private GameObject _tower;

    void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        Menu.menu.scorePanel = scorePanel;
        Menu.menu.scoreText = menuScoreText;

        _randomSpawn = GetComponent<RandomSpawn>();

        _tower = GameObject.Find("Tower");
        _towerComponent = _tower.GetComponent<Tower>();
        _pipeDirection = _tower.GetComponent<PipeDirectionController>();
        _pipes = _tower.GetComponent<Pipes>();

        _towerComponent.SetScore(0);

        Spawn();
    }

    void Spawn()
    {
        if (_randomSpawn != null)
        {
            _points = _randomSpawn.Spawn(2, 2f);
        }
    }

    void DestroyObjects(List<GameObject> objs)
    {
        foreach (var o in objs)
        {
            Destroy(o);
        }
        objs.Clear();
    }

    void Update()
    {
        if (Next())
        {
            DestroyObjects(_pipes.GetPipes());

            _pipeDirection.sensitivity = 3;
            _pipeDirection.IsEnterPlast = false;
            Vector3 startPos = new Vector3(0, 13.6f, 0);
            _pipeDirection.Position = startPos;
            _pipeDirection.PipeStart();
            DestroyObjects(_points);
            Spawn();
        }
        scoreText.text = $"{_towerComponent.GetScore()}";

        if (Input.GetKey(KeyCode.Escape) && panelExit != null)
        {
            panelExit.SetActive(true);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    bool Next()
    {
        foreach (var point in _points)
        {
            Point p = point.GetComponent<Point>();
            if (!p.IsTrigger)
                return false;
        }
        return true;
    }
}
