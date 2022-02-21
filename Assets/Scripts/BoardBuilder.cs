using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject _board;

    private string _startFenPos = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    [SerializeField]
    private GameObject _blackSquare;

    [SerializeField]
    private GameObject _whiteSquare;

    [SerializeField]
    private float _size = 0.068f;

    [SerializeField]
    private float offset = 0.68f;

    [SerializeField]
    private Vector3 _startBuildPoint= new Vector3(-2.39f,3.57f,0);

    [SerializeField]
    private GameObject[] _pieces;


    /// <summary>
    /// Название клеток
    /// </summary>
    private static Dictionary<int, string> _cellNames = new Dictionary<int, string>
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



    private void Start()
    {
        BuildBord();
        BuildPieces(_startFenPos);
    }

   
    private void BuildBord()
    {
        Vector3 Pos = _startBuildPoint;
        bool black = false;
        int Id = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Id++;   
                if (black == true)
                {
                    BuildSquare(_blackSquare, Pos,Id);
                    black = !black;
                }
                else
                {
                    BuildSquare(_whiteSquare, Pos ,Id);
                    black = !black;
                }
                Pos.x += offset;
            }
            Pos.y -= offset;
            Pos.x = _startBuildPoint.x;
            black = !black;
        }
    }

    private void BuildSquare(GameObject square,Vector3 position, int id)
    {
        // Создаем новую клетку
        GameObject Square = Instantiate(square, _board.transform);

        string celname = string.Empty;

        // Ищем имя клетки по ID из словаряю
        foreach (var num in _cellNames)
        {
            if (num.Key == id)
            {
                celname = num.Value;
            }
        }

        // Изменяем размер клетки 
        Square.transform.localScale = new Vector3(_size, _size, 0);

        // Изменяем позицию созданной клетки
        Square.transform.position = position;

        // Иницализируем клетку. 
        Square.transform.GetComponent<Cell>().Unit(id,celname);

        // Меняем имя клетки в инспекторе. 
        Square.transform.name = celname;

    }


    /// <summary>
    /// Ставить фигуры на доску сверяясь с fen нотацией.
    /// </summary>
    /// <param name="_fen"></param>
    private void BuildPieces(string fen)
    {
        // Ссылки на префабы фигур.  
        Dictionary<char, GameObject> _piecePrefabs = new Dictionary<char, GameObject>
         {
            {'K', _pieces[0] },
            {'Q',_pieces[1] },
            {'B', _pieces[2] },
            {'N',_pieces[3] },
            {'R', _pieces[4] },
            {'P',_pieces[5] },
            {'k', _pieces[6] },
            {'q',_pieces[7] },
            {'b', _pieces[8] },
            {'n', _pieces[9] },
            {'r',_pieces[10] },
            {'p', _pieces[11] },
         };

        char[] _white = { 'R', 'N', 'B', 'Q', 'K', 'P' };
        char[] _black = { 'r', 'n', 'b', 'q', 'k', 'p' };

        int count = 0;

        // удаляем старую позицию. 
        //EmptyBorder();

        // Cоздаем новую позицию.
        foreach (char s in fen)
        {
            // Пропускаем пустые клетки. 
            if (s >= '1' && s <= '8') count += s - '1' + 1;
            for (int i = 0; i < 6; i++)
            {
                char _NameWhite = _white[i];
                char _NameBlack = _black[i];

                if (s == _NameBlack)
                {
                    count = count + 1;
                    AddPiece();
                }
                else if (s == _NameWhite)
                {
                    count = count + 1;
                    AddPiece();
                }
            }
            // Создает фигуру.
            void AddPiece()
            {
                string cellName = _cellNames[count]; // Находим название клетки.
                GameObject cell = GameObject.Find(cellName); // Находим саму клетку на которую надо встать.
                Vector3 piecePosition = new Vector3(cell.transform.position.x, cell.transform.position.y, -1); // получаем трансформ клетки на которую надо вставить фигуру.
                GameObject piece = Instantiate(_piecePrefabs[s], _board.transform); // Создаем фигуру и делаем его дочерным обьектом к доске.
                piece.transform.position = piecePosition; // Перемещаем фигуру на клетку. 
                piece.gameObject.GetComponent<Piece>().Unit(count,cellName, _piecePrefabs[s].ToString()); // передаем позицию скрипту фигуры.
                piece.gameObject.tag = "Piece";
                cell.GetComponent<Cell>().Occupied(piece); // Передаем клетке, что его заняли. 
            }
        }
    }
}
