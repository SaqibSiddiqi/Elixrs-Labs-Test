using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Public Variables
    public int Game_State;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
