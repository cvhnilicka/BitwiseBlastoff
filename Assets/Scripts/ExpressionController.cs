using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpressionController : MonoBehaviour
{
    Text expressionText;

    private void Awake()
    {
        expressionText = GetComponent<Text>();

    }

    public void SetExpression(string expression)
    {
        this.expressionText.text = expression;
    }
}
