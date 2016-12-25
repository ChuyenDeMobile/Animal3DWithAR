using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public enum _AnimationState
{
    idle = 1,
    run = 2,
    walk =3,
    attack = 4
}


public class BaseAnimationManager : MonoBehaviour {
    public Animation animationOfThis;
    public _AnimationState currState;

    public string currStrState = null;

    // time
    private const float minLimiteTime = 5f;
    private const float maxLimiteTime = 7f;

    private float timeOfAttack = 0;
    void Awake()
    {
        animationOfThis = gameObject.GetComponent<Animation>();
        //thoi gian attack cua object
        timeOfAttack = animationOfThis[_AnimationState.attack.ToString()].clip.length;
    }

    void OnEnable()
    {
        ResetAnimation();
        // set audio when tracked
        string name = gameObject.name;
        _AudioType audioType = (_AudioType)System.Enum.Parse(typeof(_AudioType),name);
        AudioManager.Instance.PlayAudioByType(audioType);
    }

    // ban dau animation 
    public void ResetAnimation()
    {
        SetAnimationByType(_AnimationState.idle);
        StartCoroutine(RandomState());
    }

    [ContextMenu("test!")]
    public IEnumerator RandomState()
    {
        while(true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minLimiteTime, maxLimiteTime));
            Debug.Log("change state!");

            do
            {
                currState = GetRandomEnum<_AnimationState>();
            }
            while (currState == _AnimationState.attack);

            if (currStrState != null)
            {
                StopCoroutine(currStrState);
            }

            switch (currState)
            {
                case _AnimationState.idle:
                    currStrState = "UpdateIdle";
                    break;
                case _AnimationState.walk:
                    currStrState = "UpdateWalk";
                    break;
                case _AnimationState.attack:
                    currStrState = "UpdateAttack";
                    break;
                case _AnimationState.run:
                    currStrState = "UpdateRun";
                    break;
            }
            StartCoroutine(currStrState);
            SetAnimationByType(currState);
        }
    }

    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SetAnimationByType(_AnimationState _type)
    {
        animationOfThis.CrossFade(_type.ToString());
    }

    public void Attack()
    {
        StopAllCoroutines();
        SetAnimationByType(_AnimationState.attack);
        Invoke("ResetAnimation", timeOfAttack - 0.1f);
    }


	// Use this for initialization
	void Start () {
        InitGame();
	}

    #region COROUTINES
    private IEnumerator UpdateRun()
    {
        while(true)
        {
            if(currState != _AnimationState.run) // ???
            {
                break;
            }
            DoRun();
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator UpdateWalk()
    {
        while (true)
        {
            if (currState != _AnimationState.walk)
            {
                break;
            }
            DoWalk();
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator UpdateAttack()
    {
        while (true)
        {
            if (currState != _AnimationState.walk)
            {
                break;
            }

            yield return new WaitForFixedUpdate();
        }
    }


    private IEnumerator UpdateIdle()
    {
        while (true)
        {
            if (currState != _AnimationState.idle)
            {
                break;
            }
            DoIdle();
            yield return new WaitForFixedUpdate();
        }
    }

    #endregion

    #region OVERRIDE
    // do some thing object when state move
    public virtual void DoRun()
    {

    }


    //do something with object when state idle
    public virtual void DoIdle()
    {

    }

    public virtual void DoWalk()
    {

    }

    public virtual void DoAttack()
    {

    }
    #endregion


    // Update is called once per frame
	void Update () {
        UpdateGame();
        //Debug.Log(animationOfThis["idle"].clip.length);
	}

    //override
    public virtual void InitGame()
    {
        return;
    }
    public virtual void UpdateGame()
    {
        return;
    }
}
