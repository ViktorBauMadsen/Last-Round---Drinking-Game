using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public QuoteManager QuoteManager
    {
        get => default;
        set
        {
        }
    }

    public void OnContinueButton()
    {
        QuoteManager.Instance.HideQuoteAndContinue();
    }
}
