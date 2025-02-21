using UnityEngine;

public class AnimatedObjects
{
    private string _animatedObjectName;
    private GameObject _object;
    private Animator _animator;
    private string _enterence_animation_name;
    private string _exit_animation_name;
    private string _movement_animation_name;
    private bool _isPlaying;

    public AnimatedObjects(string name, GameObject obj, Animator anim, string enterence, string exit, string movement)
    {
        this._animatedObjectName = name;
        this._object = obj;
        this._animator = anim;
        this._enterence_animation_name = enterence;
        this._exit_animation_name = exit;
        this._movement_animation_name = movement;

        this._isPlaying = false;
    }


    public string AnimatedObjectName
    {
        get { return _animatedObjectName; }
        set { _animatedObjectName = value; }
    }

    public GameObject Object
    {
        get { return _object; }
        set { _object = value; }
    }

    public Animator Animator
    {
        get { return _animator; }
        set { _animator = value; }
    }

    public string EnterenceAnimationName
    {
        get { return _enterence_animation_name; }
        set { _enterence_animation_name = value; }
    }

    public string ExitAnimationName
    {
        get { return _exit_animation_name; }
        set { _exit_animation_name = value; }
    }

    public string MovementAnimationName
    {
        get { return _movement_animation_name; }
        set { _movement_animation_name = value; }
    }

    public bool IsPlaying
    {
        get { return _isPlaying; }
        set { _isPlaying = value; }
    }

}
