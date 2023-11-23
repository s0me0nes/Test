using TMPro;
using UnityEngine;

public class CoinUIUpdater : MonoBehaviour
{
    [Inject]
    private ReactiveProperty<int> _coinCount;

    [Inject]
    private TextMeshProUGUI _coinText;

    private void Start()
    {
        _coinCount.Subscribe(UpdateCoinText);
    }

    private void UpdateCoinText(int coins)
    {
        _coinText.text = coins.ToString();
    }

}
