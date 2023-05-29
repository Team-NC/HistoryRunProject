using UnityEngine;
using UnityEngine.Rendering;

public class PUZ_DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;

    public int correctPieces = 0;
    
    private int OIL = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("PUZ"))
            {
                if (!hit.transform.GetComponent<PUZ_PiecesScript>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PUZ_PiecesScript>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<PUZ_PiecesScript>().Selected = false;
                SelectedPiece = null;
                // if (SelectedPiece.GetComponent<PUZ_PiecesScript>().InRightPosition == true)
                // {
                //     Debug.Log("check");
                // }
            }

        }

        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
            
    }
}
