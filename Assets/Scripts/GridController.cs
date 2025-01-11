using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController _instance;
    public static GridController Instance
    {
        get { return _instance;}
    }

    private Pet[,] _grid;

    public Pet[,] Grid
    {
        get => _grid;
        set { _grid = value; }
    }

    private void Awake()
    {
        if (_instance!=null&&_instance!=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
