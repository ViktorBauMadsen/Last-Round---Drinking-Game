using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OnContinueButton()
    {
        QuoteManager.Instance.HideQuoteAndContinue();
    }
}
