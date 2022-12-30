using UnityEngine;

public class GameTile : MonoBehaviour
{
    [SerializeField]
    private Transform _arrow;

    private GameTile _north, _east, _south, _west, _nextOnPath;

    private int _distance;
    public bool HasPath => _distance != int.MaxValue;
    public bool IsAlternative { get; set; }

    private Quaternion _northRotation = Quaternion.Euler(90f, 270f, 0f);
    private Quaternion _southRotation = Quaternion.Euler(90f, 90f, 0f);
    private Quaternion _eastRotation = Quaternion.Euler(90f, 0f, 0f);
    private Quaternion _westhRotation = Quaternion.Euler(90f, 180f, 0f);

    private GameTileContent _content;

    public GameTile NextTileOnPath => _nextOnPath;

    public Vector3 ExitPoint { get; private set; }

    public Vector3 Position => transform.position;

    public Direction PathDirection { get; private set; }

    public GameTileContent Content
    {
        get => _content;
        set
        {
            if(_content != null)
            {
                _content.Recycle();
            }
            _content = value;
            _content.transform.localPosition = transform.localPosition;
        }
    }
    public static void MakeEastWestNeighbors(GameTile east, GameTile west)
    {
        west._east = east;
        east._west = west;
    }

    public static void MakeNorthSouthNeighbors(GameTile north, GameTile south)
    {
        south._north = north;
        north._south = south;
    }

    
    public void ClearPath()
    {
        _distance = int.MaxValue;
        _nextOnPath = null;

    }

    public void BecomeDestination()
    {
        _distance = 0;
        _nextOnPath = null;
        ExitPoint = transform.localPosition;
    }

    private GameTile GrowPathTo(GameTile neighbour, Direction direction)
    {
        if(!HasPath || neighbour == null || neighbour.HasPath)
        {
            return null;
        }
        neighbour._distance = _distance + 1;
        neighbour._nextOnPath = this;
        neighbour.ExitPoint = neighbour.transform.localPosition + direction.GetHalfVector();
        neighbour.PathDirection = direction;
        return neighbour.Content.IsBlockingPath ? null : neighbour;
    }

    public GameTile GrowPathNorth() => GrowPathTo(_north, Direction.South);
    public GameTile GrowPathEast() => GrowPathTo(_east, Direction.West);
    public GameTile GrowPathSouth() => GrowPathTo(_south, Direction.North);
    public GameTile GrowPathWest() => GrowPathTo(_west, Direction.East);

    public void ShowPath()
    {
        if(_distance == 0)
        {
            _arrow.gameObject.SetActive(false);
            return;
        }
        _arrow.gameObject.SetActive(true);
        _arrow.localRotation =
            _nextOnPath == _north ? _northRotation :
            _nextOnPath == _east ? _eastRotation :
            _nextOnPath == _south ? _southRotation :
            _westhRotation;
            

    }
}

