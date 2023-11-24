using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private Text m_label;
    [SerializeField] private GameObject m_stackObject;
    [SerializeField] private Text m_stackLabel;

    public void Set(InventoryItem item)
    {
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        if(item.stackSize <= 1)
        {
            m_stackObject.SetActive(false);
            return;
        }
        m_stackLabel.text = item.stackSize.ToString();
    }

    public void Set(ItemObject item)
    {
        m_icon.sprite = item.referenceItem.icon;
        m_label.text = item.referenceItem.displayName;
        if (item.amount <= 1)
        {
            m_stackObject.SetActive(false);
            return;
        }
        m_stackLabel.text = item.amount.ToString();
    }

    private void Awake()
    {
        if (GetComponent<ItemObject>().referenceItem != null)
        {
            Set(GetComponent<ItemObject>());
        }
    }
}
