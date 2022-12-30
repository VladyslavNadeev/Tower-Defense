using UnityEngine;

public class GrenadierView : EnemyView
{
    public void OnDieAnimationFinished()
    {
        _enemy.Recycle();
    }

    public void OnStepAnimation()
    {
       
    }
}

