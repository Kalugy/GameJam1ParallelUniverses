using System;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{
    public static GameManagerX Instance { get; private set; }

    public bool haveKey;

    private void Awake()
    {
        if (Instance != null & Instance != this) Destroy(this);
        else Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
