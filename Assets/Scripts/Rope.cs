using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope
{

    List<Link> links;

    GameObject gameObject;
    LineRenderer lineRenderer;
    EdgeCollider2D edgeCollider;
    HingeJoint2D weightJoint;
    Vector3[] points;
    Vector3[] points3D;
    Vector2[] points2D;
    float smooth = 3.0f;

    bool cut = false;

    public EdgeCollider2D EdgeCollider
    {
        get
        {
            return edgeCollider;
        }
    }

    public Rope(Vector3 origine, Vector3 destination, float length, float linkPerUnit=2.0f, float mass=5.0f, int layer=0)
    {

        gameObject = new GameObject("Rope");
        links = new List<Link>();

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.sortingLayerName = "Rope";
        lineRenderer.material = RessourceManager.GetRopeMaterial();
        lineRenderer.textureMode = LineTextureMode.RepeatPerSegment;

        edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        EdgeCollider.isTrigger = true;

        Vector3 direction = (destination - origine).normalized;
        Vector3 offset = (destination - origine);

        int nbLink = (int)(length * linkPerUnit)+1;
        float lastLinkSize = length - (nbLink - 2) * (1 / linkPerUnit);

        for (int i = 0; i < nbLink; i++)
        {
            Vector3 position = origine + offset / nbLink * i;
            Link link;
            if (i== nbLink-1) link = new Link(position, direction, lastLinkSize, mass, 8);
            else link = new Link(position, direction, 1 /linkPerUnit, mass, 8);
            link.SetParent(gameObject);
            if (i != 0) link.SetConnectedBody(links[i - 1].GetRigidbody());
            links.Add(link);
        }

        points = new Vector3[links.Count];
        points2D = new Vector2[links.Count * (int)smooth];
        points3D = new Vector3[links.Count * (int)smooth];
    }

    //Set the rope anchor
    public void SetAnchor(Rigidbody2D rb)
    {
        links[0].SetFirst(rb);
    }

    //Set the rope link to weight
    public void SetWeight(GameObject weight)
    {
        weightJoint = weight.AddComponent<HingeJoint2D>();
        weightJoint.connectedBody = links[links.Count - 1].GetRigidbody();
        weightJoint.autoConfigureConnectedAnchor = false;
        weightJoint.anchor = Vector2.zero;
        weightJoint.connectedAnchor = Vector2.zero;
    }

    // Update is called once per frame
    public void Update()
    {
        //Update points array for edgeRenderer and lineRenderer
        for (int i = 0; i< links.Count; ++i)
        {
            points[i] = links[i].GetPosition();
        }

        points3D = Curver.MakeSmoothCurve(points, smooth);

        for (int i = 0; i < points3D.Length; ++i)
        {
            points2D[i] = points3D[i];
        }

        //EdgeCollider update
        EdgeCollider.points = points2D;

        //LineRenderer update
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = points3D.Length;
        lineRenderer.SetPositions(points3D);
    }

    public bool HasLink(GameObject obj)
    {
        foreach(Link link in links)
        {
            if(link.gameObject == obj)
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    public void Cut()
    {
        lineRenderer.enabled = false;
        if (weightJoint) Object.Destroy(weightJoint);
        Object.Instantiate(RessourceManager.GetRopeAudio());
        Object.Destroy(gameObject);
    }
}
