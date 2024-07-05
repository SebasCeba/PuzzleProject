using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine.Events;

public class AnswerGraphic : MonoBehaviour 
{
    [SerializeField] private GameObject origin;
    private GameObject[][] allPanels;
    [SerializeField] private bool[][] answerKey = new bool[5][];
    [SerializeField] private float spacing;
    [SerializeField] private int gridSize;
    public UnityEvent RequestAnswerKey;
   
    private void Awake()
    {
        
        Mesh mesh = origin.GetComponent<MeshFilter>().sharedMesh;
        Bounds bounds = mesh.bounds;
        float boundsX = origin.transform.localScale.x * bounds.size.x;
        spacing = boundsX;
        
        Setup();
    }
    private void Setup()
    {
        allPanels = new GameObject[gridSize][];
        answerKey = new bool[gridSize][];
        for (int i = 0; i < gridSize; i++)
        {
            allPanels[i] = new GameObject[gridSize];
            answerKey[i] = new bool[gridSize];
            
            for (int j = 0; j < gridSize; j++)
            {
                answerKey[i][j] = new bool();
                allPanels[i][j] = Instantiate(origin, transform);
                Debug.Log("Answer Key " + i + " " + j + "initiatied");
                if (j >= 1)
                { 
                    allPanels[i][j].transform.Translate(new Vector3(0,0,-1) * spacing * j, Space.Self);
                }
                
            }
            origin.transform.Translate(- origin.transform.up * spacing * i, Space.Self);
        }
        origin.SetActive(false);
    }
    private void Start()
    {
        RequestAnswerKey.Invoke();
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                UpdateGraphic(i,j, answerKey[i][j]);
            }
        }
    }
    public bool[][] GetAnswerKey()
    {
        return answerKey;
    }
    public void RequestKeyFromEditor()
    {
        RequestAnswerKey.Invoke();
    }

    public void SetAnswerKey(bool[][] answerKey)
    {
        this.answerKey = answerKey;
    }
    public void UpdateAnswer(int row, int col, bool value)
    {
        Debug.Log(answerKey[row][col] + "Row: " + row + " Col " + col + " Value: " + value);
            answerKey[row][col] = value;
            UpdateGraphic(row, col, value);
    }
    private void UpdateGraphic(int row, int col, bool value)
    {
       if (allPanels[row][col].activeSelf == value)
        {
            return;
        }
       else
        {
            allPanels[row][col].SetActive(value);
            answerKey[row][col] = value;
        }
    }    
  
}

