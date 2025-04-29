using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public void OnContinueButton()
    {
        QuoteManager.Instance.HideQuoteAndContinue();
    }
}
