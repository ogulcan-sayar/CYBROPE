using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    [HideInInspector] public LineRenderer lineRenderer;
    private EdgeCollider2D edgeColl;
    public static Line instance;
    private Vector2 hitPoint;
    public bool ipKesildi;


    void Start()
    {
        
        instance = this;
        lineRenderer = GetComponent<LineRenderer>();
        edgeColl = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ipiOlustur(Vector2 origin, Vector2 target)
    {
        hitPoint = target;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, target);
        
        Vector2[] colPoints = { origin, target};
        edgeColl.points = colPoints;
    }

    public void ipiBol(Vector2 kesilenYer)
    {
        
        lineRenderer.SetPosition(0, kesilenYer);
        lineRenderer.SetPosition(1, hitPoint);
        lineRenderer.enabled = true;
        StartCoroutine(ipKes());
    }

    public void ipiSal()
    {
        lineRenderer.enabled = false;
    }
    
    IEnumerator ipKes ()
    {
        yield return new WaitForSeconds(0.8f);
        ipKesildi = false;

    }

}
