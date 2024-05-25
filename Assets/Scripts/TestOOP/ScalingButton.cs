using UnityEngine;

/*
This button will grow to the target scale when the mouse hovers over the button,
if not, then scale back to its original size.
*/
public class ScalingButton : ButtonBase // INHERITANCE
{
	[SerializeField]
	Vector3 _targetScale;

	[SerializeField]
	float _scalingDuration;

	float _scalingElapsedTime;

	Vector3 _originalScale;

	// true if the button is in scaling/scaling back
	bool _isScalingStarted;

	// true when the button is in returning to its original size
	bool _isScalingBack;

	// Start is called before the first frame update
	void Start()
	{
		_originalScale = transform.localScale;
		_isScalingStarted = false;

		// display tooltip as text
		ButtonTooltip = "Hover to change scale";
		_cachedTextComponent.text = ButtonTooltip;

		ChangeTextColor(Color.blue);
	}

	// Update is called once per frame
	void Update()
	{
		if (_isScalingStarted)
		{
			ProcessScaling(Time.deltaTime);
		}
	}

	void ProcessScaling(float dt) // ABSTRACTION
	{
		if (_scalingElapsedTime < _scalingDuration)
		{
			if (!_isScalingBack) // scaling to target scale
			{
				transform.localScale = Vector3.Lerp(_originalScale, _targetScale, _scalingElapsedTime / _scalingDuration);
			}
			else // scaling back
			{
				transform.localScale = Vector3.Lerp(_targetScale, _originalScale, _scalingElapsedTime / _scalingDuration);
			}
			_scalingElapsedTime += dt;
		}
		else // when scaling finished
		{
			transform.localScale = !_isScalingBack ? _targetScale : _originalScale;
			_isScalingStarted = false;
		}
	}

	protected override void OnHoverStart() // POLYMORPHISM
	{
		if (!_isScalingStarted)
		{
			_scalingElapsedTime = 0.0f;
			_isScalingBack = false;
			_isScalingStarted = true;
		}
	}

	protected override void OnHoverEnd() // POLYMORPHISM
	{
		if (!_isScalingStarted)
		{
			_scalingElapsedTime = 0.0f;
			_isScalingBack = true;
			_isScalingStarted = true;
		}
	}
}
