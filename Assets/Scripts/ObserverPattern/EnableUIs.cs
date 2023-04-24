using UnityEngine;

public class EnableUIs : MonoBehaviour, IObserver
{
    [SerializeField] Subject _playerSubject;
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] GameObject levelReload;
    public void OnNotify(UIPanels panels)
    {
        switch(panels)
        {
            case (UIPanels.LevelComplete):
                levelCompletePanel.SetActive(true);
                break;
            case (UIPanels.LevelReload):
                levelReload.SetActive(true);
                break;
        }
    }

    private void OnEnable()
    {
        _playerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }
}
