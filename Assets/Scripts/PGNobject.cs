using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class PGNobject : MonoBehaviour
{
    //  ���� PGN ��������. 
    private string _pgn; 

    // ������ ���������, ���������� �� ����. 
    public string _pgnAnnotation { get; private set; }

    // ���� � ����. 
    public string _pgnMoves { get; private set; }

    // ��� ������ � ������ ��������
    public string _whiteName { get; private set; }

    // ��� ������ � ������� ��������
    public string _blackName { get; private set; }

    // ��������� ������ 
    public string _rezult { get; private set; }

    // ����� ������ ������� 
    public string _date { get; private set; }

    // ������������ � ������� ������� ������. 
    public string _event { get; private set; }

    // ���� � ���� ��� �c����������� � ������ ��������. 

    public Dictionary<int, string> _moves { get; private set; } = new Dictionary<int, string>();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            print(_pgnMoves);
            print(_pgnAnnotation);
        }
    }
    
    private void SetTags(string Annotation)
    {
        string TagName = string.Empty;
        string TagValue = string.Empty;
        bool TagNameIsFilled = false;
        bool TagValueIsFilled = false;
        for (int i = 0; i < Annotation.Length; i++)
        {   
            char s =Annotation[i];
            if (s == '[')
            {
                int Quote = 0; // ���������� ��� ����� ������� � ������ � � �����.

                for (int j = i+1; j < Annotation.Length; j++)
                {
                    char c = Annotation[j];
                    if (c != ' ' && TagNameIsFilled == false)
                    {
                        TagName += c;
                    }
                    else if (c ==' ' && TagNameIsFilled == false)
                    {
                        TagNameIsFilled = true;
                        continue;
                    }
                    else if (TagNameIsFilled == true && TagValueIsFilled == false)
                    {
                        if (c != '"')
                        {
                            TagValue += c;
                        }
                        else if (c == '"')
                        {
                            Quote++;
                            if (Quote == 2)
                            {
                                switch (TagName)
                                {
                                    case "Event":
                                        _event = TagValue;
                                        break;
                                    case "White":
                                        _whiteName = TagValue;
                                        break;
                                    case "Black":
                                        _blackName = TagValue;  
                                        break;
                                    case "Result":
                                        _rezult=TagValue;
                                        break;
                                    case "Date":
                                        _date = TagValue;
                                        break;
                                        default:
                                        break;
                                }
                                TagName=string.Empty;
                                TagValue = string.Empty;
                                TagNameIsFilled=false;
                                TagValueIsFilled=false;
                                break;
                            }
                            continue;
                        }
                    }

                }
            }
        }
    }
    
    private void SetMoves(string Moves)
    {
        // ���������� ����� ����. 
        int IdMove = 0;
        string MoveKey = string.Empty;

        for (int i = 0; i < Moves.Length; i++)
        {
            char c = Moves[i];
            // ���� ����� �� �����,������, ����� ����� ����� ����.
            if (c == '.')
            {
                IdMove++;
                // ��������� �������� ��� ��� �� �����.
                for (int j = i+1; j < Moves.Length; j++)
                {
                    char d = Moves[j];
                    // ��� ����������.
                    if (d == '.')
                    { 
                        // ������� � ������ �������� ����� ������ ����.
                        // ��� ��� �� ���������� �� �����. 
                        
                        for (int num = MoveKey.Length-1;  num>0; num--)
                        {
                            if (char.IsDigit(MoveKey[num]))
                            {
                               MoveKey= MoveKey.Remove(num);
                            }
                            else break;
                        }

                        // ��������� � �������. 
                        _moves.Add(IdMove,MoveKey); 

                        // ������� ���������� ��� ������ ����. 
                        MoveKey = string.Empty;
                        break;
                    }
                    // ���������� �������� ���� �� ��������� �����. 
                    MoveKey += d;
                }
            }
        }
    }

    public void PgnToAnnotationAndMoves(string PGN)
    {
        char [] endAnnotation = {'1','.'};
        char[] endAnnotionFor = new char[2];

        for(int i = 0;i < PGN.Length; i++)
        {
            // ����� �� �������� �� ����� ������� 
            if (i== PGN.Length-1)
            {
                endAnnotionFor[0] = PGN[i-1];
                endAnnotionFor[1] = PGN[i];
            }
            else
            {
                endAnnotionFor[0] = PGN[i];
                endAnnotionFor[1] = PGN[i + 1];
            }
            if(endAnnotionFor[0] == endAnnotation[0] && endAnnotionFor[1] == endAnnotation[1])
            {
                for(int j = i;j < PGN.Length; j++)
                {
                    _pgnMoves += PGN[j];
                }
                break;
            }
            else
            {
                //if(PGN[i] == '"')
                //{
                //    _pgn_Annotation += "/";
                //    _pgn_Annotation += PGN[i];
                //}
                _pgnAnnotation+=PGN[i];
            }
        }
        SetTags(_pgnAnnotation);
        SetMoves(_pgnMoves);
    }

}
