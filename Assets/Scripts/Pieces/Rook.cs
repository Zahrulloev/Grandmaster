using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    /// <summary>
    /// ������� ������ �� �����. ���������� �� ����� ������ �� �����.
    /// </summary>
    public int _myPosition;

    // ������������ ��� _myPosition. ����� ���������� � ������ Doska.
    public void MyPosition(int pos)
    {
        _myPosition = pos;
    }

    public bool isActiv { get; set; }

    private void Start()
    {
        //// �������������� ���� � ��� ������.
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
        //else print("��� ������ �� ���������!");
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
    //    // � ������ �������������� ������ ����� ������ � ������� �����. � ����� �� ��� ����� ��������.
    //    int backlightID = piecesPosition;
    //    while (true)
    //    {
    //        backlightID = backlightID + direction; // ������� id �������������� ������.
    //        if (BacklightOnTheBorder(backlightID, direction)) break; // ���� ��������� ������ �� ������� ������� �� �����.
    //        var backlightCell = GameObject.Find(_cellNames[backlightID]); // ������� �������������� ������.

    //        if (backlightCell.GetComponent<Cell>().IsOccupied() == true)// ���� �������������� ������ ������.
    //        {
    //            GameObject pieceOnCell = backlightCell.GetComponent<Cell>().GetPieceOnTheCell(); // ������ ������� ����� �� �������������� ������.
    //            Color colorPieceOnCell =   

    //            //���� ���� ������ �� ����� ����� ����� ������. 
    //            if (_pieceColor != colorPieceOnCell) // �������� ��������� ���������.
    //            { 
    //                // ���������� �����������. 
    //                break;
    //            }
    //            else break; // ������� �� ����� �� ����������� ���.   
    //        }
    //        backlightCell.GetComponent<Cell>()._BacklightON(); // ������������ ������.
    //        //backlightCell.GetComponent<Cell>().Occupied(gameObject); // ��������, ��� �� ��������� ��� ������.
    //    }
    //}
}
