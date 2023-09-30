using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Softbody : MonoBehaviour
{
    #region Constants
    private const float splineOffset = 0.5f;
    #endregion
    #region Fields
    [SerializeField]
    public SpriteShapeController spriteShape;
    [SerializeField]
    public Transform[] points;
    #endregion

    #region MonoBehavior Callbacks
    private void Awake(){
        UpdateVertices();
    }

    private void Update(){
        UpdateVertices();
    }
    #endregion

    #region privateMethods
    private void UpdateVertices(){
        for(int i = 0; i < points.Length-1;i++){
            spriteShape.spline.SetPosition(i, points[i].position);
            // Debug.Log(i + ": " + points[i].position);
            Vector2 vertex = points[i].localPosition;
            Vector2 towardsCenter = (Vector2.zero - vertex).normalized;
            float colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;
            // try{
            // spriteShape.spline.SetPosition(i, (vertex - towardsCenter * colliderRadius));
            // }catch{
            //     Debug.Log("Points too close");
            //     spriteShape.spline.SetPosition(i, (vertex - towardsCenter * (colliderRadius + splineOffset)));
            // }
        }
    }
    #endregion

}
