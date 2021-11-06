using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controEnemylManager
{
    private controEnemylManager() { }
    private static controEnemylManager instance;
    public static controEnemylManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new controEnemylManager();
            }
            return instance;
        }
        
    }

    
    private float _speed;

    private int _level;

    public int Level { get => _level; set => _level = value; }

    public int HpAlgo(int level)
    {
        return level;//not yet
    }

    public float speedAlgo()
    {
        return _speed*Level;
    }


}
