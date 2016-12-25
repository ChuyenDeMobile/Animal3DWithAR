using UnityEngine;
using System.Collections;
using DG.Tweening;

public class AnimalManager : BaseAnimationManager
{
    public float speedMove = 0;
    public float speedRotation = 0;
    private float rotation = 0;

    private Vector2 origin = Vector2.zero;
    float radius = 5;

    //float x = 0;
    //float y = 0;

    private const float m_minZoom = 1f;
    private const float m_maxZoom = 1.5f;
    private Vector3 m_localScale = Vector3.one;
    public void MoveObject()
    {
        rotation += speedRotation * Time.deltaTime;
        //x = origin.x + Mathf.Sin(rotation) * radius;
        ////Debug.Log("x"+x);

        //y = origin.y + Mathf.Cos(rotation) * radius;
       // Debug.Log("y" + y);

        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z));
        // move
        transform.position += transform.forward * Time.deltaTime * speedMove;

        //transform.position = new Vector3(x,1,y);
        //transform.localEulerAngles = new Vector3(0, Mathf.Sin(rotation) * 360,0);
    }

    // override
    public override void InitGame()
    {
        m_localScale = transform.localScale;
    }
    public override void UpdateGame()
    {
    }

    public override void DoRun()
    {
        //MoveObject();
    }

    public override void DoIdle()
    {
        
    }


    [ContextMenu("idle")]
    public void ChangeToIdle()
    {
        SetAnimationByType(_AnimationState.idle);
    }

    [ContextMenu("run")]
    public void ChangeToRun()
    {
        SetAnimationByType(_AnimationState.run);
    }

    public void DoZoomIn()
    {
        if(transform.localScale.x >= m_maxZoom)
        {
            return;
        }
        transform.DOScale(transform.localScale * (m_localScale.x + 0.1f), 0.5f);
    }

    public void DoZoomOut()
    {
        if (transform.localScale.x <= m_minZoom)
        {
            return;
        }
        transform.DOScale(transform.localScale * (m_localScale.x - 0.1f), 0.5f);
    }
}
