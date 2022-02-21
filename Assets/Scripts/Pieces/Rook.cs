using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    /// <summary>
    /// Позиция фигуры на доске. Показывает на какой клетке он стоит.
    /// </summary>
    public int _myPosition;

    // Конструктора для _myPosition. Метод вызывается в классе Doska.
    public void MyPosition(int pos)
    {
        _myPosition = pos;
    }

    public bool isActiv { get; set; }

    private void Start()
    {
        //// Инициализируем Свет и Тип фигуры.
        //string thisPiecesName = transform.name;
        //if (thisPiecesName[0] == 'R')
        //{
        //    _pieceType = PieceType.R;
        //    _pieceColor = PieceColor.white;
        //}
        //else if (thisPiecesName[0] == 'r')
        //{
        //    _pieceType = PieceType.r;
        //    _pieceColor = PieceColor.black;
        //}
        //else print("Тип фигуры не определен!");
    }


    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            isActiv = true;
            //ColoringPossibleMoves();
        }
    }

    //public override void ColoringPossibleMoves()
    //{
    //    if ("NotBorder" == PiecesOnTheBorder(_myPosition))
    //    {
            
    //        forwardBacklight(_myPosition, -8);
    //        forwardBacklight(_myPosition, 8);
    //        forwardBacklight(_myPosition, -1);
    //        forwardBacklight(_myPosition, 1);
    //    }
    //    else
    //    {
    //        string s = PiecesOnTheBorder(_myPosition);
    //        switch (s)
    //        {
    //            case "Top":
    //                forwardBacklight(_myPosition, 8);
    //                forwardBacklight(_myPosition, -1);
    //                forwardBacklight(_myPosition, 1);
    //                break;
    //            case "Bottom":
    //                forwardBacklight(_myPosition, -8);
    //                forwardBacklight(_myPosition, -1);
    //                forwardBacklight(_myPosition, 1);
    //                break;
    //            case "Left":
    //                forwardBacklight(_myPosition, 1);
    //                forwardBacklight(_myPosition, -8);
    //                forwardBacklight(_myPosition, 8);
    //                break;
    //            case "Right":
    //                forwardBacklight(_myPosition, -1);
    //                forwardBacklight(_myPosition, -8);
    //                forwardBacklight(_myPosition, 8);
    //                break;
    //            case "1":
    //                forwardBacklight(_myPosition, 8);
    //                forwardBacklight(_myPosition, 1);
    //                break;
    //            case "8":
    //                forwardBacklight(_myPosition, 8);
    //                forwardBacklight(_myPosition, -1);
    //                break;
    //            case "57":
    //                forwardBacklight(_myPosition, -8);
    //                forwardBacklight(_myPosition, 1);
    //                break;
    //            case "64":
    //                forwardBacklight(_myPosition, -8);
    //                forwardBacklight(_myPosition, -1);
    //                break;
    //        }
    //    }
    //}

    //private void forwardBacklight(int piecesPosition, int direction)
    //{
    //    // в начале подсвечиваямая клетка равна клетки в котором стоим. А потом мы его будем изменять.
    //    int backlightID = piecesPosition;
    //    while (true)
    //    {
    //        backlightID = backlightID + direction; // Находим id подсвечиваемой клетки.
    //        if (BacklightOnTheBorder(backlightID, direction)) break; // если подсветка пришла на границу выходим из цикла.
    //        var backlightCell = GameObject.Find(_cellNames[backlightID]); // находим подсвечиваемую клетку.

    //        if (backlightCell.GetComponent<Cell>().IsOccupied() == true)// Если подсвечиваемая клетка занята.
    //        {
    //            GameObject pieceOnCell = backlightCell.GetComponent<Cell>().GetPieceOnTheCell(); // Фигура которая стоит на подсвечиваемой клетки.
    //            Color colorPieceOnCell =   

    //            //Если свет фигуры не равно цвету нашей фигуры. 
    //            if (_pieceColor != colorPieceOnCell) // Включаем атакующую подсветку.
    //            { 
    //                // Реализация функционала. 
    //                break;
    //            }
    //            else break; // выходим из цикла не подсвечивая его.   
    //        }
    //        backlightCell.GetComponent<Cell>()._BacklightON(); // подсвечиваем клетку.
    //        //backlightCell.GetComponent<Cell>().Occupied(gameObject); // передаем, что мы посветили эту клетку.
    //    }
    //}
}
