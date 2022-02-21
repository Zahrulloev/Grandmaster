using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Piece : MonoBehaviour
{
    // �������� ������
    protected string _myName;

    // ID ������ �� ������� ����� ������
    protected int _myCellId;

    // �������� ������ �� ������� ����� ������
    protected string _myCellName;

    // �������� ������ ���� ������ ������� ������
    protected string _cellForMove;

    public enum Color
    {
        White,
        Black,
    }

    protected Color myColor;

    public enum PieceType
    {
        K,
        k,
        Q,
        q,
        R,
        r,
        B,
        b,
        N,
        n,
        P,
        p
    }

    /// <summary>
    /// ��� ����� ������.
    /// </summary>
    protected PieceType myType;

    /// <summary>
    /// ���������� ������� ������� �����.
    /// </summary>
    private int[] _top = new int[] { 2, 3, 4, 5, 6, 7 };

    /// <summary>
    ///  ���������� ������ ������� �����.
    /// </summary>
    private int[] _bottom = new int[] { 58, 59, 60, 61, 62, 63 };

    /// <summary>
    /// ���������� ����� ������� �����.
    /// </summary>
    private int[] _left = new int[] { 9, 17, 25, 33, 41, 49 };

    /// <summary>
    /// ���������� ������ ������� �����.
    /// </summary>
    private int[] _right = new int[] { 16, 24, 32, 40, 48, 56 };

    /// <summary>
    /// ��������� ���� �����.
    /// </summary>
    private int[] _corners = new int[] { 1, 8, 57, 64, };

    protected static Dictionary<int, string> _cellNames { get; } = new Dictionary<int, string>
    {
    {1, "a8"},
    {2, "b8"},
    {3, "c8"},
    {4, "d8"},
    {5, "e8"},
    {6, "f8"},
    {7, "g8"},
    {8, "h8"},
    {9, "a7"},
    {10, "b7"},
    {11, "c7"},
    {12, "d7"},
    {13, "e7"},
    {14, "f7"},
    {15, "g7"},
    {16, "h7"},
    {17, "a6"},
    {18, "b6"},
    {19, "c6"},
    {20, "d6"},
    {21, "e6"},
    {22, "f6"},
    {23, "g6"},
    {24, "h6"},
    {25, "a5"},
    {26, "b5"},
    {27, "c5"},
    {28, "d5"},
    {29, "e5"},
    {30, "f5"},
    {31, "g5"},
    {32, "h5"},
    {33, "a4"},
    {34, "b4"},
    {35, "c4"},
    {36, "d4"},
    {37, "e4"},
    {38, "f4"},
    {39, "g4"},
    {40, "h4"},
    {41, "a3"},
    {42, "b3"},
    {43, "c3"},
    {44, "d3"},
    {45, "e3"},
    {46, "f3"},
    {47, "g3"},
    {48, "h3"},
    {49, "a2"},
    {50, "b2"},
    {51, "c2"},
    {52, "d2"},
    {53, "e2"},
    {54, "f2"},
    {55, "g2"},
    {56, "h2"},
    {57, "a1"},
    {58, "b1"},
    {59, "c1"},
    {60, "d1"},
    {61, "e1"},
    {62, "f1"},
    {63, "g1"},
    {64, "h1"}
    };

    /// <summary>
    /// ������� ���� ��������� ����� ������.
    /// </summary>
   // public abstract void ColoringPossibleMoves();

    private void Move(string celName)
    {
        GameObject CellForMove = GameObject.Find(celName);
        Cell cel = CellForMove.GetComponent<Cell>();
        _myCellName = cel.name;
        transform.position = cel._position;
    }

    public void Unit(int cellId, string cellName, string myName)
    {
        _myCellId=cellId;
        _myCellName = cellName;
        _myName = myName;
    }


    /// <summary>
    /// ��������� ��������� ����� �����. �������� ��� �����, ����� � �����. ������� ��� ����.
    /// </summary>
    /// <param name="piecesPosition"></param>
    /// <param name="direction"></param>
    //protected void forwardBacklight(int piecesPosition, int direction)
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
    //            Color colorPieceOnCell =  // 
    //            if (_pieceColor != colorPieceOnCell) // �������� ��������� ���������.
    //            {
    //                podsvetka_kletka.GetComponent<Kletka>().atakovan = true;// ������������ ������.
    //                podsvetka_kletka.GetComponent<Kletka>().podsvetka = true; // ������������ ������. ��� ����.
    //                podsvetka_kletka.GetComponent<Kletka>().Vinovnik_podsvetki = gameObject; // ��������, ��� �� ��������� ��� ������.
    //                break;
    //            } 
    //            else break; // ������� �� ����� �� ����������� ���.   
    //        }
    //        //backlightCell.GetComponent<Cell>()._BacklightON(); // ������������ ������.
    //        //podsvetka_kletka.GetComponent<Kletka>().Vinovnik_podsvetki = gameObject; // ��������, ��� �� ��������� ��� ������.
    //    }
    //}



    /// <summary>
    /// ��������� ������-�� ��������� ������ �� ������� �����.
    /// </summary>
    /// <param name ="cellId">"Id ������"</param>
    /// <param name="direction">����������� ���������</param>
    /// <returns></returns>
    protected bool BacklightOnTheBorder(int cellId, int direction)
    {
        switch (direction)
        {
            case -8:
                foreach (int x in _top) if (x == cellId) return true;
                foreach (int xx in _corners) if (xx == cellId) return true;
                break;
            case 8:
                foreach (int x in _bottom) if (x == cellId) return true;
                foreach (int xx in _corners) if (xx == cellId) return true;
                break;
            case -1:
                foreach (int x in _left) if (x == cellId) return true;
                foreach (int xx in _corners) if (xx == cellId) return true;
                break;
            case 1:
                foreach (int x in _right) if (x == cellId) return true;
                foreach (int xx in _corners) if (xx == cellId) return true;
                break;

            case -7:
                foreach (int x in _top) if (x == cellId) return true;
                foreach (int x in _right) if (x == cellId) return true;
                foreach (int xx in _corners) if (xx == cellId) return true;
                break;
            case -9:
                foreach (int x in _top) if (x == cellId) return true;
                foreach (int x in _left) if (x == cellId) return true;
                foreach (int xx in _corners) if (xx == cellId) return true;
                break;
            case 7:
                foreach (int x in _bottom) if (x == cellId) return true;
                foreach (int x in _left) if (x == cellId) return true;
                foreach (int xx in _corners) if (xx == cellId) return true;
                break;
            case 9:
                foreach (int x in _bottom) if (x == cellId) return true;
                foreach (int x in _right) if (x == cellId) return true;
                foreach (int xx in _corners) if (xx == cellId) return true;
                break;
        }
        return false;
    }


    /// <summary>
    /// ��������� ���������� �� ������ �� �������� �����.
    /// </summary>
    /// <param name="piecesPosition">������� ������ �� �����</param>
    /// <returns></returns>
    protected string PiecesOnTheBorder(int piecesPosition)
    {
        foreach (int top in _top) if (top == piecesPosition) return "Top";
        foreach (int bottom in _bottom) if (bottom == piecesPosition) return "Bottom";
        foreach (int left in _left) if (left == piecesPosition) return "Left";
        foreach (int right in _right) if (right == piecesPosition) return "Right";
        foreach (int corner in _corners) if (corner == piecesPosition) return corner.ToString();
        return "NotBorder";
    }
}
