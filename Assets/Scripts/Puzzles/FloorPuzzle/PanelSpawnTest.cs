using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelSpawnTest : MonoBehaviour
{
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private GameObject original;
    [SerializeField] private float width;

    private void Awake()
    {
        if (original == null)
        {
            meshFilter = GetComponentInChildren<MeshFilter>();
        }

        Bounds bounds = meshFilter.sharedMesh.bounds;
        width = bounds.size.x * 2.1f * original.transform.localScale.x;


    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPanels();
    }

    void SpawnPanels()
    {
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject temp = Instantiate(original, transform);
                temp.transform.position += i * width * transform.right;
                temp.transform.position += j * width * -transform.up;

        
            }
        }
        original.SetActive(false);
    }

}
