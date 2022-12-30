using System.Collections;
using UnityEngine;

public class EllenView : EnemyView
{
    public void OnDieAnimationFinished()
    {
        _enemy.Recycle();
    }

    public void OnStepAnimation()
    {

    }
}

