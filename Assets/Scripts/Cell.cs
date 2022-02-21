using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int _id { get; private set; }
    public string _name { get; private set; }

    public bool _isOccupied { get; private set; }

    public GameObject _occupiedPiece { get; private set; }
    public Vector3 _position { get; private set; }


    private void Start()
    {
        _position = transform.position; 
    }
    
    /// <summary>
    /// Инициализая клетки
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public void Unit(int id, string name)
    {
        _id = id;
        _name = name;
    }

    /// <summary>
    /// Ставит на клетку фигуру.
    /// </summary>
    /// <param name="piece"></param>
    public void Occupied (GameObject piece)
    {
            _isOccupied = true;
            _occupiedPiece = piece;
    }

    /// <summary>
    /// Убирает с клетки фигуру
    /// </summary>
    public void AnOccupied()
    {
        _occupiedPiece = null;
        _isOccupied = false;
    }

    /// <summary>
    /// Возврашает true если на клетке есть фигура 
    /// </summary>
    /// <returns></returns>
    public bool IsOccupied()
    {
        return _isOccupied;
    }

    /// <summary>
    /// Возвращает GameObject 
    /// </summary>
    /// <returns></returns>
    public GameObject GetPieceOnTheCell()
    {
        return _occupiedPiece;
    }


}
