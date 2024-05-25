using UnityEngine;
using UnityEngine.UI;

/* 
This button will change color when the mouse hovers over the button,
if not, then returns back to its original color
*/
public class ColorChangingButton : ButtonBase // INHERITANCE
{
	[SerializeField]
	Color _colorToChange;

	Color _originalColor;

	Image _cachedImageComp;

	// Start is called before the first frame update
	void Start()
	{
		_cachedImageComp = GetComponent<Image>();
		// display tooltip as text
		ButtonTooltip = "Hover to change color";
		_cachedTextComponent.text = ButtonTooltip;

		// set text color to black
		ChangeTextColor(0.0f, 0.0f, 0.0f, 1.0f);
	}

	protected override void OnHoverStart() // POLYMORPHISM
	{
		// change its color
		_originalColor = _cachedImageComp.color;
		_cachedImageComp.color = _colorToChange;
	}

	protected override void OnHoverEnd() // POLYMORPHISM
	{
		// change back to original color
		_cachedImageComp.color = _originalColor;
	}
}
