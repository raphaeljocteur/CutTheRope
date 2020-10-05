using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link
{

    public GameObject gameObject;
    public Rigidbody2D body;
    public HingeJoint2D joint;
    public CircleCollider2D collider;

    public Link(Vector3 position, Vector3 direction, float size, float mass, int layer = 0)
    {

        gameObject = new GameObject("Link");
        gameObject.layer = layer;
        gameObject.transform.position = position;

        body = gameObject.AddComponent<Rigidbody2D>();
        body.angularDrag = 0.0f;
        body.mass = mass;

        joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = direction * size;

        collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius = 0.5f * size;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public void SetFirst(Rigidbody2D jointBody)
    {
        joint.connectedAnchor = Vector2.zero;
        joint.connectedBody = jointBody;
    }

    public void SetParent(GameObject obj)
    {
        gameObject.transform.parent = obj.transform;
    }

    public Rigidbody2D GetRigidbody()
    {
        return body;
    }

    public void SetConnectedBody(Rigidbody2D rigidbody)
    {
        joint.connectedBody = rigidbody;
    }

}
