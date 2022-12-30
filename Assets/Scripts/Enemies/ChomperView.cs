using System.Collections;
using UnityEngine;

public class ChomperView : EnemyView
{
    public void OnDieAnimationFinished()
    {
        _enemy.Recycle();
    }

    public void OnStepAnimation()
    {

    }
}
