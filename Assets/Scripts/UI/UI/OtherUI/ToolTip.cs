using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private Text toolTipText;
    private Text contentText;
    private CanvasGroup canvasGroup;
    private bool isShow;
    private Vector2 toolTipPosionOffset = new Vector2(90, -90);
    private float targetAlpha = 0;

    public float smoothing = 5;

    void Start()
    {
        toolTipText = GetComponent<Text>();
        contentText = transform.Find("Content").GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
        if(isShow)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.transform as RectTransform, Input.mousePosition, null, out position);
            SetLocalPotion(position + toolTipPosionOffset);
        }
    }

    public void Show(string text)
    {
        isShow = true;
        toolTipText.text = text;
        contentText.text = text;
        targetAlpha = 1;
    }
    public void Hide()
    {
        isShow = false;
        targetAlpha = 0;
    }
    public void SetLocalPotion(Vector3 position)
    {
        transform.localPosition = position;
    }
}
