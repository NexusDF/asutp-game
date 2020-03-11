using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Tower tower;
    public bool IsOut { get; set; }

    void Start()
    {
        tower = GameObject.Find("Tower").GetComponent<Tower>();
    }

    public void GetOut(Vector3 pos)
    {
        if (Mathf.Abs(pos.x) > 4.8f || Mathf.Abs(pos.z) > 4.8f)
        {
            GameOver(tower.GetScore());
        }
    }

    public void GameOver(int score)
    {
        Menu.menu.Open(score);
        tower.SetScore(0);
    }
}
