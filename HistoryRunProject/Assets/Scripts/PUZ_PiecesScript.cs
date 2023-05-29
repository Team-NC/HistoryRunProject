using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PUZ_PiecesScript : MonoBehaviour
{
    private Vector3 RightPosition;

    public bool InRightPosition;

    public bool Selected;

    private PUZ_DragAndDrop _puzDragAndDrop;

    private int pieces = 16;
    
    // Start is called before the first frame update
    void Start()
    {
        RightPosition = transform.localPosition;
        // transform.localPosition = new Vector3(-4, -10);
        transform.localPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-12f, -10f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.localPosition, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.localPosition = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    _puzDragAndDrop = GameObject.Find("Main Camera").GetComponent<PUZ_DragAndDrop>();
                    _puzDragAndDrop.correctPieces++;
                    Debug.Log(_puzDragAndDrop.correctPieces);
                    
                    if (_puzDragAndDrop.correctPieces == pieces)
                    {
                        SceneManager.LoadScene("PuzzleDoneScene");
                    }
                }
                
            }
        }
    }
}