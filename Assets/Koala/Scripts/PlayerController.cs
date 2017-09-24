using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private float DirectionDampTime = 0.25f;
    private float speed = 0.0f;
    private float _horizontal = 0.0f;
    private float _vertical = 0.0f;

	// Use this for initialization
	void Start ()
	{
	    _animator = GetComponent<Animator>();
	    if (_animator.layerCount >= 2)
	    {
	        _animator.SetLayerWeight(1,1);
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (_animator)
	    {
	        _horizontal = Input.GetAxis("Horizontal");
	        _vertical = Input.GetAxis("Vertical");
	        speed = new Vector2(_horizontal, _vertical).sqrMagnitude;

            _animator.SetFloat("Speed", speed);
            _animator.SetFloat("Direction", _horizontal, DirectionDampTime, Time.deltaTime);
	    }
	}
}
