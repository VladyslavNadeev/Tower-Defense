using Assets.Scripts.Debuffs;
using UnityEngine;

[SelectionBase]
public class GameTileContent : MonoBehaviour
{
    [SerializeField]
    private GameTileContentType _contentType;

    [SerializeField]
    private TargetPointTrigger _trigger;

    public GameTileContentType ContentType => _contentType;

    public GameTileContentFactory OriginFactory { get; set; }

    public bool IsBlockingPath => ContentType > GameTileContentType.BeforeBlockers;

    private void Awake()
    {
        if (_trigger != null)
            _trigger.Entered += OnTargetEntered;
    }

    private void OnTargetEntered(TargetPoint targetPoint)
    {
        targetPoint.Enemy.DebuffWrapper.Replace(ContentType.GetDebuff());
    }

    private void OnDestroy()
    {
        if (_trigger != null)
            _trigger.Entered -= OnTargetEntered;
    }

    public void Recycle()
    {
        OriginFactory.Reclaim(this);
    }
    public virtual void GameUpdate()
    {
        if (_trigger != null)
            _trigger.UpdateSelf();
    }
}


